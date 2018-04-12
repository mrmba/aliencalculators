using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SSGeek.Models
{
    public class AlienTravelModel
    {

        public int EarthAge { get; set; }
        public string PlanetSelection { get; set; }
        public double AlienTravelYears { get; set; }
        public string TransportSelection { get; set; }
        public double TravelAge { get; set; }
            

        public Dictionary<string, double> Planets { get; } = new Dictionary<string, double>()
         {
            { "Mercury", 56974146 },
            { "Venus", 25724767 },
            { "Mars", 48678219 },
            { "Saturn", 792248270 },
            { "Neptune", 2703959960 },
            { "Uranus", 1692662530 },
            { "Jupiter", 390674710 }
         };

            public Dictionary<string, double> Transport { get; } = new Dictionary<string, double>()
         {
            { "Walking", 3 },
            { "Car", 100 },
            { "Bullet Train", 200 },
            { "Boeing 747", 570 },
            { "Concorde", 1350 },
         };

        public double GetTravelYears(string PlanetSelection, string TransportSelection, int EarthAge)
        {
            double hoursInEarthYear = 8760;
            double hoursToPlanet = Planets[PlanetSelection] / Transport[TransportSelection];
            AlienTravelYears = hoursToPlanet / hoursInEarthYear;
            return AlienTravelYears;
        }
        public double UserTravelAge (double AlienTravelYears, int EarthAge)
        {
            double TravelAge = AlienTravelYears + EarthAge;
            return TravelAge;
        }
    }
}