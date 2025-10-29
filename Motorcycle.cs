using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingGarage
{
    class Motorcycle : Vehicle
    {
        public string Brand { get; set; }

        public Motorcycle(string regNo, string color, string brand)
            : base(regNo, color, 0.5) // Motorcycle takes half space
        {
            Brand = brand;
        }

        public new string GetInfo()
        {
            return "Motorcycle " + RegNo + " " + Color + " " + Brand;
        }
    }
}
