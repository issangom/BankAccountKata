using System;

namespace BankAccountKata.Application.Modules
{
    public class InternalTransaction
    {
        public int Amount { get; private set; }
        public DateTime Date { get; private set; }

        public InternalTransaction(int amount, DateTime depositDate)
        {
            Amount = amount;
            Date = depositDate;
        }
        
}
}