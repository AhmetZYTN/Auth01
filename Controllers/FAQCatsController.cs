using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Auth01.Data;
using Auth01.Models;

namespace Auth01.Controllers
{
    public class FAQCatsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FAQCatsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: FAQCats
        public async Task<IActionResult> Index()
        {
              return _context.FAQCat != null ? 
                          View(await _context.FAQCat.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.FAQCat'  is null.");
        }

        // GET: FAQCats/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.FAQCat == null)
            {
                return NotFound();
            }

            var fAQCat = await _context.FAQCat
                .FirstOrDefaultAsync(m => m.Id == id);
            if (fAQCat == null)
            {
                return NotFound();
            }

            return View(fAQCat);
        }

        // GET: FAQCats/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FAQCats/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CatName")] FAQCat fAQCat)
        {
            if (ModelState.IsValid)
            {
                _context.Add(fAQCat);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(fAQCat);
        }

        // GET: FAQCats/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.FAQCat == null)
            {
                return NotFound();
            }

            var fAQCat = await _context.FAQCat.FindAsync(id);
            if (fAQCat == null)
            {
                return NotFound();
            }
            return View(fAQCat);
        }

        // POST: FAQCats/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CatName")] FAQCat fAQCat)
        {
            if (id != fAQCat.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fAQCat);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FAQCatExists(fAQCat.Id))
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
            return View(fAQCat);
        }

        // GET: FAQCats/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.FAQCat == null)
            {
                return NotFound();
            }

            var fAQCat = await _context.FAQCat
                .FirstOrDefaultAsync(m => m.Id == id);
            if (fAQCat == null)
            {
                return NotFound();
            }

            return View(fAQCat);
        }

        // POST: FAQCats/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.FAQCat == null)
            {
                return Problem("Entity set 'ApplicationDbContext.FAQCat'  is null.");
            }
            var fAQCat = await _context.FAQCat.FindAsync(id);
            if (fAQCat != null)
            {
                _context.FAQCat.Remove(fAQCat);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FAQCatExists(int id)
        {
          return (_context.FAQCat?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
