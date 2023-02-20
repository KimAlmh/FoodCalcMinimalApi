using FoodCalcApi.DTOs;

namespace FoodCalcApi;

public class FoodPerPiece : Food
{
    public double Weight { get; set; }
    
    public FoodPerPiece()
    {
        
    }

    public FoodPerPiece(FoodDto dto, Brand brand)
    {
        var multiplier = dto.Weight / 100;
        Name = dto.Name;
        Brand = brand;
        Weight = dto.Weight;
        Kcal = dto.Kcal * multiplier;
        Kj = dto.Kj * multiplier;
        Protein = dto.Protein * multiplier;
        Fat = dto.Fat * multiplier;
        Carbohydrate = dto.Carbohydrate * multiplier;
        SaturatedFat = dto.SaturatedFat * multiplier;
        Sugar = dto.Sugar * multiplier;
        Salt = dto.Salt * multiplier;
        Fibre = dto.Fibre * multiplier;
    }
}