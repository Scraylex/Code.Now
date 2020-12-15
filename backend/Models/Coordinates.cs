using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models
{
    public class Coordinates
    {
        public float Longitude { get; set; }
        public float Latitude { get; set; }

        public Coordinates(float longitude, float latitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }
    }
}
