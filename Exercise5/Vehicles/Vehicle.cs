using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise5
{
    public abstract class Vehicle
    {
        public string RegNo { get; }
        public string Color { get; }
        public int NrOfWheels { get; }
        public Enum.FuelType FuelType { get; }
        public bool HasBeenScratched { get; }

        public Vehicle()
        {
        }
        public Vehicle(string regNo, string color, int nrOfWheels, Enum.FuelType fuelType)
        {
            RegNo = regNo.ToUpper(); // Registration number is always uppercase
            Color = color;
            NrOfWheels = nrOfWheels;
            FuelType = fuelType;
        }
    }
}
