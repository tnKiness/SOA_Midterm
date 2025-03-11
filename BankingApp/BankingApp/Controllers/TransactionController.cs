using BankingApp.ServiceLayer.Services;
using Microsoft.AspNetCore.Mvc;

namespace BankingApp.Controllers
{
    [ApiController]
    [Route("api/[controller]/transactions")]
    public class TransactionController : ControllerBase
    {
        private readonly TransactionService _transactionService;

        public TransactionController(TransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        [HttpPost("withdraw")]
        public async Task<IActionResult> Withdraw([FromBody] WithdrawRequest request)
        {
            bool success = await _transactionService.Withdraw(request.CardNumber, request.Pin, request.Amount);
            if (!success)
            {
                return BadRequest("Withdrawal failed due to insufficent balance or invalid card.");
            }
            return Ok("Withdrawal successful.");
        }
    }

    public class WithdrawRequest
    {
        public required string CardNumber { get; set; }
        public required string Pin { get; set; }
        public decimal Amount { get; set; }
    }
}
