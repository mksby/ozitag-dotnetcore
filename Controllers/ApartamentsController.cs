using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoApi.Models;

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApartamentsController : ControllerBase
    {
        private readonly ApartamentContext _context;

        public ApartamentsController(ApartamentContext context)
        {
            _context = context;
        }

        // GET: api/Apartaments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Apartament>>> GetApartament()
        {
            return await _context.Apartament.Take(10).ToListAsync();
        }

        // GET: api/Apartaments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Apartament>> GetApartament(long id)
        {
            var apartament = await _context.Apartament.FindAsync(id);

            if (apartament == null)
            {
                return NotFound();
            }

            return apartament;
        }

        // PUT: api/Apartaments/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutApartament(long id, Apartament apartament)
        {
            if (id != apartament.id)
            {
                return BadRequest();
            }

            _context.Entry(apartament).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ApartamentExists(id))
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

        // POST: api/Apartaments
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Apartament>> PostApartament(Apartament apartament)
        {
            _context.Apartament.Add(apartament);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetApartament", new { id = apartament.id }, apartament);
        }

        // DELETE: api/Apartaments/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Apartament>> DeleteApartament(long id)
        {
            var apartament = await _context.Apartament.FindAsync(id);
            if (apartament == null)
            {
                return NotFound();
            }

            _context.Apartament.Remove(apartament);
            await _context.SaveChangesAsync();

            return apartament;
        }

        private bool ApartamentExists(long id)
        {
            return _context.Apartament.Any(e => e.id == id);
        }
    }
}
