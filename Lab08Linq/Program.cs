using System;
using System.IO;
using QuickType;
using System.Collections.Generic;
using System.Linq;

namespace Lab08Linq
{
    class Program
    {
        static void Main(string[] args)
        {
            //SET PATH
            string fileName = "data.json";
            string path = Path.Combine(Environment.CurrentDirectory, @"data\", fileName);
            string freddyVSjson;

            //READ IN JSON
            using (StreamReader sr = File.OpenText(path))
            {
                freddyVSjson = File.ReadAllText(path);
                Console.WriteLine(freddyVSjson);
                Console.ReadLine();
                Console.Clear();
            }

            //DESERIALIZE JSON
            var data = GettingStarted.FromJson(freddyVSjson);

            //PRINT UNFILTERED DATA
            Console.WriteLine("RAW NEIGHBORHOOD DATA");
            Console.WriteLine();
            IEnumerable<Feature> rawHoods = from o in data.Features
                                           where o.Properties.Neighborhood != null
                                           select o;
            foreach (var o in rawHoods)
            {
                Console.WriteLine(o.Properties.Neighborhood);
            }

            Console.WriteLine();
            Console.ReadLine();
            Console.Clear();

            //PRINT DATA SANS EMPTY STRINGS
            Console.WriteLine("NEIGHBORHOOD DATA WITHOUT NULLS");
            Console.WriteLine();

            var noNullHoods = rawHoods.Where(x => x.Properties.Neighborhood != "");
            foreach (var o in noNullHoods)
            {
                    Console.WriteLine(o.Properties.Neighborhood);
            }

            Console.WriteLine();
            Console.ReadLine();
            Console.Clear();

            //PRINT DATA SANS DUPLICATES
            Console.WriteLine("NEIGHBORHOOD DATA WITHOUT DUPLICATES");
            Console.WriteLine();
            var distinctHoods = noNullHoods.GroupBy(x => x.Properties.Neighborhood).Select(y => y.First());

            foreach (var o in distinctHoods)
            {

                Console.WriteLine(o.Properties.Neighborhood);

            }
            Console.WriteLine();
            Console.ReadLine();
            Console.Clear();

            //DO ALL OF THE ABOVE IN ONE LINE!!!!!!!!
            Console.WriteLine("MEGA QUERY!");
            Console.WriteLine();
            var megaQuery = data.Features.Where(x => x.Properties.Neighborhood != "").GroupBy(x => x.Properties.Neighborhood).Select(y => y.First());

            foreach (var o in distinctHoods)
            {

                Console.WriteLine(o.Properties.Neighborhood);

            }
            Console.WriteLine();
            Console.ReadLine();
            Console.Clear();

            Console.ReadLine();
        }
    }
}
