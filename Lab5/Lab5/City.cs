using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    public class City
    {
        public string Name { get; set; }
        public string Province { get; set; }
        public string Country { get; set; }
        public Geolocation Location { get; set; }

        public City(string name, string province, string country, Geolocation location)
        {
            Name = name;
            Province = province;
            Country = country;
            Location = location;
        }

        public City(decimal latitude, decimal longitude)
        {
            Location = new Geolocation(latitude, longitude);
        }

        public decimal Distance(City city, LengthTypes lengthType = LengthTypes.Miles)
        {
            if (city == null)
            {
                return 0;
            }
            else
            {
                return Location.GreatCircleDistance(city.Location, lengthType);
            }
        }

        public void Print()
        {
            Console.WriteLine($"{Name,-15} {Province,-10} {Country,-15} {Location.DMS()}");
        }

        public static void PrintHeader()
        {
            Console.WriteLine("{0,-15} {1,-10} {2,-15} {3}","City","Province","Country","Coordinates");
            string seperator = new string('=', 75);
            Console.WriteLine(seperator);
        }
    }
}
