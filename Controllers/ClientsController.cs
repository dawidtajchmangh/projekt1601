using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using zpnet.Models;

namespace zpnet.Controllers
{
    public class ClientsController : Controller
    {
        private readonly zpnetContext _context;

        public ClientsController(zpnetContext context)
        {
            _context = context;
        }

        // GET: Fields
        public async Task<IActionResult> Index()
        {
            return _context.Client != null ?
                        View(await _context.Client.ToListAsync()) :
                        Problem("Entity set 'zpnetContext.Client'  is null.");
        }

        // GET: Fields/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Client == null)
            {
                return NotFound();
            }

            var @client = await _context.Client
                .FirstOrDefaultAsync(m => m.Id == id);
            if (@client == null)
            {
                return NotFound();
            }

            return View(@client);
        }

        // GET: Fields/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Fields/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Imie,Nazwisko,Telefon,Email")] Client @client)
        {
            if (ModelState.IsValid)
            {
                _context.Add(@client);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(@client);
        }

        // GET: Fields/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Client == null)
            {
                return NotFound();
            }

            var @client = await _context.Client.FindAsync(id);
            if (@client == null)
            {
                return NotFound();
            }
            return View(@client);
        }

        // POST: Fields/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Imie,Nazwisko,Telefon,Email")] Client @client)
        {
            if (id != @client.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(@client);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClientExists(@client.Id))
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
            return View(@client);
        }

        // GET: Fields/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Client == null)
            {
                return NotFound();
            }

            var @client = await _context.Client
                .FirstOrDefaultAsync(m => m.Id == id);
            if (@client == null)
            {
                return NotFound();
            }

            return View(@client);
        }

        // POST: Fields/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Client == null)
            {
                return Problem("Entity set 'zpnetContext.Client'  is null.");
            }
            var @client = await _context.Client.FindAsync(id);
            if (@client != null)
            {
                _context.Client.Remove(@client);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClientExists(int id)
        {
            return (_context.Client?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
