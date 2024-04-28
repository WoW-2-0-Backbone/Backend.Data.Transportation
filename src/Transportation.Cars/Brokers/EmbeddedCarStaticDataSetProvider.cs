using System.Reflection;
using nietras.SeparatedValues;
using Transportation.Cars.Abstractions.Brokers;
using Transportation.Cars.Abstractions.Models;
using Transportation.Cars.Models;

namespace Transportation.Cars.Brokers;

/// <summary>
/// Provides car static data set from embedded resources.
/// </summary>
public class EmbeddedCarStaticDataSetProvider : ICarStaticDataSetProvider
{
    private readonly Assembly _assembly = Assembly.GetExecutingAssembly();

    public IEnumerable<ICar> GetData(CancellationToken cancellationToken = default)
    {
        // Read car data from each file
        foreach (var fileStream in GetResourceStreams())
        {
            if (cancellationToken.IsCancellationRequested)
                yield break;

            using var reader = Sep.Reader().From(fileStream);

            foreach (var row in reader)
            {
                if (cancellationToken.IsCancellationRequested)
                    yield break;

                var car = new Car
                {
                    ManufacturedDate = new DateOnly(row["year"].Parse<int>(), 1, 1),
                    Make = row["make"].ToString(),
                    Model = row["model"].ToString()
                };

                yield return car;
            }
        }
    }

    /// <summary>
    /// Gets the names of the embedded resource files.
    /// </summary>
    /// <returns></returns>
    public IEnumerable<string> GetFileNames()
    {
        return typeof(EmbeddedCarStaticDataSetProvider).Assembly.GetManifestResourceNames();
    }

    /// <summary>
    /// Gets the embedded resource as a stream.
    /// </summary>
    /// <returns>Collection of available embedded resource streams</returns>
    /// <exception cref="FileNotFoundException">If given file is not found</exception>
    public IEnumerable<Stream> GetResourceStreams()
    {
        foreach (var fileName in GetFileNames())
        {
            var fileStream = _assembly.GetManifestResourceStream(fileName);
            if (fileStream is null)
                throw new FileNotFoundException($"Could not find the embedded resource file - {fileName}");

            yield return fileStream;
        }
    }
}