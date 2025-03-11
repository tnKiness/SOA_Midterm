using BankingApp.BusinessLayer;

namespace BankingApp.ServiceLayer.Services
{
    public class TransactionService
    {
        private readonly TransactionBusiness _transactionBusiness;

        public TransactionService(TransactionBusiness transactionBusiness)
        {
            _transactionBusiness = transactionBusiness;
        }

        public async Task<bool> Withdraw(string cardNumber, string pin, decimal amount)
        {
            return await _transactionBusiness.Withdraw(cardNumber, pin, amount);
        }
    }
}
