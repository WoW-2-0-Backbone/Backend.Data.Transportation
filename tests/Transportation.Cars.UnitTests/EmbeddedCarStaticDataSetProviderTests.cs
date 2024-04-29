using System.Diagnostics;
using Transportation.Cars.Brokers;

namespace Transportation.Cars.UnitTests;

public class EmbeddedCarStaticDataSetProviderTests
{
    #region Finding files

    [Fact]
    public void GetFileNames_Should_ReturnNonEmptyEnumerable_WhenCalled()
    {
        // Arrange
        var sut = new EmbeddedCarStaticDataSetProvider();

        // Act
        var act = () => sut.GetFileNames().ToList();

        // Assert
        var exception = Record.Exception(act);
        Assert.Null(exception);
        Assert.NotEmpty(act());
    }

    [Theory]
    [InlineData(1)]
    public void GetFileNames_Should_ReturnAllData_InReasonableAmountOfTime(int expectedExecutionDurationInSeconds)
    {
        // Arrange
        var sut = new EmbeddedCarStaticDataSetProvider();
        var stopwatch = Stopwatch.StartNew();

        // Act
        var act = () => sut.GetFileNames().ToList();

        // Assert
        var exception = Record.Exception(act);
        Assert.Null(exception);
        var cars = act();
        Assert.NotEmpty(cars);

        stopwatch.Stop();
        Assert.True(stopwatch.Elapsed.TotalSeconds < expectedExecutionDurationInSeconds,
            $"Method takes longer than {expectedExecutionDurationInSeconds} seconds to complete");
    }

    #endregion

    #region Opening file stream

    [Fact]
    public void GetResourceStreams_Should_NotThrowException_WhenCalled()
    {
        // Arrange
        var sut = new EmbeddedCarStaticDataSetProvider();

        // Act
        var act = () => sut.GetResourceStreams().ToList();

        // Assert
        var exception = Record.Exception(act);
        Assert.Null(exception);
        Assert.NotEmpty(act());
    }

    #endregion

    #region Reading data

    [Fact]
    public void GetData_Should_ReturnNonEmptyEnumerable_WhenCalled()
    {
        // Arrange
        var sut = new EmbeddedCarStaticDataSetProvider();

        // Act
        var act = () => sut.GetData().ToList();

        // Assert
        var exception = Record.Exception(act);
        Assert.Null(exception);
        Assert.NotEmpty(act());
    }

    [Theory]
    [InlineData(5)]
    public void GetData_Should_ReturnAllData_InReasonableAmountOfTime(int expectedExecutionDurationInSeconds)
    {
        // Arrange
        var sut = new EmbeddedCarStaticDataSetProvider();
        var stopwatch = Stopwatch.StartNew();

        // Act
        var act = () => sut.GetData().ToList();

        // Assert
        var exception = Record.Exception(act);
        Assert.Null(exception);
        var cars = act();
        Assert.NotEmpty(cars);

        stopwatch.Stop();
        Assert.True(stopwatch.Elapsed.TotalSeconds < expectedExecutionDurationInSeconds,
            $"Method takes longer than {expectedExecutionDurationInSeconds} seconds to complete");
    }

    [Fact]
    public void GetData_Should_HaveConsistentData_WhenResultReturned()
    {
        // Arrange
        var sut = new EmbeddedCarStaticDataSetProvider();

        // Act
        var act = () => sut.GetData().ToList();

        // Assert
        var exception = Record.Exception(act);
        Assert.Null(exception);

        var cars = act();
        Assert.NotEmpty(cars);
        Assert.True(cars.TrueForAll(car =>
            !string.IsNullOrWhiteSpace(car.Make)
            && !string.IsNullOrWhiteSpace(car.Model)
            && car.ManufacturedDate != default));
    }

    #endregion
}