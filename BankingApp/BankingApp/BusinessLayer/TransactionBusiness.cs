using BankingApp.DataAccessLayer.Repositories;

namespace BankingApp.BusinessLayer
{
    public class TransactionBusiness
    {
        private readonly TransactionRepository _transactionRepo;

        public TransactionBusiness(TransactionRepository transactionRepo)
        {
            _transactionRepo = transactionRepo;
        }

        public async Task<bool> Withdraw(string cardNumber, string pin, decimal amount)
        {
            return await _transactionRepo.WithdrawAsync(cardNumber, pin, amount);
        }
    }
}
