using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise5
{
    class Boat : Vehicle
    {
        public int Length { get; set; }

        public Boat(string regNo, string color, int nrOfWheels, Enum.FuelType fuelType, int length)
            : base(regNo, color, nrOfWheels, fuelType)
        {
            Length = length;
        }
    }
}
