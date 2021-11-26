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
    public class NoticiassesController : Controller
    {
        private readonly NoticiasContext _context;

        public NoticiassesController(NoticiasContext context)
        {
            _context = context;
        }

        // GET: Noticiasses
        public async Task<IActionResult> Index()
        {
            var noticiasContext = _context.Noticiasses.Include(n => n.IdCategoriasNavigation).Include(n => n.IdPaisNavigation);
            return View(await noticiasContext.ToListAsync());
        }

        // GET: Noticiasses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var noticiass = await _context.Noticiasses
                .Include(n => n.IdCategoriasNavigation)
                .Include(n => n.IdPaisNavigation)
                .FirstOrDefaultAsync(m => m.IdNoticias == id);
            if (noticiass == null)
            {
                return NotFound();
            }

            return View(noticiass);
        }

        // GET: Noticiasses/Create
        public IActionResult Create()
        {
            ViewData["IdCategorias"] = new SelectList(_context.Categorias, "IdCategorias", "IdCategorias");
            ViewData["IdPais"] = new SelectList(_context.Paises, "IdPais", "IdPais");
            return View();
        }

        // POST: Noticiasses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdNoticias,Titulo,Autor,Descripcion,Link,Imagen,Fecha,IdCategorias,IdPais")] Noticiass noticiass)
        {
            if (ModelState.IsValid)
            {
                _context.Add(noticiass);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdCategorias"] = new SelectList(_context.Categorias, "IdCategorias", "IdCategorias", noticiass.IdCategorias);
            ViewData["IdPais"] = new SelectList(_context.Paises, "IdPais", "IdPais", noticiass.IdPais);
            return View(noticiass);
        }

        // GET: Noticiasses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var noticiass = await _context.Noticiasses.FindAsync(id);
            if (noticiass == null)
            {
                return NotFound();
            }
            ViewData["IdCategorias"] = new SelectList(_context.Categorias, "IdCategorias", "IdCategorias", noticiass.IdCategorias);
            ViewData["IdPais"] = new SelectList(_context.Paises, "IdPais", "IdPais", noticiass.IdPais);
            return View(noticiass);
        }

        // POST: Noticiasses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdNoticias,Titulo,Autor,Descripcion,Link,Imagen,Fecha,IdCategorias,IdPais")] Noticiass noticiass)
        {
            if (id != noticiass.IdNoticias)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(noticiass);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NoticiassExists(noticiass.IdNoticias))
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
            ViewData["IdCategorias"] = new SelectList(_context.Categorias, "IdCategorias", "IdCategorias", noticiass.IdCategorias);
            ViewData["IdPais"] = new SelectList(_context.Paises, "IdPais", "IdPais", noticiass.IdPais);
            return View(noticiass);
        }

        // GET: Noticiasses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var noticiass = await _context.Noticiasses
                .Include(n => n.IdCategoriasNavigation)
                .Include(n => n.IdPaisNavigation)
                .FirstOrDefaultAsync(m => m.IdNoticias == id);
            if (noticiass == null)
            {
                return NotFound();
            }

            return View(noticiass);
        }

        // POST: Noticiasses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var noticiass = await _context.Noticiasses.FindAsync(id);
            _context.Noticiasses.Remove(noticiass);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NoticiassExists(int id)
        {
            return _context.Noticiasses.Any(e => e.IdNoticias == id);
        }
    }
}
