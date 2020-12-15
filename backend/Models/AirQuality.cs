using System;
using WebApi.Models;

namespace WebApi.Models
{
    public class AirQuality
    {
        public AirQuality(string country, string location, string city, string measurementUnit, string particulateMatter, Coordinates coordinates)
        {
            Country = country;
            Location = location;
            City = city;
            MeasurementUnit = measurementUnit;
            ParticulateMatter = particulateMatter;
            Coordinates = coordinates;
        }

        public long Id { get; set; }
        public Coordinates Coordinates { get; set; }
        public string Location { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public DateTime Date { get; set; }
        public string MeasurementUnit { get; set; }
        public string ParticulateMatter { get; set; }
    }
}