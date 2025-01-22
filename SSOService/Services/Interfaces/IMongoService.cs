using MongoDB.Driver;
using SSOService.Models;
namespace SSOService.Services.Interfaces
{
    public interface IMongoService
    {
        IMongoCollection<User> GetUserCollection();

    }

}

