using BankingApp.CoreLayer.Entities;
using MongoDB.Driver;

namespace BankingApp.DataAccessLayer.Repositories
{
    public class TransactionRepository
    {
        private readonly IMongoCollection<Transaction> _transactions;
        private readonly IMongoCollection<Card> _cards;

        public TransactionRepository(MongoDBContext dbContext)
        {
            _transactions = dbContext.Transactions;
            _cards = dbContext.Cards;
        }

        public async Task<bool> WithdrawAsync(string cardNumber, string pin, decimal amount)
        {
            var card = await _cards.Find(c => c.CardNumber == cardNumber).FirstOrDefaultAsync();
            if (card == null || card.Pin != pin || card.Balance < amount)
            {
                var failedTransaction = new Transaction
                {
                    CardNumber = cardNumber,
                    Amount = amount,
                    TransactionDate = DateTime.UtcNow,
                    Status = TransactionStatus.Failed,
                };
                await _transactions.InsertOneAsync(failedTransaction);
                return false;
            }

            var update = Builders<Card>.Update.Inc(c => c.Balance, -amount);
            await _cards.UpdateOneAsync(c => c.CardNumber == cardNumber, update);

            var successfulTransaction = new Transaction
            {
                CardNumber = cardNumber,
                Amount = amount,
                TransactionDate = DateTime.UtcNow,
                Status = TransactionStatus.Success,
            };
            await _transactions.InsertOneAsync(successfulTransaction);
            return true;
        }
    }
}
