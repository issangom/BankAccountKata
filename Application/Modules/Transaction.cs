using System;

namespace BankAccountKata.Application.Modules
{
    public class Transaction
    {
        public DateTime Date { get; private set; }
        public int Amount { get; private set; }
        public int Balance { get; private set; }

        public Transaction(int amount,DateTime transactionDate, int balance)
        {
            Amount = amount;
            Date = transactionDate;
            Balance = balance;
        }
        // override object.Equals
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            return Equals((Transaction)obj);
        }
        public  bool Equals(Transaction obj)
        {
            return Date.Equals(obj.Date) && Amount == obj.Amount && Balance == obj.Balance;
        }

        // override object.GetHashCode
        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Date.GetHashCode();
                hashCode = (hashCode * 397) ^ Amount;
                hashCode = (hashCode * 397) ^ Balance;
                return hashCode;
            }
            
        }
        
    }
}