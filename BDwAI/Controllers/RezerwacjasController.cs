using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BDwAI.Data;
using BDwAI.Models;

namespace BDwAI.Controllers
{
    public class RezerwacjasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RezerwacjasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Rezerwacjas
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Rezerwacja.Include(r => r.Lekarz).Include(r => r.Uzytkownik);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Rezerwacjas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rezerwacja = await _context.Rezerwacja
                .Include(r => r.Lekarz)
                .Include(r => r.Uzytkownik)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (rezerwacja == null)
            {
                return NotFound();
            }

            return View(rezerwacja);
        }

        // GET: Rezerwacjas/Create
        public IActionResult Create()
        {
            ViewData["LekarzId"] = new SelectList(_context.Set<Lekarz>(), "Id", "Id");
            ViewData["UzytkownikId"] = new SelectList(_context.Set<Uzytkownik>(), "Id", "Id");
            return View();
        }

        // POST: Rezerwacjas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UzytkownikId,LekarzId,Data")] Rezerwacja rezerwacja)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rezerwacja);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["LekarzId"] = new SelectList(_context.Set<Lekarz>(), "Id", "Id", rezerwacja.LekarzId);
            ViewData["UzytkownikId"] = new SelectList(_context.Set<Uzytkownik>(), "Id", "Id", rezerwacja.UzytkownikId);
            return View(rezerwacja);
        }

        // GET: Rezerwacjas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rezerwacja = await _context.Rezerwacja.FindAsync(id);
            if (rezerwacja == null)
            {
                return NotFound();
            }
            ViewData["LekarzId"] = new SelectList(_context.Set<Lekarz>(), "Id", "Id", rezerwacja.LekarzId);
            ViewData["UzytkownikId"] = new SelectList(_context.Set<Uzytkownik>(), "Id", "Id", rezerwacja.UzytkownikId);
            return View(rezerwacja);
        }

        // POST: Rezerwacjas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UzytkownikId,LekarzId,Data")] Rezerwacja rezerwacja)
        {
            if (id != rezerwacja.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rezerwacja);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RezerwacjaExists(rezerwacja.Id))
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
            ViewData["LekarzId"] = new SelectList(_context.Set<Lekarz>(), "Id", "Id", rezerwacja.LekarzId);
            ViewData["UzytkownikId"] = new SelectList(_context.Set<Uzytkownik>(), "Id", "Id", rezerwacja.UzytkownikId);
            return View(rezerwacja);
        }

        // GET: Rezerwacjas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rezerwacja = await _context.Rezerwacja
                .Include(r => r.Lekarz)
                .Include(r => r.Uzytkownik)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (rezerwacja == null)
            {
                return NotFound();
            }

            return View(rezerwacja);
        }

        // POST: Rezerwacjas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var rezerwacja = await _context.Rezerwacja.FindAsync(id);
            if (rezerwacja != null)
            {
                _context.Rezerwacja.Remove(rezerwacja);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RezerwacjaExists(int id)
        {
            return _context.Rezerwacja.Any(e => e.Id == id);
        }
    }
}
