using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ClassNoticias.Data;
using ClassNoticias.Models;

namespace NoticiasAppMVC.Controllers
{
    public class MundialesController : Controller
    {
        private readonly NoticiasContext _context;

        public MundialesController(NoticiasContext context)
        {
            _context = context;
        }

        // GET: Mundiales
        public async Task<IActionResult> Index()
        {
            return View(await _context.Mundiales.ToListAsync());
        }

        // GET: Mundiales/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mundiale = await _context.Mundiales
                .FirstOrDefaultAsync(m => m.IdMundiales == id);
            if (mundiale == null)
            {
                return NotFound();
            }

            return View(mundiale);
        }

        // GET: Mundiales/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Mundiales/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdMundiales,Continente")] Mundiale mundiale)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mundiale);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(mundiale);
        }

        // GET: Mundiales/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mundiale = await _context.Mundiales.FindAsync(id);
            if (mundiale == null)
            {
                return NotFound();
            }
            return View(mundiale);
        }

        // POST: Mundiales/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdMundiales,Continente")] Mundiale mundiale)
        {
            if (id != mundiale.IdMundiales)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mundiale);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MundialeExists(mundiale.IdMundiales))
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
            return View(mundiale);
        }

        // GET: Mundiales/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mundiale = await _context.Mundiales
                .FirstOrDefaultAsync(m => m.IdMundiales == id);
            if (mundiale == null)
            {
                return NotFound();
            }

            return View(mundiale);
        }

        // POST: Mundiales/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mundiale = await _context.Mundiales.FindAsync(id);
            _context.Mundiales.Remove(mundiale);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MundialeExists(int id)
        {
            return _context.Mundiales.Any(e => e.IdMundiales == id);
        }
    }
}
