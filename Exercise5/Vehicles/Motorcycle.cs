using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise5
{
    class Motorcycle : Vehicle
    {
        public Enum.MotorcycleMake Make { get; set; }
        public Motorcycle(string regNo, string color, int nrOfWheels, Enum.FuelType fuelType, Enum.MotorcycleMake make)
            : base(regNo, color, nrOfWheels, fuelType)
        {
            Make = make;
        }

    }
}
