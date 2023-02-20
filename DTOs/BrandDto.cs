namespace FoodCalcApi.DTOs;

public class BrandDto
{
    public string? Name { get; set; }
    public string? Description { get; set; }

    public BrandDto(){}

    public BrandDto(Brand brand) => (Name, Description) = (brand.Name, brand.Description);

}