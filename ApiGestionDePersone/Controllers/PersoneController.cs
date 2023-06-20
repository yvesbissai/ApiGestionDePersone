using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiGestionDePersone.Data;
using ApiGestionDePersone.Modele;

namespace ApiGestionDePersone.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersoneController : ControllerBase
    {
        private readonly ApiGestionDePersoneContext _context;

        public PersoneController(ApiGestionDePersoneContext context)
        {
            _context = context;
        }

        // GET: api/Persone/filtre
        [HttpGet("{rech}")]
        public async Task<ActionResult<IEnumerable<Persone>>> GetPersone(string  rech = null)
        { 
            if (_context.Persone == null)
           {
               return NotFound();
           }
            else if (rech==null)
            {
                return await _context.Persone.ToListAsync(); 
            }
            else
            {
                return await _context.Persone
                    .Where(p => p.Nom.ToLower().EndsWith(rech.ToLower()) || 
                     (p.Nom.ToLower().StartsWith(rech.ToLower()) || 
                     (p.Prenom.ToLower().StartsWith(rech.ToLower()) || 
                    (p.Prenom.ToLower().EndsWith(rech.ToLower())))))
                    .ToListAsync();
            }

        }

        // GET: api/Persone/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Persone>> GetPersone(int id)
        {
          if (_context.Persone == null)
          {
              return NotFound();
          }
            var persone = await _context.Persone.FindAsync(id);

            if (persone == null)
            {
                return NotFound();
            }

            return persone;
        }

        // PUT: api/Persone/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPersone(int id, Persone persone)
        {
            if (id != persone.id)
            {
                return BadRequest();
            }

            _context.Entry(persone).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersoneExists(id))
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

        // POST: api/Persone
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Persone>> PostPersone(Persone persone)
        {
          if (_context.Persone == null)
          {
              return Problem("Entity set 'ApiGestionDePersoneContext.Persone'  is null.");
          }
            _context.Persone.Add(persone);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPersone", new { id = persone.id }, persone);
        }

        // DELETE: api/Persone/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePersone(int id)
        {
            if (_context.Persone == null)
            {
                return NotFound();
            }
            var persone = await _context.Persone.FindAsync(id);
            if (persone == null)
            {
                return NotFound();
            }

            _context.Persone.Remove(persone);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PersoneExists(int id)
        {
            return (_context.Persone?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
