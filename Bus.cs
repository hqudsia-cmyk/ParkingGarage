using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingGarage
{
    class Bus : Vehicle
    {
        public int Passengers { get; set; }

        public Bus(string regNo, string color, int passengers)
            : base(regNo, color, 2.0) // Bus takes 2 parking spaces
        {
            Passengers = passengers;
        }

        public new string GetInfo()
        {
            return "Bus " + RegNo + " " + Color + " " + Passengers + " passengers";
        }
    }
}
