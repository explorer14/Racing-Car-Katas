using Xunit;
using Xunit.Abstractions;
using Xunit.Sdk;

namespace TDDMicroExercises.LeaderBoard.Tests;

public class CharacterisationTests(ITestOutputHelper testOutputHelper)
{
    [Fact]
    public void GivenOneRaceAndTwoDriversReturnRankings()
    {
        var leaderBoardWithOneRaceAndOneDriver = new Leaderboard(
            new Race(name: "GP2024",
                new Driver(name: "aman2",
                    country: "DE"),
                new Driver(name: "aman",
                    country: "NL")));

        // OBS: Rankings are drivers sorted by their name alphabetically ascending
        // One on top is rank 1st, one on the bottom is rank last.
        var rankings = leaderBoardWithOneRaceAndOneDriver.DriverRankings();
        foreach (var ranking in rankings)
        {
            testOutputHelper.WriteLine(ranking);    
        }
    }
    
    [Fact]
    public void GivenOneRaceAndTwoDriversReturnResults()
    {
        var leaderBoardWithOneRaceAndOneDriver = new Leaderboard(
            new Race(name: "GP2024",
                new Driver(name: "aman2",
                    country: "DE"),
                new Driver(name: "aman",
                    country: "NL")));

        var driverResults = leaderBoardWithOneRaceAndOneDriver.DriverResults();
        foreach (var result in driverResults)
        {
            testOutputHelper.WriteLine($"{result.Key}: {result.Value}");    
        }
    }
    
    [Fact]
    public void GivenMultipleRacesAndTwoDriversReturnResults()
    {
        var leaderBoardWithOneRaceAndOneDriver = new Leaderboard(
            new Race(name: "GP2023",
                new Driver(name: "john wick",
                    country: "DE"),
                new Driver(name: "aman",
                    country: "NL")),
            new Race(name: "GP2024",
                new Driver(name: "john wick",
                    country: "DE"),
                new Driver(name: "aman",
                    country: "NL")));

        var driverResults = leaderBoardWithOneRaceAndOneDriver.DriverResults();
        foreach (var result in driverResults)
        {
            testOutputHelper.WriteLine($"{result.Key}: {result.Value}");    
        }
    }
}