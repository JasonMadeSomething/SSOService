using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SSOService.Models
{
    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("username")]
        public string Username { get; set; }

        [BsonElement("email")]
        public string Email { get; set; }

        [BsonElement("passwordHash")]
        public string PasswordHash { get; set; } // Store hashed password securely
        [BsonElement("role")]
        public string Role { get; set; } // Admin, Paid, Free
        [BsonElement("freeUsageCount")]
        public int FreeUsageCount { get; set; } // Track free users' usage
    }
}

