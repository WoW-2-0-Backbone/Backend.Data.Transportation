namespace Transportation.Abstractions.Brokers;

/// <summary>
/// Defines static data set provider contract
/// </summary>
/// <typeparam name="TData">Type of data provided</typeparam>
public interface IStaticDataSetProvider<out TData>
{
    /// <summary>
    /// Gets enumerable source of static data set
    /// </summary>
    /// <param name="cancellationToken">A cancellation token to cancel the operation.</param>
    /// <exception cref="ArgumentException">If cancellation token can't be cancelled. See <see href="https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken.none?view=net-8.0">CancellationToken.None</see> for more details.</exception>
    /// <returns>Enumerable source of data</returns>
    IEnumerable<TData> GetData(CancellationToken cancellationToken = default);
}