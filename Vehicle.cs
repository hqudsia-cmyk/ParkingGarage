using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingGarage
{
    internal class Vehicle

    {
        public string RegNo { get; set; }
        public string Color { get; set; }
        public double Size { get; set; }
        public DateTime ParkedTime { get; set; }

        public Vehicle(string regNo, string color, double size)
        {
            RegNo = regNo;
            Color = color;
            Size = size;
            ParkedTime = DateTime.Now;
        }

        public  string GetInfo()
        {
            return $"{RegNo} {Color}{Size}";
        }
    }

}
