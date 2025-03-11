using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BankingApp.CoreLayer.Entities
{
    public class Card
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = string.Empty;

        [BsonElement("CardNumber")]
        public string CardNumber { get; set; } = string.Empty;

        [BsonElement("CustomerId")]
        public string CustomerId { get; set; } = string.Empty;

        [BsonElement("Pin")]
        public string Pin { get; set; } = string.Empty;

        [BsonElement("Balance")]
        public decimal Balance { get; set; } = 0;

        [BsonElement("CreatedAt")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
