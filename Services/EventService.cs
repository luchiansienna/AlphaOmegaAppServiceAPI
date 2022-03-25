using MongoDB.Driver;
using System.Threading.Tasks;
using System.Collections.Generic;
using AlphaOmegaAppServiceAPI.Models;

namespace AlphaOmegaAppServiceAPI.Services
{
    public class EventService : IEventService
    {
        private readonly IMongoCollection<Event> _events;        

        public EventService(MongoService mongo, IDatabaseSettings settings)
        {
            var db = mongo.GetClient().GetDatabase(settings.DatabaseName);
            _events = db.GetCollection<Event>(settings.ProductCollectionName);
        }

        public Task<List<Event>> GetNAsync(int n)
        {
            return  _events.Find(product => true).Limit(n).ToListAsync();
        }

        public Task<Event> GetByIdAsync(string Id)
        {
            return _events.Find(p => p.Id == Id).FirstOrDefaultAsync();
        }

        public Task CreateAsync(Event product)
        {
            return _events.InsertOneAsync(product);
        }

        public Task<Event> UpdateAsync(Event update)
        {
            return _events.FindOneAndReplaceAsync(
                Builders<Event>.Filter.Eq(p => p.Id, update.Id), 
                update, 
                new FindOneAndReplaceOptions<Event> { ReturnDocument = ReturnDocument.After });
        }

        public Task DeleteAsync(string Id)
        {
            return _events.DeleteOneAsync(p => p.Id == Id);
        }
    }
}