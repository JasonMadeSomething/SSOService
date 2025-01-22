namespace SSOService.Models
{
    public class ClientConfig
    {
        public string Audience { get; set; }
        public List<string> Scopes { get; set; }
    }
}
