using System;
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
    public class IngressosController : Controller
    {
        private readonly CinemaContext _context;

        public IngressosController(CinemaContext context)
        {
            _context = context;
        }

        // GET: Ingressos
        public async Task<IActionResult> Index()
        {
            var cinemaContext = _context.Ingresso.Include(i => i.Assento).Include(i => i.Cinema).Include(i => i.Filme).Include(i => i.Hora).Include(i => i.Sessao).Include(i => i.TipoIngresso);
            return View(await cinemaContext.ToListAsync());
        }

        // GET: Ingressos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ingresso = await _context.Ingresso
                .Include(i => i.Assento)
                .Include(i => i.Cinema)
                .Include(i => i.Filme)
                .Include(i => i.Hora)
                .Include(i => i.Sessao)
                .Include(i => i.TipoIngresso)
                .FirstOrDefaultAsync(m => m.IngressoId == id);
            if (ingresso == null)
            {
                return NotFound();
            }

            return View(ingresso);
        }

        // GET: Ingressos/Create
        public IActionResult Create()
        {
            ViewData["AssentoId"] = new SelectList(_context.Assento, "AssentoId", "AssentoId");
            ViewData["CinemaId"] = new SelectList(_context.Cine, "CinemaId", "LocalCinema");
            ViewData["FilmeId"] = new SelectList(_context.Filme, "FilmeId", "NomeFilme");
            ViewData["HoraId"] = new SelectList(_context.Hora, "HoraId", "Horario");
            ViewData["SessaoId"] = new SelectList(_context.Sessao, "SessaoId", "NumSala");
            ViewData["TipoIngressoId"] = new SelectList(_context.TipoIngresso, "TipoIngressoId", "TIngresso");
            return View();
        }

        // POST: Ingressos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IngressoId,CinemaId,FilmeId,SessaoId,HoraId,TipoIngressoId,AssentoId")] Ingresso ingresso)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ingresso);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AssentoId"] = new SelectList(_context.Assento, "AssentoId", "AssentoId", ingresso.AssentoId);
            ViewData["CinemaId"] = new SelectList(_context.Cine, "CinemaId", "LocalCinema", ingresso.CinemaId);
            ViewData["FilmeId"] = new SelectList(_context.Filme, "FilmeId", "NomeFilme", ingresso.FilmeId);
            ViewData["HoraId"] = new SelectList(_context.Hora, "HoraId", "Horario", ingresso.HoraId);
            ViewData["SessaoId"] = new SelectList(_context.Sessao, "SessaoId", "NumSala", ingresso.SessaoId);
            ViewData["TipoIngressoId"] = new SelectList(_context.TipoIngresso, "TipoIngressoId", "TIngresso", ingresso.TipoIngressoId);
            return View(ingresso);
        }

        // GET: Ingressos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ingresso = await _context.Ingresso.FindAsync(id);
            if (ingresso == null)
            {
                return NotFound();
            }
            ViewData["AssentoId"] = new SelectList(_context.Assento, "AssentoId", "AssentoId", ingresso.AssentoId);
            ViewData["CinemaId"] = new SelectList(_context.Cine, "CinemaId", "LocalCinema", ingresso.CinemaId);
            ViewData["FilmeId"] = new SelectList(_context.Filme, "FilmeId", "NomeFilme", ingresso.FilmeId);
            ViewData["HoraId"] = new SelectList(_context.Hora, "HoraId", "Horario", ingresso.HoraId);
            ViewData["SessaoId"] = new SelectList(_context.Sessao, "SessaoId", "NumSala", ingresso.SessaoId);
            ViewData["TipoIngressoId"] = new SelectList(_context.TipoIngresso, "TipoIngressoId", "TIngresso", ingresso.TipoIngressoId);
            return View(ingresso);
        }

        // POST: Ingressos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IngressoId,CinemaId,FilmeId,SessaoId,HoraId,TipoIngressoId,AssentoId")] Ingresso ingresso)
        {
            if (id != ingresso.IngressoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ingresso);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IngressoExists(ingresso.IngressoId))
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
            ViewData["AssentoId"] = new SelectList(_context.Assento, "AssentoId", "AssentoId", ingresso.AssentoId);
            ViewData["CinemaId"] = new SelectList(_context.Cine, "CinemaId", "LocalCinema", ingresso.CinemaId);
            ViewData["FilmeId"] = new SelectList(_context.Filme, "FilmeId", "NomeFilme", ingresso.FilmeId);
            ViewData["HoraId"] = new SelectList(_context.Hora, "HoraId", "Horario", ingresso.HoraId);
            ViewData["SessaoId"] = new SelectList(_context.Sessao, "SessaoId", "NumSala", ingresso.SessaoId);
            ViewData["TipoIngressoId"] = new SelectList(_context.TipoIngresso, "TipoIngressoId", "TIngresso", ingresso.TipoIngressoId);
            return View(ingresso);
        }

        // GET: Ingressos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ingresso = await _context.Ingresso
                .Include(i => i.Assento)
                .Include(i => i.Cinema)
                .Include(i => i.Filme)
                .Include(i => i.Hora)
                .Include(i => i.Sessao)
                .Include(i => i.TipoIngresso)
                .FirstOrDefaultAsync(m => m.IngressoId == id);
            if (ingresso == null)
            {
                return NotFound();
            }

            return View(ingresso);
        }

        // POST: Ingressos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ingresso = await _context.Ingresso.FindAsync(id);
            _context.Ingresso.Remove(ingresso);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool IngressoExists(int id)
        {
            return _context.Ingresso.Any(e => e.IngressoId == id);
        }
    }
}
