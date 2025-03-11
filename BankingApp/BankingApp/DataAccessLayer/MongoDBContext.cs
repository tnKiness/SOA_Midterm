using BankingApp.CoreLayer.Entities;
using MongoDB.Driver;

namespace BankingApp.DataAccessLayer
{
    public class MongoDBContext
    {
        private readonly IMongoDatabase _database;

        public MongoDBContext(IConfiguration configuration)
        {
            var client = new MongoClient(configuration.GetConnectionString("MongoDb"));
            _database = client.GetDatabase("BankDB");
        }

        public IMongoCollection<Customer> Customers => _database.GetCollection<Customer>("Customers");
        public IMongoCollection<Card> Cards => _database.GetCollection<Card>("Cards");
        public IMongoCollection<Transaction> Transactions => _database.GetCollection<Transaction>("Transactions");
    }
}
