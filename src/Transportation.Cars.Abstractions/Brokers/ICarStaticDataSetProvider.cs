using Transportation.Abstractions.Brokers;
using Transportation.Cars.Abstractions.Models;

namespace Transportation.Cars.Abstractions.Brokers;

/// <summary>
/// Defines car static data set provider.
/// </summary>
public interface ICarStaticDataSetProvider : IStaticDataSetProvider<ICar>;