using FoodCalcApi.DTOs;

namespace FoodCalcApi.Models;

public class FoodPerGram : Food
{
    public FoodPerGram()
    {
        
    }

    public FoodPerGram(FoodDto dto, Brand brand)
    {
        var amount = (dto.FoodType == FoodType.G100) ? 100 : 1;
        Name = dto.Name;
        Brand = brand;
        Kcal = dto.Kcal / amount;
        Kj = dto.Kj / amount;
        Protein = dto.Protein / amount;
        Fat = dto.Fat / amount;
        Carbohydrate = dto.Carbohydrate / amount;
        SaturatedFat = dto.SaturatedFat / amount;
        Sugar = dto.Sugar / amount;
        Salt = dto.Salt / amount;
        Fibre = dto.Fibre / amount;
    }
}