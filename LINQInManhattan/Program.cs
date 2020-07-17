using LINQInManhattan.Classes;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Cryptography;

namespace LINQInManhattan
{
    class Program
    {
        static void Main(string[] args)
        {
            // Relative path: needs to read the dll file within Obj/Debug
            ReadJSON("../../../data.json");

            Console.WriteLine("Welcome to LINQ in Manhattan. Press any key to continue.");
            Console.ReadLine();
            Console.Clear();

            OutputAllNeighborhoods();
            
            Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Thank you for using the program!");
        }

        static Root ReadJSON(string filePath)
        {
            Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(File.ReadAllText(filePath));

            return myDeserializedClass;
        }

        static void OutputAllNeighborhoods()
        {
            Root data = ReadJSON("../../../data.json");

            // Outputs all of the neighborhoods in this data list
            Console.WriteLine("These are all the neighborhoods in Manhattan:");

            var query = from Feature in data.features
                        select Feature.properties.neighborhood;
            
            int counter = 1;

            foreach (var item in query)
            {
                Console.WriteLine($"{counter++}. {item}");
            }

            Console.ReadLine();
            Console.Clear();

            // Filter out all the neighborhoods that do not have any names
            Console.WriteLine("These are all the neighborhoods in Manhattan minus the entries that were left empty:");

            var query2 = from Feature in data.features
                         where Feature.properties.neighborhood != String.Empty
                         select Feature.properties.neighborhood;

            int counter2 = 1;

            foreach (var item in query2)
            {
                Console.WriteLine($"{counter2++}. {item}");
            }

            Console.ReadLine();
            Console.Clear();

            // Remove the duplicates
            Console.WriteLine("These are all the unique neighborhood names:");

            var query3 = (from Feature in data.features
                          select Feature.properties.neighborhood).Distinct();

            int counter3 = 1;

            foreach (var item in query3)
            {
                Console.WriteLine($"{counter3++}. {item}");
            }

            Console.ReadLine();
            Console.Clear();

            // Rewrites the queries from above and consolodates all into one single query
            Console.WriteLine("Display of all of the queries at once:");

            var query4 = (from Feature in data.features
                          where Feature.properties.neighborhood != String.Empty
                          select Feature.properties.neighborhood).Distinct();

            int counter4 = 1;

            foreach (var item in query4)
            {
                Console.WriteLine($"{counter4++}. {item}");
            }

            Console.ReadLine();
            Console.Clear();

            // Rewrite at least one of these questions only using the opposing method
            // Using LINQ method call for "Output all the neighborhoods in this data list"
            Console.WriteLine("Using LINQ method call to display all the neighborhoods in Manhattan:");

            var query5 = data.features.Select(x => new { x.properties.neighborhood });

            int counter5 = 1;

            foreach (var item in query5)
            {
                Console.WriteLine($"{counter5++}. {item}");
            }

        }
    }
}
