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
    public class AccesoriosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AccesoriosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Accesorios
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Accesorios.Include(a => a.TipoAccesorio);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Accesorios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var accesorios = await _context.Accesorios
                .Include(a => a.TipoAccesorio)
                .FirstOrDefaultAsync(m => m.AccesoriosID == id);
            if (accesorios == null)
            {
                return NotFound();
            }

            return View(accesorios);
        }

        // GET: Accesorios/Create
        public IActionResult Create()
        {
            ViewData["TipoAccesorioID"] = new SelectList(_context.TipoAccesorio, "TipoAccesorioID", "Nombre");
            return View();
        }

        // POST: Accesorios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AccesoriosID,TipoAccesorioID,Nombre,Cantidad,Talla,Valor,Color")] Accesorios accesorios)
        {
            if (ModelState.IsValid)
            {
                _context.Add(accesorios);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TipoAccesorioID"] = new SelectList(_context.TipoAccesorio, "TipoAccesorioID", "TipoAccesorioID", accesorios.TipoAccesorioID);
            return View(accesorios);
        }

        // GET: Accesorios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var accesorios = await _context.Accesorios.FindAsync(id);
            if (accesorios == null)
            {
                return NotFound();
            }
            ViewData["TipoAccesorioID"] = new SelectList(_context.TipoAccesorio, "TipoAccesorioID", "Nombre", accesorios.TipoAccesorioID);
            return View(accesorios);
        }

        // POST: Accesorios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AccesoriosID,TipoAccesorioID,Nombre,Cantidad,Talla,Valor,Color")] Accesorios accesorios)
        {
            if (id != accesorios.AccesoriosID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(accesorios);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AccesoriosExists(accesorios.AccesoriosID))
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
            ViewData["TipoAccesorioID"] = new SelectList(_context.TipoAccesorio, "TipoAccesorioID", "TipoAccesorioID", accesorios.TipoAccesorioID);
            return View(accesorios);
        }

        // GET: Accesorios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var accesorios = await _context.Accesorios
                .Include(a => a.TipoAccesorio)
                .FirstOrDefaultAsync(m => m.AccesoriosID == id);
            if (accesorios == null)
            {
                return NotFound();
            }

            return View(accesorios);
        }

        // POST: Accesorios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var accesorios = await _context.Accesorios.FindAsync(id);
            _context.Accesorios.Remove(accesorios);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AccesoriosExists(int id)
        {
            return _context.Accesorios.Any(e => e.AccesoriosID == id);
        }
    }
}
