using Microsoft.VisualBasic;
using System;
using System.ComponentModel;
using System.Text.RegularExpressions;

namespace ParkingGarage
{
    internal class Program
    {
        static void Main(string[]args)
        {
            ParkingGarage garage = new ParkingGarage();
            bool running = true;

            while (running)
            {
                Console.WriteLine("\n--- Parking Garage Menu ---");
                Console.WriteLine("1. Park vehicle");
                Console.WriteLine("2. Show vehicles");
                Console.WriteLine("3. Check out vehicle");
                Console.WriteLine("4. Exit");
                Console.Write("Choose: ");
                string choice = Console.ReadLine();

                if (choice == "1")
                    garage.ParkVehicle();
                
                else if (choice == "2")
                    garage.ShowVehicles();

                else if (choice == "3")
                    garage.CheckOutVehicle();

                else if (choice == "4")
                    running = false;

                else
                    Console.WriteLine("Invalid choice!");
                
            }
        }
    }
}
