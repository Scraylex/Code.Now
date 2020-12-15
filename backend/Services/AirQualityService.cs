using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using WebApi.Models;
using WebApi.Services;

namespace WebApi.Services
{
    public class AirQualityService
    {
        static readonly string PATH = "https://api.openaq.org/beta/averages";

        private readonly AirQualityContext _context;

        internal class AirQualityPOCO
        {
            public Meta Meta { get; set; }
            public List<AirQuality> Results { get; set; }
        }

        public AirQualityService(AirQualityContext ctx)
        {
            _context = ctx;
        }
        private static async Task<AirQualityPOCO> ConvertWebResponseToAirQualityPoco()
        {
            string jsonString = await GetWebUrlAsStringAsync();
            return JsonSerializer.Deserialize<AirQualityPOCO>(jsonString);
        }

        private static async Task<string> GetWebUrlAsStringAsync()
        {
            using var client = new HttpClient();
            var response = await client.GetAsync(PATH);
            if (response.IsSuccessStatusCode)
                return await response.Content.ReadAsStringAsync();
            else
                throw new Exception("Failed to Get URL");
        }

        public async Task SaveAirQualityData()
        {
            var data = await ConvertWebResponseToAirQualityPoco();
            await _context.AddRangeAsync(data.Results);
        }
    }
}
