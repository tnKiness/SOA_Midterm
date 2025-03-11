using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BankingApp.CoreLayer.Entities
{
    public class Customer
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = string.Empty;

        [BsonElement("Name")]
        public string Name { get; set; } = string.Empty;

        [BsonElement("CitizenNumber")]
        public string CitizenNumber { get; set; } = string.Empty;
    }
}
