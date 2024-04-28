using Transportation.Cars.Abstractions.Models;

namespace Transportation.Cars.Models;

/// <summary>
/// Represents a car.
/// </summary>
public class Car : ICar
{
    public string Make { get; set; } = default!;
    
    public string Model { get; set; } = default!;
    
    public DateOnly ManufacturedDate { get; set; }
    
    public string YmmIdentifier =>
        $"{ManufacturedDate.Year}-{Make}-{Model}" + (string.IsNullOrEmpty(Trim) ? "" : $"-{Trim}");

    public string? Trim { get; set; }
}