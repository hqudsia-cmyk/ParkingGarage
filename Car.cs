using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingGarage
{
    class Car : Vehicle
    {
        public bool IsElectric { get; set; }

        public Car(string regNo, string color, bool isElectric)
            : base(regNo, color, 1.0) // Car takes 1 parking space
        {
            IsElectric = isElectric;
        }

        // This just makes a nice text for showing car info
        public new string GetInfo()
        {
            string type = IsElectric ? "Electric Car" : "Car";
            return type + " " + RegNo + " " + Color;
        }
    }

}
