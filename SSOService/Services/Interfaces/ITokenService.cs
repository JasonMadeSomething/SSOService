using SSOService.Models;

namespace SSOService.Services.Interfaces
{
    public interface ITokenService
    {
        string GenerateToken(User user);
    }
}
