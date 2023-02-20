using Newtonsoft.Json.Converters;
using Newtonsoft.Json;

namespace FoodCalcApi.DTOs;

public class FoodDto
{
    public string? Name { get; set; }
    public string? BrandName { get; set; }
    public double Kcal { get; set; }
    public double Kj { get; set; }
    public double Carbohydrate { get; set; }
    public double Fat { get; set; }
    public double Protein { get; set; }
    public double Sugar { get; set; }
    public double Fibre { get; set; }
    public double SaturatedFat { get; set; }
    public double Salt { get; set; }
    public double Weight { get; set; }
    
    // [JsonConverter(typeof(StringEnumConverter))]
    public FoodType? FoodType { get; set; }
}