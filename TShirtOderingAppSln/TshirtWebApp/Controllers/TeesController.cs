using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TshirtWebApp.Models;

namespace TshirtWebApp.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TeesController : ControllerBase
    {
        private readonly TeesContext _context;

        public TeesController(TeesContext context)
        {
            _context = context;
        }

        // GET: api/Tees
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tee>>> GetTees()
        {
            return await _context.Tees.ToListAsync();
        }

        // GET: api/Tees/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Tee>> GetTees(int id)
        {
            var tees = await _context.Tees.FindAsync(id);

            if (tees == null)
            { 
                return NotFound();
            }

            return tees;
        }

        // PUT: api/Tees/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTees(int id, Tee tees)
        {
            if (id != tees.ID)
            {
                return BadRequest();
            }

            _context.Entry(tees).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TeesExists(id))
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

        // POST: api/Tees
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Tee>> PostTees(Tee[] tees)
        {
            foreach(var t in tees) {
                _context.Tees.Add(t);
                await _context.SaveChangesAsync();
            }
            return Ok();
        }

        

        // DELETE: api/Tees/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Tee>> DeleteTees(int id)
        {
            var tees = await _context.Tees.FindAsync(id);
            if (tees == null)
            {
                return NotFound();
            }

            _context.Tees.Remove(tees);
            await _context.SaveChangesAsync();

            return tees;
        }

        private bool TeesExists(int id)
        {
            return _context.Tees.Any(e => e.ID == id);
        }
    }
}
