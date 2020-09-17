using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise5
{
    public class Bus : Vehicle
    {
        public int NrOfSeats { get; }
        public Bus(string regNo, string color, int nrOfWheels, Enum.FuelType fuelType, int nrOfSeats)
            : base(regNo, color, nrOfWheels, fuelType)
        {
            NrOfSeats = nrOfSeats;
        }
    }
}
