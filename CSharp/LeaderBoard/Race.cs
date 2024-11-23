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
            Drivers = new List<Driver>();
            Drivers.AddRange(drivers);

            foreach (var driver in Drivers)
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

        public List<Driver> Drivers { get; }

        public int Position(Driver driver)
        {
            return Drivers.FindIndex(d => Equals(d, driver));
        }

        //OBS: Points depend on the position of the driver in the Results collection.
        // This is the first time points are "awarded" completely hidden and implicitly
        public int GetPoints(Driver driver)
        {
            return Points[Position(driver)];
        }
    }
}