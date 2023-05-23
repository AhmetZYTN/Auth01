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
    public class FAQModelsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FAQModelsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: FAQModels
        public async Task<IActionResult> Index()
        {
              return _context.FAQModel != null ? 
                          View(await _context.FAQModel.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.FAQModel'  is null.");
        }

        // GET: FAQModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.FAQModel == null)
            {
                return NotFound();
            }

            var fAQModel = await _context.FAQModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (fAQModel == null)
            {
                return NotFound();
            }

            return View(fAQModel);
        }

        // GET: FAQModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FAQModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Question,Answer")] FAQModel fAQModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(fAQModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(fAQModel);
        }

        // GET: FAQModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.FAQModel == null)
            {
                return NotFound();
            }

            var fAQModel = await _context.FAQModel.FindAsync(id);
            if (fAQModel == null)
            {
                return NotFound();
            }
            return View(fAQModel);
        }

        // POST: FAQModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Question,Answer")] FAQModel fAQModel)
        {
            if (id != fAQModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fAQModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FAQModelExists(fAQModel.Id))
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
            return View(fAQModel);
        }

        // GET: FAQModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.FAQModel == null)
            {
                return NotFound();
            }

            var fAQModel = await _context.FAQModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (fAQModel == null)
            {
                return NotFound();
            }

            return View(fAQModel);
        }

        // POST: FAQModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.FAQModel == null)
            {
                return Problem("Entity set 'ApplicationDbContext.FAQModel'  is null.");
            }
            var fAQModel = await _context.FAQModel.FindAsync(id);
            if (fAQModel != null)
            {
                _context.FAQModel.Remove(fAQModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FAQModelExists(int id)
        {
          return (_context.FAQModel?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
