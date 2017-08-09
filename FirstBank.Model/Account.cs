namespace FirstBank.Model
{
    public class Account
    {
        public void Deposit(decimal amount)
        {
            Balance += amount;
        }

        public void Withdraw(decimal amount)
        {
            if (amount > Balance)
                throw new InsufficientFundsException(amount, Balance);

            Balance -= amount;
        }

        public decimal Balance { get; private set; }
    }
}