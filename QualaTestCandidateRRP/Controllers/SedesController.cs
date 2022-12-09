using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QualaTestCandidateRRP.Models;
using QualaTestCandidateRRP.Data;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace QualaTestCandidateRRP.Controllers
{
    public class SedesController : Controller
    {
        private readonly TestDBContext _context;

        public SedesController(TestDBContext context)
        {
            _context = context;
        }

        // GET: Sedes
        public async Task<IActionResult> Index()
        {
            //assigning SelectListItem to view Bag for Coins
            ViewBag.Monedas = _context.Monedas;
            return View(await _context.Sedes.ToListAsync());
        }

        // GET: Sedes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Sedes == null)
            {
                return NotFound();
            }

            var sede = await _context.Sedes
                .FirstOrDefaultAsync(m => m.Codigo == id);
            if (sede == null)
            {
                return NotFound();
            }

            return View(sede);
        }

        // GET: Sedes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Sedes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Codigo,Descripcion,Direccion,Identificacion,NombreMoneda,FechaTransaccion")] Sede sede)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sede);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sede);
        }

        // GET: Sedes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Sedes == null)
            {
                return NotFound();
            }

            var sede = await _context.Sedes.FindAsync(id);
            if (sede == null)
            {
                return NotFound();
            }
            return View(sede);
        }

        // POST: Sedes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Codigo,Descripcion,Direccion,Identificacion,NombreMoneda,FechaTransaccion")] Sede sede)
        {
            if (id != sede.Codigo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sede);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SedeExists(sede.Codigo))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(sede);
        }

        // GET: Sedes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Sedes == null)
            {
                return NotFound();
            }

            var sede = await _context.Sedes
                .FirstOrDefaultAsync(m => m.Codigo == id);
            if (sede == null)
            {
                return NotFound();
            }

            return View(sede);
        }

        // POST: Sedes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Sedes == null)
            {
                return Problem("No se lograron Cargar los registros de Sedes 'TestDBContext.Sedes'  es Nulo.");
            }
            var sede = await _context.Sedes.FindAsync(id);
            if (sede != null)
            {
                _context.Sedes.Remove(sede);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SedeExists(int id)
        {
          return _context.Sedes.Any(e => e.Codigo == id);
        }
    }
}
