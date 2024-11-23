namespace TDDMicroExercises.LeaderBoard
{
    public record SelfDrivingCar(string algorithmVersion, string Company) : 
        Driver(algorithmVersion, Company)
    {
        public string AlgorithmVersion {get; set;} = algorithmVersion;
    }
}