using BankAccountKata.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BankAccountKata.Application.Modules
{
    public class BankAccount : IBankAccount
    {
        private IList<InternalTransaction> _records = new List<InternalTransaction>();
        public void Deposit(int amount, DateTime depositDate)
        {
            _records.Add(new InternalTransaction(amount, depositDate));
        }
        public void Withdraw(int amount, DateTime depositDate)
        {
            _records.Add(new InternalTransaction(-1*amount, depositDate));
        }
        public IList<Transaction> GetTransactions()
        {
            var transactions = new List<Transaction>();
            _records.Reverse();
            int balance = 0;
            foreach (var record in _records)
            {
                balance += record.Amount;
                transactions.Add(new Transaction(record.Amount, record.Date,balance));
            }
            return transactions.OrderByDescending(d=>d.Date).ToList(); ;

        }
    }
}