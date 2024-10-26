using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using scopeAgency.Models;
using scopeAgency.Services;
using System.Threading.Tasks;

namespace scopeAgency.Controllers
{
    public class UnitsController : Controller
    {
        private readonly IUnitService _unitService;

        public UnitsController(IUnitService unitService)
        {
            _unitService = unitService;
        }

        // GET: units1
        public async Task<IActionResult> Index()
        {
            var units = await _unitService.GetAllUnitsAsync();
            return View(units);
        }

        // GET: units1/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var unit = await _unitService.GetUnitByIdAsync(id.Value);
            if (unit == null)
            {
                return NotFound();
            }

            return View(unit);
        }

        // GET: units1/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: units1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("unitNo,unitName")] unit unit)
        {
            if (ModelState.IsValid)
            {
                await _unitService.CreateUnitAsync(unit);
                return RedirectToAction(nameof(Index));
            }
            return View(unit);
        }

        // GET: units1/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var unit = await _unitService.GetUnitByIdAsync(id.Value);
            if (unit == null)
            {
                return NotFound();
            }
            return View(unit);
        }

        // POST: units1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("unitNo,unitName")] unit unit)
        {
            if (id != unit.unitNo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _unitService.UpdateUnitAsync(unit);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await _unitService.UnitExistsAsync(unit.unitNo))
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
            return View(unit);
        }

        // GET: units1/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var unit = await _unitService.GetUnitByIdAsync(id.Value);
            if (unit == null)
            {
                return NotFound();
            }

            return View(unit);
        }

        // POST: units1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _unitService.DeleteUnitAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
