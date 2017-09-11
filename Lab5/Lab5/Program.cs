using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    class Program
    {
        static List<City> cities = new List<City>();
        static void Main(string[] args)
        {
            bool quit = false;

            MenuChoices choice = MenuChoices.CityDistances;

            while (quit != true)
            {
                Console.WriteLine("Please choose from the following menu items:");
                int count = 0;
                foreach (string name in Enum.GetNames(typeof(MenuChoices)))
                {
                    Console.WriteLine($"[{count}] {name}");
                    count++;
                }

                Console.Write("Your choice: ");

                Enum.TryParse(Console.ReadLine(), out choice);

                switch (choice)
                {
                    case MenuChoices.DisplayCities:
                        DisplayCities();
                        break;
                    case MenuChoices.AddCity:
                        AddCity();
                        break;
                    case MenuChoices.RemoveCity:
                        RemoveCity();
                        break;
                    case MenuChoices.CityDistances:
                        CityDistances();
                        break;
                    case MenuChoices.Quit:
                        quit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid input");
                        break;
                }
            }
        }

        static Program()
        {
            Geolocation sanDiego = new Geolocation(32.71513M, -117.1611M);
            Geolocation sanFrancisco = new Geolocation(37.78352M, -122.4169M);
            Geolocation losAngeles = new Geolocation(34.04983M, -118.2498M);
            Geolocation newYork = new Geolocation(40.71015M, -74.00658M);
            Geolocation london = new Geolocation(51.51786M, -0.102216M);
            Geolocation sydney = new Geolocation(-33.86767M, 151.2094M);

            City sanDiego2 = new City("San Diego", "CA", "USA", sanDiego);
            City sanFrancisco2 = new City("San Francisco", "CA", "USA", sanFrancisco);
            City losAngeles2 = new City("Los Angeles", "CA", "USA", losAngeles);
            City newYork2 = new City("New York", "NY", "USA", newYork);
            City london2 = new City("London", "London", "England", london);
            City sydney2 = new City("Sydney", "NSW", "Australia", sydney);


            cities.Add(sanDiego2);
            cities.Add(sanFrancisco2);
            cities.Add(losAngeles2);
            cities.Add(newYork2);
            cities.Add(london2);
            cities.Add(sydney2);
        }

        static void DisplayCities()
        {
            City.PrintHeader();
            foreach (var city in cities)
            {
                city.Print();
            }
        }

        static void AddCity()
        {
            string cityName, cityState, cityCountry = string.Empty;
            decimal cityLong, cityLat = 0;

            Console.WriteLine("Please enter the information for the city you wish to add");

            Console.Write("City: ");
            cityName = Console.ReadLine();

            Console.Write("State/Province: ");
            cityState = Console.ReadLine();

            Console.Write("Country: ");
            cityCountry = Console.ReadLine();

            Console.Write("Lattitude: ");
            if(!decimal.TryParse(Console.ReadLine(), out cityLat))
            {
                Console.WriteLine("Error: Invalid input");
                return;
            }

            Console.Write("Longitude: ");
            if(!decimal.TryParse(Console.ReadLine(), out cityLong))
            {
                Console.WriteLine("Error: Invalid input");
                return;
            }

            Geolocation newCity = new Geolocation(cityLat, cityLong);
            City newCity2 = new City(cityName, cityState, cityCountry, newCity);

            cities.Add(newCity2);
            Console.WriteLine($"{cityName} added");
        }

        static void RemoveCity()
        {
            int cityIndex = -1;

            Console.WriteLine("City List:");
            for (int i = 0; i < cities.Count; i++)
            {
                Console.WriteLine($"{i}. {cities[i].Name}");
            }

            Console.Write("Select the city you wish to remove: ");

            if (int.TryParse(Console.ReadLine(), out cityIndex) == false)
            {
                Console.WriteLine("Error: Invalid input");
                return;
            }
            else
            {
                Console.WriteLine($"{cities[cityIndex].Name} was removed");
                cities.RemoveAt(cityIndex);
                return;
            }
        }

        static void CityDistances()
        {
            int city1 = -1;
            int city2 = -1;

            Console.WriteLine("City List:");
            for (int i = 0; i < cities.Count; i++)
            {
                Console.WriteLine($"{i}. {cities[i].Name}");
            }

            Console.Write("Enter first city number: ");
            if (int.TryParse(Console.ReadLine(), out city1) == false)
            {
                Console.WriteLine("Error: Invalid input");
                return;
            }

            Console.Write("Enter second city number: ");
            if (int.TryParse(Console.ReadLine(), out city2) == false)
            {
                Console.WriteLine("Error: Invalid input");
                return;
            }

            Array values = Enum.GetValues(typeof(LengthTypes));

            Console.WriteLine("Please select a unit of measurement");

            int count = 0;

            foreach (var type in values)
            {
                Console.WriteLine($"[{count}] {Enum.GetName(typeof(LengthTypes),type)}");
                count++;
            }

            LengthTypes lenChoice;

            Console.Write("Your choice: ");
            if (Enum.TryParse(Console.ReadLine(), out lenChoice) == false)
            {
                Console.WriteLine("Error: Invalid input");
                return;
            }

            switch (lenChoice)
            {
                case LengthTypes.Feet:
                    Console.WriteLine($"Distance between {cities[city1].Name} and {cities[city2].Name} is {decimal.Round(cities[city1].Distance(cities[city2], LengthTypes.Feet),1)} feet.");
                    break;
                case LengthTypes.Kilometers:
                    Console.WriteLine($"Distance between {cities[city1].Name} and {cities[city2].Name} is {decimal.Round(cities[city1].Distance(cities[city2], LengthTypes.Kilometers),1)} Kilometers");
                    break;
                case LengthTypes.Meters:
                    Console.WriteLine($"Distance between {cities[city1].Name} and {cities[city2].Name} is {decimal.Round(cities[city1].Distance(cities[city2], LengthTypes.Meters),1)} Meters");
                    break;
                case LengthTypes.Miles:
                    Console.WriteLine($"Distance between {cities[city1].Name} and {cities[city2].Name} is {decimal.Round(cities[city1].Distance(cities[city2], LengthTypes.Miles),1)} Miles");
                    break;
                default:
                    break;
            }
        }
    }
}
