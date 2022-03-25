using System.Threading.Tasks;
using System.Collections.Generic;
using AlphaOmegaAppServiceAPI.Models;

namespace AlphaOmegaAppServiceAPI.Services
{
    public interface IEventService
    {
        public Task<List<Event>> GetNAsync(int n);
        public Task<Event> GetByIdAsync(string Id);
        public Task CreateAsync(Event item);
        public Task<Event> UpdateAsync(Event item);
        public Task DeleteAsync(string Id);
    }
}
