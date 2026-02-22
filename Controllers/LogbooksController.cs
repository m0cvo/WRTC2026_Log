using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WRTC2026_Log.Data;
using WRTC2026_Log.Models;

namespace WRTC2026_Log.Controllers
{
    public class LogbooksController : Controller
    {
        public int entryCount = 0;

        private readonly WRTC2026_LogContext _context;

        public LogbooksController(WRTC2026_LogContext context)
        {
            _context = context;
        }

        // GET: Logbooks
        public async Task<IActionResult> Index()
        {
            return View(await _context.Logbook.ToListAsync());
        }

        // GET: Logbooks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var logbook = await _context.Logbook
                .FirstOrDefaultAsync(m => m.Id == id);
            if (logbook == null)
            {
                return NotFound();
            }

            return View(logbook);
        }

        // GET: Logbooks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Logbooks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Date,Time,Frequency,Mode,Power,Callsign,ReportSent,ReportReceived")] Logbook logbook)
        {
            if (ModelState.IsValid)
            {
                _context.Add(logbook);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            entryCount++;
            return View(logbook);
        }

        // GET: Logbooks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var logbook = await _context.Logbook.FindAsync(id);
            if (logbook == null)
            {
                return NotFound();
            }
            return View(logbook);
        }

        // POST: Logbooks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Date,Time,Frequency,Mode,Power,Callsign,ReportSent,ReportReceived")] Logbook logbook)
        {
            if (id != logbook.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(logbook);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LogbookExists(logbook.Id))
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
            return View(logbook);
        }

        // GET: Logbooks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var logbook = await _context.Logbook
                .FirstOrDefaultAsync(m => m.Id == id);
            if (logbook == null)
            {
                return NotFound();
            }

            return View(logbook);
        }

        // POST: Logbooks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var logbook = await _context.Logbook.FindAsync(id);
            if (logbook != null)
            {
                _context.Logbook.Remove(logbook);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LogbookExists(int id)
        {
            return _context.Logbook.Any(e => e.Id == id);
        }
    }
}
