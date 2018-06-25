using LINQManhatten.Classes;
using System;
using System.Linq;
using Newtonsoft.Json;
using System.IO;

namespace LINQManhatten
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello");
            ReadFiles();

            Console.ReadKey();
        }
        /// <summary>
        /// created to read the json file
        /// </summary>
        public static void ReadFiles()
        {
            // C:\Users\rhiannon\Source\Repos\LINQManhatten\LINQManhatten\LINQManhatten\Program.cs
            // C:\Users\rhiannon\Source\Repos\LINQManhatten\LINQManhatten\LINQManhatten\data.json
            string path = "./data.json";
            try
            {
                StreamReader r = new StreamReader(path);
                string json = r.ReadToEnd();
                FeaturesCollections items = JsonConvert.DeserializeObject<FeaturesCollections>(json);
                GetLINQed(items);
            }
            catch (Exception e)
            {
                Console.WriteLine($@"uh oh, what happened?
                                    {e.Message}");
            }
        }
        /// <summary>
        /// this handles all queries
        /// </summary>
        /// <param name="obj"></param>
        public static void GetLINQed(FeaturesCollections obj)
        {
            // we are making sure that Neighborhood doesnt = null
            var neighborhoods = from i in obj.Features
                        where i.Properties.Neighborhood != null
                        select i;
            // cycling through the not null neighborhoods
            foreach (var neighborhood in neighborhoods)
            {
                Console.WriteLine(neighborhood.Properties.Neighborhood);
            }
            Console.WriteLine("Up next, all the neighborhoods that have a name. Press any key to contin...");
            Console.ReadKey();
            // 
            var noNeighborhood = from j in neighborhoods
                           where j.Properties.Neighborhood !=""
                           select j.Properties.Neighborhood;
            // 
            foreach (var noN in noNeighborhood)
            {
                Console.WriteLine(noN);
            }
            // 
            Console.WriteLine("Now, all the unique neighborhoods. Press any key to contin...");
            Console.ReadKey();
            var uniqueN = noNeighborhood.Distinct();
            foreach (var uN in uniqueN)
            {
                Console.WriteLine(uN);
            }
            Console.WriteLine("Lastly, we gonna make all the above into one! Press any key to contin...");
            Console.ReadKey();
            var allNeighborhoods = obj.Features.Where(k => k.Properties.Neighborhood != "")
                                                .GroupBy(l => l.Properties.Neighborhood)
                                                .Select(m => m.Key);
            foreach (var h in allNeighborhoods) {Console.WriteLine(h);}
            Console.ReadKey();
        }
    }
}
