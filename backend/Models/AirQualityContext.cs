using Microsoft.EntityFrameworkCore;
using WebApi.Services;

namespace WebApi.Models 
{
    public class AirQualityContext : DbContext 
    {
        public AirQualityContext(DbContextOptions<AirQualityContext> options) : base(options) 
        {

        }
        public DbSet<AirQuality> AirQualityData { get; set; }
    }
}