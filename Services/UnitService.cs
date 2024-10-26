// Services/UnitService.cs
using Microsoft.EntityFrameworkCore;
using scopeAgency.Data;
using scopeAgency.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace scopeAgency.Services
{
    public class UnitService : IUnitService
    {
        private readonly ApplicationDbContext _context;

        public UnitService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<unit>> GetAllUnitsAsync()
        {
            return await _context.units.ToListAsync();
        }

        public async Task<unit> GetUnitByIdAsync(int id)
        {
            return await _context.units.FirstOrDefaultAsync(u => u.unitNo == id);
        }

        public async Task CreateUnitAsync(unit unit)
        {
            _context.Add(unit);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateUnitAsync(unit unit)
        {
            _context.Update(unit);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteUnitAsync(int id)
        {
            var unit = await GetUnitByIdAsync(id);
            if (unit != null)
            {
                _context.units.Remove(unit);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> UnitExistsAsync(int id)
        {
            return await _context.units.AnyAsync(u => u.unitNo == id);
        }
    }
}
