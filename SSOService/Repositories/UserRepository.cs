using MongoDB.Driver;
using SSOService.Models;
using SSOService.Repositories.Interfaces;
using SSOService.Services;

namespace SSOService.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IMongoCollection<User> _usersCollection;

        public UserRepository(MongoService mongoService)
        {
            _usersCollection = mongoService.GetUserCollection();
        }

        public async Task<User?> GetUserByIdAsync(string userId)
        {
            return await _usersCollection.Find(u => u.Id == userId).FirstOrDefaultAsync();
        }

        public async Task<User?> GetUserByUsernameAsync(string username) // New method
        {
            return await _usersCollection.Find(u => u.Username == username).FirstOrDefaultAsync();
        }
        public async Task CreateUserAsync(User user)
        {
            try
            {
                await _usersCollection.InsertOneAsync(user);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error creating user: {ex.Message}");
                throw;
            }
        }



        public async Task UpdateUserAsync(User user)
        {
            var filter = Builders<User>.Filter.Eq(u => u.Id, user.Id);
            await _usersCollection.ReplaceOneAsync(filter, user);
        }
    }
}
