using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BankingApp.CoreLayer.Entities
{
    public class Transaction
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = string.Empty;

        [BsonElement("CardNumber")]
        public string? CardNumber { get; set; }

        [BsonElement("Amount")]
        public decimal Amount { get; set; }

        [BsonElement("TransactionDate")]
        public DateTime TransactionDate { get; set; } = DateTime.UtcNow;

        [BsonElement("Status")]
        public TransactionStatus Status { get; set; } = TransactionStatus.Failed;
    }
}
