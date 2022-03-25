using MongoDB.Driver;
using AlphaOmegaAppServiceAPI.Models;
using Microsoft.Extensions.Configuration;

namespace AlphaOmegaAppServiceAPI.Services
{
    public class MongoService
    {
        private static MongoClient _client;
        private IConfiguration _configuration;
    
        public MongoService(IDatabaseSettings settings, IConfiguration configuration)
        {
            _client = new MongoClient(configuration.GetConnectionString("MongoConnectionString"));
            _configuration = configuration;
        }

        public MongoClient GetClient()
        {
            return _client;
        }
    }
}