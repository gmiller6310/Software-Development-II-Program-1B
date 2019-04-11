//Grading ID: C6485
// Program #: 1B
// Due Date: October 4, 2017 11:59 P.M.
// Course Number: CIS200-01
// Brief Decsription: Uses LINQ to display existing Parcel hierarchy created objects based on
// different criteria

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program1B
{
    class Program
    {
        // Precondition:  None
        // Postcondition: Parcels have been created and displayed
        static void Main(string[] args)
        {
            // Test Addresses
            Address a1 = new Address("  John Smith  ", "   123 Any St.   ", "  Apt. 45 ",
                "  Louisville   ", "  KY   ", 40202); // Test Address 1
            Address a2 = new Address("Jane Doe", "987 Main St.",
                "Beverly Hills", "CA", 90210); // Test Address 2
            Address a3 = new Address("James Kirk", "654 Roddenberry Way", "Suite 321",
                "El Paso", "TX", 79901); // Test Address 3
            Address a4 = new Address("John Crichton", "678 Pau Place", "Apt. 7",
                "Portland", "ME", 04101); // Test Address 4
            Address a5 = new Address("Billy Walsh", "123 Hollywood Lane",
                "Pasadena", "CA", 10100); // Test Address 5
            Address a6 = new Address("Vincent Chase", "456 Rich Road",
                "Los Angeles", "CA", 75432); // Test Address 6
            Address a7 = new Address("Eric Murphy", "111 Short Street",
                "Benton", "KY", 42025); // Test Address 7
            Address a8 = new Address("Ari Gold", "414 Fairview Street", "Apt. 12",
                "Paducah", "KY", 83325); // Test Address 8

            // Letter test objects
            Letter letter1 = new Letter(a1, a2, 3.95M);
            Letter letter2 = new Letter(a8, a5, 4M);
            Letter letter3 = new Letter(a6, a3, 3.94M);
            Letter letter4 = new Letter(a7, a4, 3.91M);

            // Ground Package test objects
            GroundPackage gp1 = new GroundPackage(a3, a4, 14, 10, 5, 12.5);
            GroundPackage gp2 = new GroundPackage(a2, a1, 20, 7, 4, 20);
            GroundPackage gp3 = new GroundPackage(a5, a8, 20, 10, 8, 9);
            GroundPackage gp4 = new GroundPackage(a6, a7, 11, 2, 3, 15);

            // Next Day Air Package test objects
            NextDayAirPackage ndap1 = new NextDayAirPackage(a1, a3, 25, 15, 15,
                85, 7.50M);
            NextDayAirPackage ndap2 = new NextDayAirPackage(a7, a2, 11, 22, 9, 
                70, 7.38M);
            NextDayAirPackage ndap3 = new NextDayAirPackage(a8, a4, 6, 4, 10,
                40, 7.40M);
            NextDayAirPackage ndap4 = new NextDayAirPackage(a6, a5, 15, 20, 15,
                90, 7.55M);

            // Two Day Air Package test objects
            TwoDayAirPackage tdap1 = new TwoDayAirPackage(a4, a1, 46.5, 39.5, 28.0,
                80.5, TwoDayAirPackage.Delivery.Saver);
            TwoDayAirPackage tdap2 = new TwoDayAirPackage(a2, a8, 55, 23, 20,
                90, TwoDayAirPackage.Delivery.Early);
            TwoDayAirPackage tdap3 = new TwoDayAirPackage(a5, a7, 50, 27, 19,
                69, TwoDayAirPackage.Delivery.Saver);
            TwoDayAirPackage tdap4 = new TwoDayAirPackage(a6, a3, 70, 68, 30,
                100, TwoDayAirPackage.Delivery.Early);


            List<Parcel> parcels = new List<Parcel>(); // Test list of parcels

            // Adds created objects to list
            parcels.Add(letter1);
            parcels.Add(letter2);
            parcels.Add(letter3);
            parcels.Add(letter4);
            parcels.Add(gp1);
            parcels.Add(gp2);
            parcels.Add(gp3);
            parcels.Add(gp4);
            parcels.Add(ndap1);
            parcels.Add(ndap2);
            parcels.Add(ndap3);
            parcels.Add(ndap4);
            parcels.Add(tdap1);
            parcels.Add(tdap2);
            parcels.Add(tdap3);
            parcels.Add(tdap4);
           
            // Linq
            var parcelsByDestinationZip =
               from parc in parcels
               orderby parc.DestinationAddress.Zip descending
               select parc; // Gives list sorted by destination address zip code in descending order

            Console.WriteLine("Parcels by Destination Zip Descending\n"); // Header for data

            foreach (var i in parcelsByDestinationZip)
                Console.WriteLine(i); // Loop that displays the list made above

            var parcelsByCost =
                from parc in parcels
                orderby parc.CalcCost()
                select parc; // Gives list sorted by price in ascending order

            Console.WriteLine("Parcels by Cost Ascending\n"); // Header for data

            foreach (var i in parcelsByCost)
                Console.WriteLine(i); // Loop that disaplys list made above

            var parcelByTypeAndThenCost =
                from parc in parcels
                orderby parc.GetType().ToString(), parc.CalcCost() descending 
                select parc; // Gives list sorted by Object Type name, and then cost in descending order

            Console.WriteLine("Parcels by Type Ascending and then by Cost Descending\n"); // Header for Data

            foreach (var i in parcelByTypeAndThenCost)
                Console.WriteLine(i); // Loop that displays the list made above

            var parcelByIsHeavyAndWeight =
                from parc in parcels
                where parc is AirPackage // Determines that parc is an AirPackage
                where ((AirPackage)parc).IsHeavy() // Use of downcasting to make sure packages are heavy
                orderby ((AirPackage)parc).Weight descending // Orders packages by weight in descending order
                select ((AirPackage)parc); // Gives list of Air Packages determined heavy 
                                           // sorted by weight in descending order

            Console.WriteLine("Heavy Air Packages by Weight\n"); // Header for data

            foreach (var i in parcelByIsHeavyAndWeight)
                Console.WriteLine(i); // Loop that displays the list made above

        }
    }
}
