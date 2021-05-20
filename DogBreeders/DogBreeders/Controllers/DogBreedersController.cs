using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DogBreeders.Data;
using DogBreeders.Models;

namespace DogBreeders.Controllers
{
    public class DogBreedersController : Controller
    {
        private readonly DogBreedersDB _context;

        public DogBreedersController(DogBreedersDB context)
        {
            _context = context;
        }

        // GET: DogBreeders
        public async Task<IActionResult> Index()
        {
            return View(await _context.DogBreeders.ToListAsync());
        }

        // GET: DogBreeders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dogBreeder = await _context.DogBreeders
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dogBreeder == null)
            {
                return NotFound();
            }

            return View(dogBreeder);
        }

        // GET: DogBreeders/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DogBreeders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Address,PostalCode,Email,CellPhone")] DogBreeder dogBreeder)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dogBreeder);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dogBreeder);
        }

        // GET: DogBreeders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dogBreeder = await _context.DogBreeders.FindAsync(id);
            if (dogBreeder == null)
            {
                return NotFound();
            }
            return View(dogBreeder);
        }

        // POST: DogBreeders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Address,PostalCode,Email,CellPhone")] DogBreeder dogBreeder)
        {
            if (id != dogBreeder.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dogBreeder);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DogBreederExists(dogBreeder.Id))
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
            return View(dogBreeder);
        }

        // GET: DogBreeders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dogBreeder = await _context.DogBreeders
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dogBreeder == null)
            {
                return NotFound();
            }

            return View(dogBreeder);
        }

        // POST: DogBreeders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dogBreeder = await _context.DogBreeders.FindAsync(id);
            _context.DogBreeders.Remove(dogBreeder);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DogBreederExists(int id)
        {
            return _context.DogBreeders.Any(e => e.Id == id);
        }
    }
}
