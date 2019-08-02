using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProyectoDefenitivo2.Data;
using ProyectoDefenitivo2.Models;

namespace ProyectoDefenitivo2.Controllers
{
    public class TipoAccesoriosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TipoAccesoriosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TipoAccesorios
        public async Task<IActionResult> Index()
        {
            return View(await _context.TipoAccesorio.ToListAsync());
        }

        // GET: TipoAccesorios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoAccesorio = await _context.TipoAccesorio
                .FirstOrDefaultAsync(m => m.TipoAccesorioID == id);
            if (tipoAccesorio == null)
            {
                return NotFound();
            }

            return View(tipoAccesorio);
        }

        // GET: TipoAccesorios/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipoAccesorios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TipoAccesorioID,Nombre")] TipoAccesorio tipoAccesorio)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoAccesorio);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoAccesorio);
        }

        // GET: TipoAccesorios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoAccesorio = await _context.TipoAccesorio.FindAsync(id);
            if (tipoAccesorio == null)
            {
                return NotFound();
            }
            return View(tipoAccesorio);
        }

        // POST: TipoAccesorios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TipoAccesorioID,Nombre")] TipoAccesorio tipoAccesorio)
        {
            if (id != tipoAccesorio.TipoAccesorioID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoAccesorio);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoAccesorioExists(tipoAccesorio.TipoAccesorioID))
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
            return View(tipoAccesorio);
        }

        // GET: TipoAccesorios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoAccesorio = await _context.TipoAccesorio
                .FirstOrDefaultAsync(m => m.TipoAccesorioID == id);
            if (tipoAccesorio == null)
            {
                return NotFound();
            }

            return View(tipoAccesorio);
        }

        // POST: TipoAccesorios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tipoAccesorio = await _context.TipoAccesorio.FindAsync(id);
            _context.TipoAccesorio.Remove(tipoAccesorio);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoAccesorioExists(int id)
        {
            return _context.TipoAccesorio.Any(e => e.TipoAccesorioID == id);
        }
    }
}
