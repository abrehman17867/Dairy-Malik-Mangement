using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Dairy_Malik_Mangement.Data;
using Dairy_Malik_Mangement.Models;
using Microsoft.AspNetCore.Authorization;

namespace Dairy_Malik_Mangement.Controllers
{
    public class MilkController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MilkController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Milk
        public async Task<IActionResult> Index()
        {
            return View(await _context.Milk.ToListAsync());
        }

        // GET: Milk/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var milk = await _context.Milk
                .FirstOrDefaultAsync(m => m.Id == id);
            if (milk == null)
            {
                return NotFound();
            }

            return View(milk);
        }

        // GET: Milk/Create
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Milk/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,Address,NearestLocation,PhoneNumber,Liter")] Milk milk)
        {
            if (ModelState.IsValid)
            {
                _context.Add(milk);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(milk);
        }

        // GET: Milk/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var milk = await _context.Milk.FindAsync(id);
            if (milk == null)
            {
                return NotFound();
            }
            return View(milk);
        }

        // POST: Milk/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,Address,NearestLocation,PhoneNumber,Liter")] Milk milk)
        {
            if (id != milk.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(milk);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MilkExists(milk.Id))
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
            return View(milk);
        }

        // GET: Milk/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var milk = await _context.Milk
                .FirstOrDefaultAsync(m => m.Id == id);
            if (milk == null)
            {
                return NotFound();
            }

            return View(milk);
        }

        // POST: Milk/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var milk = await _context.Milk.FindAsync(id);
            if (milk != null)
            {
                _context.Milk.Remove(milk);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MilkExists(int id)
        {
            return _context.Milk.Any(e => e.Id == id);
        }
    }
}
