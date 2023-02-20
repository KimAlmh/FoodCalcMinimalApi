using FoodCalcApi.Models;
using Microsoft.EntityFrameworkCore;

namespace FoodCalcApi;

public class FoodCalcDb : DbContext
{
    public FoodCalcDb(DbContextOptions options) : base(options){}
    public DbSet<FoodPerGram> FoodPerGrams { get; set; } = null!;
    public DbSet<FoodPerPiece> FoodPerPieces { get; set; } = null!;
    public DbSet<Brand> Brands { get; set; } = null!;
}