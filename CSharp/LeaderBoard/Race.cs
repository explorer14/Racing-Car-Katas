using System.Collections.Generic;

namespace TDDMicroExercises.LeaderBoard
{
    //OBS: Is this a completed race or in progress race or something else?
    public class Race
    {
        // OBS: why are points hardcoded?
        private static readonly int[] Points = {25, 18, 15};
        // OBS: why need a dictionary to maintain a Drive -> driverName mapping when you already have a List<Driver>?
        private readonly Dictionary<Driver, string> _driverNames = new Dictionary<Driver, string>();
        private readonly string _name;

        public Race(string name, params Driver[] drivers)
        {
            _name = name;
            Results = new List<Driver>();
            Results.AddRange(drivers);

            foreach (var driver in Results)
            {
                var driverName = driver.Name;

                //OBS: this is breaking LSP. If you have to typecast to get derivative specific information
                // you've lost at polymorphism. Why can a self-driving car not use name and country instead?
                var drivingCar = driver as SelfDrivingCar;

                if (drivingCar != null)
                {
                    // OBS: this can be encapsulated within the SelfDrivingCar type otherwise it leaks driver knowledge
                    // into Race.
                    driverName = "Self Driving Car - " + drivingCar.Country + " (" +
                                 drivingCar.AlgorithmVersion + ")";
                }
                _driverNames.Add(driver, driverName);
            }
        }

        //OBS: Property name doesn't match what's being returned.
        public List<Driver> Results { get; }

        public Dictionary<Driver, string> DriverNames
        {
            get {  return _driverNames; }
        }

        public int Position(Driver driver)
        {
            return Results.FindIndex(d => Equals(d, driver));
        }

        //OBS: Points depend on the position of the driver in the Results collection.
        // This is the first time points are "awarded" completely hidden and implicitly
        public int GetPoints(Driver driver)
        {
            return Points[Position(driver)];
        }

        //OBS: why does Race expose an API to return driver name when the Driver object
        // already exposes the Name property?
        public string GetDriverName(Driver driver)
        {
            return DriverNames[driver];
        }

        public override string ToString()
        {
            return _name;
        }
    }
}