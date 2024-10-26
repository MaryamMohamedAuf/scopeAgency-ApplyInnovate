// Services/IUnitService.cs
using scopeAgency.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace scopeAgency.Services
{
    public interface IUnitService
    {
        Task<IEnumerable<unit>> GetAllUnitsAsync();
        Task<unit> GetUnitByIdAsync(int id);
        Task CreateUnitAsync(unit unit);
        Task UpdateUnitAsync(unit unit);
        Task DeleteUnitAsync(int id);
        Task<bool> UnitExistsAsync(int id);
    }
}
