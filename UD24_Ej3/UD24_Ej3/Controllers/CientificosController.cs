using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UD24_Ej3.Models;

namespace UD24_Ej3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CientificosController : ControllerBase
    {
        private readonly APIContext _context;

        public CientificosController(APIContext context)
        {
            _context = context;
        }

        // GET: api/Cientificos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cientificos>>> GetCientifico()
        {
            return await _context.Cientifico.ToListAsync();
        }

        // GET: api/Cientificos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cientificos>> GetCientificos(string id)
        {
            var cientificos = await _context.Cientifico.FindAsync(id);

            if (cientificos == null)
            {
                return NotFound();
            }

            return cientificos;
        }

        // PUT: api/Cientificos/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCientificos(string id, Cientificos cientificos)
        {
            if (id != cientificos.DNI)
            {
                return BadRequest();
            }

            _context.Entry(cientificos).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CientificosExists(id))
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

        // POST: api/Cientificos
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Cientificos>> PostCientificos(Cientificos cientificos)
        {
            _context.Cientifico.Add(cientificos);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CientificosExists(cientificos.DNI))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCientificos", new { id = cientificos.DNI }, cientificos);
        }

        // DELETE: api/Cientificos/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Cientificos>> DeleteCientificos(string id)
        {
            var cientificos = await _context.Cientifico.FindAsync(id);
            if (cientificos == null)
            {
                return NotFound();
            }

            _context.Cientifico.Remove(cientificos);
            await _context.SaveChangesAsync();

            return cientificos;
        }

        private bool CientificosExists(string id)
        {
            return _context.Cientifico.Any(e => e.DNI == id);
        }
    }
}
