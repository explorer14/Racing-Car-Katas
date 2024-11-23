using FluentAssertions;
using Xunit;
using Xunit.Abstractions;
using Xunit.Sdk;

namespace TDDMicroExercises.LeaderBoard.Tests;

public class CharacterisationTests(ITestOutputHelper testOutputHelper)
{
    [Fact]
    public void GivenOneRaceAndTwoDriversReturnResults()
    {
        var leaderBoardWithOneRaceAndOneDriver = new Leaderboard(
            new Race(name: "GP2024",
                new Driver(name: "b",
                    country: "DE"),
                new Driver(name: "a",
                    country: "NL")),
            new Race(name: "GP2023",
                new Driver(name: "b",
                    country: "DE")));

        var driverResults = leaderBoardWithOneRaceAndOneDriver.DriverResults();

        // foreach(var kvp in driverResults)
        // {
        //     testOutputHelper.WriteLine($"{kvp.Key}:{kvp.Value}");
        // }

        driverResults.Should().SatisfyRespectively(
            first => 
            {
                first.Key.Should().Be("b");
                first.Value.Should().Be(50);
            },
            second => 
            {
                second.Key.Should().Be("a");
                second.Value.Should().Be(18);
            });
    }
}