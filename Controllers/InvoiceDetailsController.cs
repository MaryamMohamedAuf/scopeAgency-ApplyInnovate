using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using scopeAgency.Data;
using scopeAgency.Models;

namespace scopeAgency.Controllers
{
    public class InvoiceDetailsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public InvoiceDetailsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: invoiceDetails1
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.invoiceDetails.Include(i => i.unit);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: invoiceDetails1/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.invoiceDetails == null)
            {
                return NotFound();
            }

            var invoiceDetail = await _context.invoiceDetails
                .Include(i => i.unit)
                .FirstOrDefaultAsync(m => m.id == id);
            if (invoiceDetail == null)
            {
                return NotFound();
            }

            return View(invoiceDetail);
        }

        // GET: invoiceDetails1/Create
        public IActionResult Create()
        {
            ViewData["unitNo"] = new SelectList(_context.units, "unitNo", "unitNo");
            return View();
        }

        // POST: invoiceDetails1/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,productName,price,quantity,expiryDate,unitNo")] invoiceDetail invoiceDetail)
        {
           
                _context.Add(invoiceDetail);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            
            ViewData["unitNo"] = new SelectList(_context.units, "unitNo", "unitNo", invoiceDetail.unitNo);
            return View(invoiceDetail);
        }

        // GET: invoiceDetails1/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.invoiceDetails == null)
            {
                return NotFound();
            }

            var invoiceDetail = await _context.invoiceDetails.FindAsync(id);
            if (invoiceDetail == null)
            {
                return NotFound();
            }
            ViewData["unitNo"] = new SelectList(_context.units, "unitNo", "unitNo", invoiceDetail.unitNo);
            return View(invoiceDetail);
        }

        // POST: invoiceDetails1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,productName,price,quantity,expiryDate,unitNo")] invoiceDetail invoiceDetail)
        {
            if (id != invoiceDetail.id)
            {
                return NotFound();
            }

                try
                {
                    _context.Update(invoiceDetail);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!invoiceDetailExists(invoiceDetail.id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            
            ViewData["unitNo"] = new SelectList(_context.units, "unitNo", "unitNo", invoiceDetail.unitNo);
            return View(invoiceDetail);
        }

        // GET: invoiceDetails1/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.invoiceDetails == null)
            {
                return NotFound();
            }

            var invoiceDetail = await _context.invoiceDetails
                .Include(i => i.unit)
                .FirstOrDefaultAsync(m => m.id == id);
            if (invoiceDetail == null)
            {
                return NotFound();
            }

            return View(invoiceDetail);
        }

        // POST: invoiceDetails1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.invoiceDetails == null)
            {
                return Problem("Entity set 'ApplicationDbContext.invoiceDetails'  is null.");
            }
            var invoiceDetail = await _context.invoiceDetails.FindAsync(id);
            if (invoiceDetail != null)
            {
                _context.invoiceDetails.Remove(invoiceDetail);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool invoiceDetailExists(int id)
        {
          return (_context.invoiceDetails?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
