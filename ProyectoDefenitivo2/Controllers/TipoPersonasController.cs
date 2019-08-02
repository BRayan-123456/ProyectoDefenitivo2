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
    public class TipoPersonasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TipoPersonasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TipoPersonas
        public async Task<IActionResult> Index()
        {
            return View(await _context.TipoPersona.ToListAsync());
        }

        // GET: TipoPersonas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoPersona = await _context.TipoPersona
                .FirstOrDefaultAsync(m => m.TipoPersonaID == id);
            if (tipoPersona == null)
            {
                return NotFound();
            }

            return View(tipoPersona);
        }

        // GET: TipoPersonas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipoPersonas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TipoPersonaID,Nombre")] TipoPersona tipoPersona)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoPersona);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoPersona);
        }

        // GET: TipoPersonas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoPersona = await _context.TipoPersona.FindAsync(id);
            if (tipoPersona == null)
            {
                return NotFound();
            }
            return View(tipoPersona);
        }

        // POST: TipoPersonas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TipoPersonaID,Nombre")] TipoPersona tipoPersona)
        {
            if (id != tipoPersona.TipoPersonaID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoPersona);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoPersonaExists(tipoPersona.TipoPersonaID))
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
            return View(tipoPersona);
        }

        // GET: TipoPersonas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoPersona = await _context.TipoPersona
                .FirstOrDefaultAsync(m => m.TipoPersonaID == id);
            if (tipoPersona == null)
            {
                return NotFound();
            }

            return View(tipoPersona);
        }

        // POST: TipoPersonas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tipoPersona = await _context.TipoPersona.FindAsync(id);
            _context.TipoPersona.Remove(tipoPersona);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoPersonaExists(int id)
        {
            return _context.TipoPersona.Any(e => e.TipoPersonaID == id);
        }
    }
}
