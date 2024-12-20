using System;
using System.Collections.Generic;

namespace TDDMicroExercises.LeaderBoard
{
    //OBS: Is this a completed race or in progress race or something else?
    public class Race
    {
        private readonly string _name;
        private readonly Driver[] _drivers;

        public Race(string name, params Driver[] drivers)
        {
            _name = name;
            _drivers = drivers;
        }

        public IReadOnlyCollection<Driver> Drivers => _drivers;


        //OBS: Points depend on the position of the driver in the Results collection.
        // This is the first time points are "awarded" completely hidden and implicitly
        public int GetPoints(Driver driver) => 
            Array.IndexOf(_drivers, driver) switch
            {
                0 => 25,
                1 => 18,
                2 => 15,
                _ => 0,
            };
    }
}