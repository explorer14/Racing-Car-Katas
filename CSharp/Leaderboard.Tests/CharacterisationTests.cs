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
                new Driver(Name: "b",
                    Country: "DE"),
                new Driver(Name: "a",
                    Country: "NL")),
            new Race(name: "GP2023",
                new Driver(Name: "b",
                    Country: "DE"),
                new Driver(Name: "c",
                    Country: "DE"),
                new Driver(Name: "d",
                    Country: "FR")));

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
            },
            third => 
            {
                third.Key.Should().Be("c");
                third.Value.Should().Be(18);
            },
            fourth => 
            {
                fourth.Key.Should().Be("d");
                fourth.Value.Should().Be(15);
            });
    }
}