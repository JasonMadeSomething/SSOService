namespace SSOService.Models.Responses
{
    public class LoginResponse
    {
        public int StatusCode { get; set; }
        public string Token { get; set; }
        public int ExpiresIn { get; set; }
    }
}
