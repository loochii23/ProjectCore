using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjectCore.DAL.Models;

namespace ProjectCore.Controllers
{
    public class PrioritiesController : Controller
    {
        private readonly ProjectCoreContext _context;

        public PrioritiesController()
        {
            _context = new ProjectCoreContext();
        }

        // GET: Priorities
        public async Task<IActionResult> Index()
        {
            return View(await _context.Priorities.ToListAsync());
        }

        // GET: Priorities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var priorities = await _context.Priorities
                .FirstOrDefaultAsync(m => m.Id == id);
            if (priorities == null)
            {
                return NotFound();
            }

            return View(priorities);
        }

        // GET: Priorities/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Priorities/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Active")] Priorities priorities)
        {
            if (ModelState.IsValid)
            {
                _context.Add(priorities);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(priorities);
        }

        // GET: Priorities/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var priorities = await _context.Priorities.FindAsync(id);
            if (priorities == null)
            {
                return NotFound();
            }
            return View(priorities);
        }

        // POST: Priorities/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Active")] Priorities priorities)
        {
            if (id != priorities.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(priorities);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PrioritiesExists(priorities.Id))
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
            return View(priorities);
        }

        // GET: Priorities/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var priorities = await _context.Priorities
                .FirstOrDefaultAsync(m => m.Id == id);
            if (priorities == null)
            {
                return NotFound();
            }

            return View(priorities);
        }

        // POST: Priorities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var priorities = await _context.Priorities.FindAsync(id);
            _context.Priorities.Remove(priorities);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PrioritiesExists(int id)
        {
            return _context.Priorities.Any(e => e.Id == id);
        }
    }
}
