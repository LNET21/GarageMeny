using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise5
{
    public class Car : Vehicle
    {
        public Enum.CarMake Make { get; }

        public Car(string regNo, string color, int nrOfWheels, Enum.FuelType fuelType, Enum.CarMake make) 
            : base(regNo, color, nrOfWheels, fuelType)
        {
            Make = make;
        }
    }
}
