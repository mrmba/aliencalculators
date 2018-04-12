using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SSGeek.Models
{
    public class AlienAgeModel
    {
        public int EarthAge { get; set; }
        public string PlanetSelection { get; set; }
        public double AlienAge { get; set; }

        public Dictionary<string, double> Planets { get; } = new Dictionary<string, double>()
         {
            { "Mercury", 87.96 },
            { "Venus", 224.68 },
            { "Mars", 686.98 },
            { "Saturn", 10751.44 },
            { "Neptune", 60155.65 },
            { "Uranus", 30685.55 },
            { "Jupiter", 4329.63 }
         };

        public double GetAlienAge(string PlanetSelection, int EarthAge)
        {
            double planetYear = Planets[PlanetSelection];
            AlienAge = (365 * EarthAge) / planetYear;
            return AlienAge;
        }

    }
}