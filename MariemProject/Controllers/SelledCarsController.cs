using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MariemProject.Data;
using MariemProject.Entities;

namespace MariemProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SelledCarsController : ControllerBase
    {
        private readonly MariemProjectDbContext _context;

        public SelledCarsController(MariemProjectDbContext context)
        {
            _context = context;
        }

        // GET: api/SelledCars
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SelledCar>>> GetSelledCar()
        {
            return await _context.SelledCar.ToListAsync();
        }

        // GET: api/SelledCars/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SelledCar>> GetSelledCar(int id)
        {
            var selledCar = await _context.SelledCar.FindAsync(id);

            if (selledCar == null)
            {
                return NotFound();
            }

            return selledCar;
        }

        // PUT: api/SelledCars/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSelledCar(int id, SelledCar selledCar)
        {
            if (id != selledCar.Id)
            {
                return BadRequest();
            }

            _context.Entry(selledCar).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SelledCarExists(id))
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

        // POST: api/SelledCars
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<SelledCar>> PostSelledCar(SelledCar selledCar)
        {
            _context.SelledCar.Add(selledCar);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSelledCar", new { id = selledCar.Id }, selledCar);
        }

        // DELETE: api/SelledCars/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<SelledCar>> DeleteSelledCar(int id)
        {
            var selledCar = await _context.SelledCar.FindAsync(id);
            if (selledCar == null)
            {
                return NotFound();
            }

            _context.SelledCar.Remove(selledCar);
            await _context.SaveChangesAsync();

            return selledCar;
        }

        private bool SelledCarExists(int id)
        {
            return _context.SelledCar.Any(e => e.Id == id);
        }
    }
}
