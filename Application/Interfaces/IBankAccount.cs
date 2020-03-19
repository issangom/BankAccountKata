using BankAccountKata.Application.Modules;
using System;
using System.Collections.Generic;

namespace BankAccountKata.Application.Interfaces
{
    public interface IBankAccount
    {
        void Deposit(int amount, DateTime depositDate);
        void Withdraw(int amount, DateTime WithdrawDate);
        IList<Transaction> GetTransactions();
    }
}