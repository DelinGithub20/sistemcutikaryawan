using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using sistemcutikaryawan.Data;
using sistemcutikaryawan.Models;

namespace sistemcutikaryawan.Controllers
{
    public class CutiController : Controller
    {
        private readonly AppDbContext _context;

        public CutiController(AppDbContext context)
        {
            _context = context;
        }

        // GET: /Cuti
        public async Task<IActionResult> Index(string? q)
        {
            var query = _context.Cutis.AsQueryable();

            if (!string.IsNullOrWhiteSpace(q))
                query = query.Where(c => c.NamaKaryawan.Contains(q));

            var data = await query
                .OrderByDescending(c => c.Id)
                .ToListAsync();

            ViewData["q"] = q;
            return View(data);
        }

        // GET: /Cuti/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var cuti = await _context.Cutis.FirstOrDefaultAsync(m => m.Id == id);
            if (cuti == null) return NotFound();

            return View(cuti);
        }

        // GET: /Cuti/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: /Cuti/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NamaKaryawan,TanggalMulai,TanggalSelesai,Alasan")] Cuti cuti)
        {
            if (cuti.TanggalSelesai < cuti.TanggalMulai)
                ModelState.AddModelError(nameof(Cuti.TanggalSelesai), "Tanggal selesai tidak boleh sebelum tanggal mulai.");

            if (!ModelState.IsValid) return View(cuti);

            _context.Add(cuti);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: /Cuti/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var cuti = await _context.Cutis.FindAsync(id);
            if (cuti == null) return NotFound();

            return View(cuti);
        }

        // POST: /Cuti/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NamaKaryawan,TanggalMulai,TanggalSelesai,Alasan")] Cuti cuti)
        {
            if (id != cuti.Id) return NotFound();

            if (cuti.TanggalSelesai < cuti.TanggalMulai)
                ModelState.AddModelError(nameof(Cuti.TanggalSelesai), "Tanggal selesai tidak boleh sebelum tanggal mulai.");

            if (!ModelState.IsValid) return View(cuti);

            try
            {
                _context.Update(cuti);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await _context.Cutis.AnyAsync(e => e.Id == id))
                    return NotFound();
                throw;
            }

            return RedirectToAction(nameof(Index));
        }

        // GET: /Cuti/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            var cuti = await _context.Cutis.FirstOrDefaultAsync(m => m.Id == id);
            if (cuti == null) return NotFound();
            return View(cuti);
        }

        // POST: /Cuti/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cuti = await _context.Cutis.FindAsync(id);
            if (cuti != null)
            {
                _context.Cutis.Remove(cuti);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        // POST: /Cutis/Approve/5
[HttpPost]
[ValidateAntiForgeryToken]
public async Task<IActionResult> Approve(int id)
{
    var cuti = await _context.Cutis.FindAsync(id);
    if (cuti == null) return NotFound();

    cuti.Status = "Approved";
    _context.Update(cuti);
    await _context.SaveChangesAsync();

    return RedirectToAction(nameof(Index));
}

// POST: /Cutis/Decline/5
[HttpPost]
[ValidateAntiForgeryToken]
public async Task<IActionResult> Decline(int id)
{
    var cuti = await _context.Cutis.FindAsync(id);
    if (cuti == null) return NotFound();

    cuti.Status = "Declined";
    _context.Update(cuti);
    await _context.SaveChangesAsync();

    return RedirectToAction(nameof(Index));
}

    }
}
