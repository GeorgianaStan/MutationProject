using System;

namespace FirstBank.Model
{
    public class InsufficientFundsException : Exception
    {
        public InsufficientFundsException(decimal amountRequested, decimal accountBalance)
        {
            AmountRequested = amountRequested;
            AccountBalance = accountBalance;
        }
        
        public decimal AmountRequested { get; private set; }

        public decimal AccountBalance { get; private set; }
    }
}