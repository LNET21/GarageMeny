using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise5
{
    public abstract class Vehicle
    {
        public string RegNo { get; set; }
        public string Color { get; set; }
        public int NrOfWheels { get; set; }
        public string FuelType { get; set; }
        public Vehicle()
        {

        }
        public Vehicle(string regNo, string color, int nrOfWheels, string fuelType)
        {
            RegNo = regNo.ToUpper(); // Registration number always in uppercase
            Color = color;
            NrOfWheels = nrOfWheels;
            FuelType = fuelType;
        }

        /// <summary>
        /// Gets a description of the property specific for the vehicle type
        /// </summary>
        /// <returns></returns>
        public abstract string GetDescription();
    }
}
