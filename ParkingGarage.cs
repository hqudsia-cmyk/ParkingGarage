using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingGarage
{
    internal class ParkingGarage//Handles logic
    {
        public int TotalSpaces { get; } = 15; // total parking spaces
        private List<Vehicle> vehicles = new List<Vehicle>();
        private Random random = new Random();

        // Property to check used spaces
        private double UsedSpaces
        {
            get { return vehicles.Sum(v => v.Size); }
        }

        // Method to create a random registration number
        private string GenerateRegNo()
        {
            string letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string numbers = "0123456789";
            string reg = "";
            for (int i = 0; i < 3; i++) reg += letters[random.Next(letters.Length)];
            for (int i = 0; i < 3; i++) reg += numbers[random.Next(numbers.Length)];
            return reg;
        }

        
        // PARK A VEHICLE
        
        public void ParkVehicle()
        {
            Console.WriteLine("\nEnter vehicle type (car/mc/bus): ");
            string type = Console.ReadLine().ToLower();

            if (UsedSpaces >= TotalSpaces)
            {
                Console.WriteLine("Garage is full!");
                return;
            }

            string regNo = GenerateRegNo();
            Console.Write("Enter color: ");
            string color = Console.ReadLine();

            Vehicle v = null;

            if (type == "car")
            {
                Console.Write("Is it electric? (y/n): ");
                bool electric = Console.ReadLine().ToLower() == "y";
                v = new Car(regNo, color, electric);
            }
            else if (type == "mc")
            {
                Console.Write("Enter brand: ");
                string brand = Console.ReadLine();
                v = new Motorcycle(regNo, color, brand);
            }
            else if (type == "bus")
            {
                Console.Write("Enter number of passengers: ");
                int passengers = int.Parse(Console.ReadLine());
                v = new Bus(regNo, color, passengers);
            }
            else
            {
                Console.WriteLine("Invalid type!");
                return;
            }

            if (UsedSpaces + v.Size > TotalSpaces)
            {
                Console.WriteLine("Not enough space for this vehicle!");
                return;
            }

            vehicles.Add(v);
            Console.WriteLine($"Vehicle parked successfully! RegNo: {v.RegNo}");
        }

        // SHOW ALL VEHICLES
        
        public void ShowVehicles()
        {
            if (vehicles.Count == 0)
            {
                Console.WriteLine("Garage is empty!");
                return;
            }

            Console.WriteLine("\n--- Vehicles in Garage ---");
            double location = 1;

            foreach (var v in vehicles)
            {
                if (v is Bus)
                {
                    Bus b = (Bus)v;
                    Console.WriteLine($"Location {location}-{location + 1}: {b.GetInfo()}");
                    location += 2;
                }
                else if (v is Motorcycle)
                {
                    Motorcycle m = (Motorcycle)v;
                    Console.WriteLine($"Location {location}: {m.GetInfo()}");
                    location += 0.5;
                }
                else if (v is Car)
                {
                    Car c = (Car)v;
                    Console.WriteLine($"Location {location}: {c.GetInfo()}");
                    location += 1;
                }
            }

            Console.WriteLine($"\nUsed spaces: {UsedSpaces}/{TotalSpaces}");
        }

        
        // CHECK OUT VEHICLE
      
        public void CheckOutVehicle()
        {
            Console.Write("Enter registration number to check out: ");
            string regNo = Console.ReadLine().ToUpper();

            Vehicle v = vehicles.FirstOrDefault(x => x.RegNo == regNo);
            if (v == null)
            {
                Console.WriteLine("Vehicle not found!");
                return;
            }

            double minutes = (DateTime.Now - v.ParkedTime).TotalMinutes;
            double price = minutes * 1.5;

            Console.WriteLine($"{v.GetInfo()} parked for {minutes:F1} minutes. Price: {price:F2} SEK.");

            vehicles.Remove(v);
            Console.WriteLine("Vehicle checked out.\n");
        }
    }
}
