using SSOService.Models;

namespace SSOService.Services.Interfaces
{
    public interface IUserService
    {
        Task<User?> GetUserByIdAsync(string userId);
        Task<User?> GetUserByUsernameAsync(string username);
        Task CreateUserAsync(User user);
        Task<bool> CanFreeUserProceedAsync(string userId);
    }
}

