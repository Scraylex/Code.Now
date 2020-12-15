using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Models;
using WebApi.Services;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AirQualityController : ControllerBase
    {
        private readonly AirQualityContext _context;


        public AirQualityController(AirQualityContext context)
        {
            _context = context;
        }

        // GET: api/AirQuality
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AirQuality>>> GetAirQualityData()
        {
            return await _context.AirQualityData.ToListAsync();
        }

        // GET: api/AirQuality/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AirQuality>> GetAirQuality(long id)
        {
            var airQuality = await _context.AirQualityData.FindAsync(id);

            if (airQuality == null)
            {
                return NotFound();
            }

            return airQuality;
        }

        // PUT: api/AirQuality/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAirQuality(long id, AirQuality airQuality)
        {
            if (id != airQuality.Id)
            {
                return BadRequest();
            }

            _context.Entry(airQuality).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AirQualityExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/AirQuality
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AirQuality>> PostAirQuality(AirQuality airQuality)
        {
            _context.AirQualityData.Add(airQuality);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAirQuality", new { id = airQuality.Id }, airQuality);
        }

        // DELETE: api/AirQuality/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAirQuality(long id)
        {
            var airQuality = await _context.AirQualityData.FindAsync(id);
            if (airQuality == null)
            {
                return NotFound();
            }

            _context.AirQualityData.Remove(airQuality);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AirQualityExists(long id)
        {
            return _context.AirQualityData.Any(e => e.Id == id);
        }
    }
}
