namespace FirstBank.Model
{
    public class AccountManager
    {
        private readonly IInterestRateService _interestRateService;

        public AccountManager(IInterestRateService interestRateService)
        {
            _interestRateService = interestRateService;
        }

        public void TransferFunds(Account sourceAccount, Account destinationAccount, decimal amount)
        {
            sourceAccount.Withdraw(amount);
            destinationAccount.Deposit(amount);
        }

        public void ApplyInterest(Account account)
        {
            var rate = _interestRateService.GetCurrentRate();
            account.Deposit(account.Balance * rate);
        }
    }
}