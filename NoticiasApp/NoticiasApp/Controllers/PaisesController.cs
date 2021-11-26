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
    public class PaisesController : Controller
    {
        private readonly NoticiasContext _context;

        public PaisesController(NoticiasContext context)
        {
            _context = context;
        }

        // GET: Paises
        public async Task<IActionResult> Index()
        {
            var noticiasContext = _context.Paises.Include(p => p.IdMundialesNavigation);
            return View(await noticiasContext.ToListAsync());
        }

        // GET: Paises/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paise = await _context.Paises
                .Include(p => p.IdMundialesNavigation)
                .FirstOrDefaultAsync(m => m.IdPais == id);
            if (paise == null)
            {
                return NotFound();
            }

            return View(paise);
        }

        // GET: Paises/Create
        public IActionResult Create()
        {
            ViewData["IdMundiales"] = new SelectList(_context.Mundiales, "IdMundiales", "IdMundiales");
            return View();
        }

        // POST: Paises/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPais,Pais,IdMundiales")] Paise paise)
        {
            if (ModelState.IsValid)
            {
                _context.Add(paise);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdMundiales"] = new SelectList(_context.Mundiales, "IdMundiales", "IdMundiales", paise.IdMundiales);
            return View(paise);
        }

        // GET: Paises/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paise = await _context.Paises.FindAsync(id);
            if (paise == null)
            {
                return NotFound();
            }
            ViewData["IdMundiales"] = new SelectList(_context.Mundiales, "IdMundiales", "IdMundiales", paise.IdMundiales);
            return View(paise);
        }

        // POST: Paises/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPais,Pais,IdMundiales")] Paise paise)
        {
            if (id != paise.IdPais)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(paise);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PaiseExists(paise.IdPais))
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
            ViewData["IdMundiales"] = new SelectList(_context.Mundiales, "IdMundiales", "IdMundiales", paise.IdMundiales);
            return View(paise);
        }

        // GET: Paises/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paise = await _context.Paises
                .Include(p => p.IdMundialesNavigation)
                .FirstOrDefaultAsync(m => m.IdPais == id);
            if (paise == null)
            {
                return NotFound();
            }

            return View(paise);
        }

        // POST: Paises/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var paise = await _context.Paises.FindAsync(id);
            _context.Paises.Remove(paise);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PaiseExists(int id)
        {
            return _context.Paises.Any(e => e.IdPais == id);
        }
    }
}
