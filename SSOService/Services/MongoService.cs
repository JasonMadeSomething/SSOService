using MongoDB.Driver;
using Microsoft.Extensions.Configuration;
using SSOService.Models;
using SSOService.Services.Interfaces;
namespace SSOService.Services
{
    public class MongoService : IMongoService
    {
        private readonly IMongoDatabase _database;

        public MongoService(IConfiguration configuration)
        {
            var connectionString = configuration["MongoDB:ConnectionString"];
            var databaseName = configuration["MongoDB:DatabaseName"];

            var client = new MongoClient(connectionString);
            _database = client.GetDatabase(databaseName);
        }
        public IMongoCollection<User> GetUserCollection()
        {
            return _database.GetCollection<User>("Users");
        }
    }
}

