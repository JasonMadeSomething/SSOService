using SSOService.Services.Interfaces;
using SSOService.Repositories.Interfaces;
using SSOService.Models;
namespace SSOService.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly ILogger<UserService> _logger;

        public UserService(IUserRepository userRepository, ILogger<UserService> logger)
        {
            _userRepository = userRepository;
            _logger = logger;
        }
        public async Task<User?> GetUserByIdAsync(string userId)
        {
            return await _userRepository.GetUserByIdAsync(userId);
        }

        public async Task<User?> GetUserByUsernameAsync(string username)
        {
            try
            {
                return await _userRepository.GetUserByUsernameAsync(username);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving user by username: {Username}", username);
                return null;
            }
        }

        public async Task CreateUserAsync(User user)
        {
            try
            {
                await _userRepository.CreateUserAsync(user);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating user: {Username}", user.Username);
                throw;
            }
        }


        public async Task<bool> CanFreeUserProceedAsync(string userId)
        {
            var user = await _userRepository.GetUserByIdAsync(userId);
            if (user == null) return false;

            if (user.Role == "Free" && user.FreeUsageCount <= 0)
            {
                return false; // Free user has no remaining usage
            }

            // Deduct usage count
            if (user.Role == "Free")
            {
                user.FreeUsageCount--;
                await _userRepository.UpdateUserAsync(user);
            }

            return true;
        }
    }

}
