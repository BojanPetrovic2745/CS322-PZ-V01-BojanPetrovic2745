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

namespace CS322_PZ_V01_BojanPetrovic2745.Controllers
{
    [Authorize]
    public class Patient_KontrolaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public Patient_KontrolaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Patient_Kontrola
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Patient_Kontrola.Include(p => p.Patient);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Patient_Kontrola/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patient_Kontrola = await _context.Patient_Kontrola
                .Include(p => p.Patient)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (patient_Kontrola == null)
            {
                return NotFound();
            }

            return View(patient_Kontrola);
        }

        // GET: Patient_Kontrola/Create
        public IActionResult Create()
        {
            ViewData["PatientID"] = new SelectList(_context.Patient, "IDpa", "ime");
            ViewData["KontrolaID"] = new SelectList(_context.Kontrola, "IDkon", "kontrola1");
            return View();
        }

        // POST: Patient_Kontrola/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,PatientID,KontroalD")] Patient_Kontrola patient_Kontrola)
        {
            if (ModelState.IsValid)
            {
                _context.Add(patient_Kontrola);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PatientID"] = new SelectList(_context.Patient, "IDpa", "ime", patient_Kontrola.PatientID);
            return View(patient_Kontrola);
        }

        // GET: Patient_Kontrola/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patient_Kontrola = await _context.Patient_Kontrola.FindAsync(id);
            if (patient_Kontrola == null)
            {
                return NotFound();
            }
            ViewData["PatientID"] = new SelectList(_context.Patient, "IDpa", "ime", patient_Kontrola.PatientID);
            return View(patient_Kontrola);
        }

        // POST: Patient_Kontrola/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,PatientID,KontroalD")] Patient_Kontrola patient_Kontrola)
        {
            if (id != patient_Kontrola.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(patient_Kontrola);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Patient_KontrolaExists(patient_Kontrola.ID))
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
            ViewData["PatientID"] = new SelectList(_context.Patient, "IDpa", "ime", patient_Kontrola.PatientID);
            return View(patient_Kontrola);
        }

        // GET: Patient_Kontrola/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patient_Kontrola = await _context.Patient_Kontrola
                .Include(p => p.Patient)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (patient_Kontrola == null)
            {
                return NotFound();
            }

            return View(patient_Kontrola);
        }

        // POST: Patient_Kontrola/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var patient_Kontrola = await _context.Patient_Kontrola.FindAsync(id);
            _context.Patient_Kontrola.Remove(patient_Kontrola);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Patient_KontrolaExists(int id)
        {
            return _context.Patient_Kontrola.Any(e => e.ID == id);
        }
    }
}
