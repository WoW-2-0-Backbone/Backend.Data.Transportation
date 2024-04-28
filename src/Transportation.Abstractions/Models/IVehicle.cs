namespace Transportation.Abstractions.Models;

/// <summary>
/// Defines a vehicle properties.
/// </summary>
public interface IVehicle
{
    /// <summary>
    /// Gets or sets the make of the vehicle.
    /// </summary>
    public string Make { get; set; }

    /// <summary>
    /// Gets or sets the model of the vehicle.
    /// </summary>
    public string Model { get; set; }

    /// <summary>
    /// Gets or sets the year the vehicle was manufactured.
    /// </summary>
    public DateOnly ManufacturedDate { get; set; }
}