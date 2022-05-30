﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Cinema.Data;
using Cinema.Models;

namespace Cinema.Controllers
{
    public class AssentosController : Controller
    {
        private readonly CinemaContext _context;

        public AssentosController(CinemaContext context)
        {
            _context = context;
        }

        // GET: Assentos
        public async Task<IActionResult> Index()
        {
            return View(await _context.Assento.ToListAsync());
        }

        // GET: Assentos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var assento = await _context.Assento
                .FirstOrDefaultAsync(m => m.AssentoId == id);
            if (assento == null)
            {
                return NotFound();
            }

            return View(assento);
        }

        // GET: Assentos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Assentos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AssentoId,NumAssento")] Assento assento)
        {
            if (ModelState.IsValid)
            {
                _context.Add(assento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(assento);
        }

        // GET: Assentos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var assento = await _context.Assento.FindAsync(id);
            if (assento == null)
            {
                return NotFound();
            }
            return View(assento);
        }

        // POST: Assentos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AssentoId,NumAssento")] Assento assento)
        {
            if (id != assento.AssentoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(assento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AssentoExists(assento.AssentoId))
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
            return View(assento);
        }

        // GET: Assentos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var assento = await _context.Assento
                .FirstOrDefaultAsync(m => m.AssentoId == id);
            if (assento == null)
            {
                return NotFound();
            }

            return View(assento);
        }

        // POST: Assentos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var assento = await _context.Assento.FindAsync(id);
            _context.Assento.Remove(assento);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AssentoExists(int id)
        {
            return _context.Assento.Any(e => e.AssentoId == id);
        }
    }
}
