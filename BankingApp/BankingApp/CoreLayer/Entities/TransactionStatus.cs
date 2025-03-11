using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BankingApp.CoreLayer.Entities
{
    public enum TransactionStatus
    {
        [BsonRepresentation(BsonType.String)]
        Success,
        [BsonRepresentation(BsonType.String)]
        Failed
    }
}
