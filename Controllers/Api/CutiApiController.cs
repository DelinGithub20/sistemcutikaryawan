using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using sistemcutikaryawan.Data;
using sistemcutikaryawan.Models;

namespace sistemcutikaryawan.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CutiApiController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CutiApiController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/cutiapi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cuti>>> GetCutis()
        {
            return await _context.Cutis.ToListAsync();
        }

        // GET: api/cutiapi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cuti>> GetCuti(int id)
        {
            var cuti = await _context.Cutis.FindAsync(id);
            if (cuti == null) return NotFound();
            return cuti;
        }

        // POST: api/cutiapi
        [HttpPost]
        public async Task<ActionResult<Cuti>> PostCuti(Cuti cuti)
        {
            _context.Cutis.Add(cuti);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetCuti), new { id = cuti.Id }, cuti);
        }

        // PUT: api/cutiapi/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCuti(int id, Cuti cuti)
        {
            if (id != cuti.Id) return BadRequest();
            _context.Entry(cuti).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        // DELETE: api/cutiapi/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCuti(int id)
        {
            var cuti = await _context.Cutis.FindAsync(id);
            if (cuti == null) return NotFound();

            _context.Cutis.Remove(cuti);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
