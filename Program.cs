using FoodCalcApi;
using FoodCalcApi.DTOs;
using FoodCalcApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration["FoodCalcDb"];
builder.Services.AddSqlServer<FoodCalcDb>(connectionString);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo()
    {
        Title = "FoodCalc Api", Description = "Count and keep track of calories", Version = "v1"
    });
});
builder.Services.Configure<Microsoft.AspNetCore.Http.Json.JsonOptions>(options =>
{
    options.SerializerOptions.Converters.Add(new System.Text.Json.Serialization.JsonStringEnumConverter());
});
builder.Services.Configure<Microsoft.AspNetCore.Mvc.JsonOptions>(options =>
{
    options.JsonSerializerOptions.Converters.Add(new System.Text.Json.Serialization.JsonStringEnumConverter());
});

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI(sw =>
{
    sw.SwaggerEndpoint("/swagger/v1/swagger.json", "FoodCalc API V1");
});

app.MapGet("/", () => "Hello World!");
app.MapGet("/food", async (FoodCalcDb db) => await db.FoodPerGrams.ToListAsync());


app.MapGet("/brand", async (FoodCalcDb db) => await db.Brands.Select(x => new BrandDto(x)).ToArrayAsync());

app.MapPost("/food", async (FoodCalcDb db, FoodDto foodDto) =>
{
    var brand = await db.Brands.SingleOrDefaultAsync(x => x.Name == foodDto.BrandName);
    if (brand is null) return Results.NotFound();

    Food food;
    if (foodDto.FoodType == FoodType.Pc)
    {
        food = new FoodPerPiece(foodDto, brand);
        await db.FoodPerPieces.AddAsync((food as FoodPerPiece)!);
    }
    else
    {
        food = new FoodPerGram(foodDto, brand);
        await db.FoodPerGrams.AddAsync((food as FoodPerGram)!);
    }
    
    await db.SaveChangesAsync();
    return Results.Created($"/food/{food.Id}", food);
});

app.MapPost("/brand", async (FoodCalcDb db, Brand brand) =>
{
    await db.Brands.AddAsync(brand);
    await db.SaveChangesAsync();
    return Results.Created($"/brand/{brand.Id}", brand);
});

app.Run();