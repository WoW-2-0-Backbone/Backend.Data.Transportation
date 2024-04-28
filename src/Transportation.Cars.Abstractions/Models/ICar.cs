using Transportation.Abstractions.Models;

namespace Transportation.Cars.Abstractions.Models;

/// <summary>
/// Defines a car properties.
/// </summary>
public interface ICar : IVehicle
{
    /// <summary>
    /// Gets the car's year make model identifier.
    /// </summary>
    public string YmmIdentifier =>
        $"{ManufacturedDate.Year}-{Make}-{Model}" + (string.IsNullOrEmpty(Trim) ? "" : $"-{Trim}");

    /// <summary>
    /// Gets or sets identifier of different features, style, equipment of the car
    /// </summary>
    public string? Trim { get; set; }
}