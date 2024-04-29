using BenchmarkDotNet.Attributes;
using Transportation.Cars.Brokers;

namespace Transportation.Cars.PerformanceTests;

public class EmbeddedCarStaticDataSetProviderTests
{
    [Benchmark]
    public void TestLoadingEmbeddedData()
    {
        // Call the function you want to test
        var sut = new EmbeddedCarStaticDataSetProvider();
        var cars = sut.GetData().ToList();
    }
}