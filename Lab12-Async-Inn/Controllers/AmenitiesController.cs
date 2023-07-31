using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Lab12_Async_Inn.Data;
using Lab12_Async_Inn.Models;

namespace Lab12_Async_Inn.Controllers
{
    public class AmenitiesController : Controller
    {
        private readonly AsyncInnContext _context;

        public AmenitiesController(AsyncInnContext context)
        {
            _context = context;
        }

        // GET: Amenities
        public async Task<IActionResult> Index()
        {
              return _context.Amenity != null ? 
                          View(await _context.Amenity.ToListAsync()) :
                          Problem("Entity set 'AsyncInnContext.Amenity'  is null.");
        }

        // GET: Amenities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Amenity == null)
            {
                return NotFound();
            }

            var amenity = await _context.Amenity
                .FirstOrDefaultAsync(m => m.ID == id);
            if (amenity == null)
            {
                return NotFound();
            }

            return View(amenity);
        }

        // GET: Amenities/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Amenities/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name")] Amenity amenity)
        {
            if (ModelState.IsValid)
            {
                _context.Add(amenity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(amenity);
        }

        // GET: Amenities/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Amenity == null)
            {
                return NotFound();
            }

            var amenity = await _context.Amenity.FindAsync(id);
            if (amenity == null)
            {
                return NotFound();
            }
            return View(amenity);
        }

        // POST: Amenities/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name")] Amenity amenity)
        {
            if (id != amenity.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(amenity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AmenityExists(amenity.ID))
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
            return View(amenity);
        }

        // GET: Amenities/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Amenity == null)
            {
                return NotFound();
            }

            var amenity = await _context.Amenity
                .FirstOrDefaultAsync(m => m.ID == id);
            if (amenity == null)
            {
                return NotFound();
            }

            return View(amenity);
        }

        // POST: Amenities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Amenity == null)
            {
                return Problem("Entity set 'AsyncInnContext.Amenity'  is null.");
            }
            var amenity = await _context.Amenity.FindAsync(id);
            if (amenity != null)
            {
                _context.Amenity.Remove(amenity);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AmenityExists(int id)
        {
          return (_context.Amenity?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
