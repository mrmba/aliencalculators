using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SSGeek.Models
{
    public class AlienWeightModel
    {
        public int EarthWeight { get; set; }
        public string PlanetSelection { get; set; }
        public double AlienWeight { get; set; }

        public Dictionary<string, double> Planets { get; } = new Dictionary<string, double>()
         {
            { "Mercury", 0.37 },
            { "Venus", 0.90 },
            { "Mars", 0.38 },
            { "Saturn", 1.13 },
            { "Neptune", 1.43 },
            { "Uranus", 1.09 },
            { "Jupiter", 2.65 }
         };

      public double GetAlienWeight(string PlanetSelection, int EarthWeight)
        {
            double planetGravity = Planets[PlanetSelection];
            AlienWeight = planetGravity * EarthWeight;
            return AlienWeight;
        }
    }
}