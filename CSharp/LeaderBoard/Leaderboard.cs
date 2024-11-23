using System.Collections.Generic;

namespace TDDMicroExercises.LeaderBoard
{
    public class Leaderboard
    {
        private readonly List<Race> _races = new();

        public Leaderboard(params Race[] races) => 
            _races.AddRange(races);

        public Dictionary<string, int> DriverResults()
        {
            var results = new Dictionary<string, int>();
            foreach (var race in _races)
            {
                foreach (var driver in race.Results)
                {
                    var points = race.GetPoints(driver);
                    if (results.ContainsKey(driver.Name))
                    {
                        results[driver.Name] += points;
                    }
                    else
                    {
                        results.Add(driver.Name, points);
                    }
                }
            }
            return results;
        }

        public List<string> DriverRankings()
        {
            var results = DriverResults();
            var resultsList = new List<string>(results.Keys);
            resultsList.Sort();
            return resultsList;
        }
    }
}