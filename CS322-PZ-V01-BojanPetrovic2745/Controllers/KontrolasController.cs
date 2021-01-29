using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CS322_PZ_V01_BojanPetrovic2745.Data;
using CS322_PZ_V01_BojanPetrovic2745.Models;
using Microsoft.AspNetCore.Authorization;

namespace CS322_PZ_V01_BojanPetrovic2745
{
    [Authorize]
    public class KontrolasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public KontrolasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Kontrolas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Kontrola.ToListAsync());
        }

        // GET: Kontrolas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kontrola = await _context.Kontrola
                .FirstOrDefaultAsync(m => m.IDkon == id);
            if (kontrola == null)
            {
                return NotFound();
            }

            return View(kontrola);
        }

        // GET: Kontrolas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Kontrolas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IDkon,kontrola1")] Kontrola kontrola)
        {
            if (ModelState.IsValid)
            {
                _context.Add(kontrola);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(kontrola);
        }

        // GET: Kontrolas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kontrola = await _context.Kontrola.FindAsync(id);
            if (kontrola == null)
            {
                return NotFound();
            }
            return View(kontrola);
        }

        // POST: Kontrolas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IDkon,kontrola1")] Kontrola kontrola)
        {
            if (id != kontrola.IDkon)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(kontrola);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KontrolaExists(kontrola.IDkon))
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
            return View(kontrola);
        }

        // GET: Kontrolas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kontrola = await _context.Kontrola
                .FirstOrDefaultAsync(m => m.IDkon == id);
            if (kontrola == null)
            {
                return NotFound();
            }

            return View(kontrola);
        }

        // POST: Kontrolas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var kontrola = await _context.Kontrola.FindAsync(id);
            _context.Kontrola.Remove(kontrola);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KontrolaExists(int id)
        {
            return _context.Kontrola.Any(e => e.IDkon == id);
        }
    }
}
