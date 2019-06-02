using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GroupProject3.Models;
using Microsoft.AspNetCore.Cors;

namespace GroupProject3.Controllers
{
    public class ResidentsController : Controller
    {
        private readonly ResidentsContext _context;

        public ResidentsController(ResidentsContext context)
        {
            _context = context;
        }

        // GET: Residents
	   [EnableCors("AllowOrigin")]
        public async Task<IActionResult> Index()
        {
            //return View(await _context.Residents.ToListAsync());
		  return Json(await _context.Residents.ToListAsync());
        }

        // GET: Residents/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var resident = await _context.Residents
                .FirstOrDefaultAsync(m => m.ID == id);
            if (resident == null)
            {
                return NotFound();
            }

            return View(resident);
        }

        // GET: Residents/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Residents/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,AcctOwner,UnitNum,LastName1,FirstName1,StorageNum,ContactNum1,ContactNum2,ContactNum3,Email1,Email2,Email3,Email4,ParkingSpot1,ParkingSpot2")] Resident resident)
        {
            if (ModelState.IsValid)
            {
                _context.Add(resident);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(resident);
        }

        // GET: Residents/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var resident = await _context.Residents.FindAsync(id);
            if (resident == null)
            {
                return NotFound();
            }
            return View(resident);
        }

        // POST: Residents/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,AcctOwner,UnitNum,LastName1,FirstName1,StorageNum,ContactNum1,ContactNum2,ContactNum3,Email1,Email2,Email3,Email4,ParkingSpot1,ParkingSpot2")] Resident resident)
        {
            if (id != resident.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(resident);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ResidentExists(resident.ID))
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
            return View(resident);
        }

        // GET: Residents/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var resident = await _context.Residents
                .FirstOrDefaultAsync(m => m.ID == id);
            if (resident == null)
            {
                return NotFound();
            }

            return View(resident);
        }

        // POST: Residents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var resident = await _context.Residents.FindAsync(id);
            _context.Residents.Remove(resident);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ResidentExists(int id)
        {
            return _context.Residents.Any(e => e.ID == id);
        }
    }
}
