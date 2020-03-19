using BankAccountKata.Application.Interfaces;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;

namespace BankAccountKata.Application.Modules

{
    public  class BankAccountController
    {
        private IConsolWrapper  _consolWrapper;
        private ICalendar       _calendarWrapper;
        private IBankAccount    _bankAccount;

        public BankAccountController(IConsolWrapper consolWrapper, ICalendar calendarWrapper, IBankAccount bankAccount)
        {
            _consolWrapper = consolWrapper;
            _calendarWrapper = calendarWrapper;
            _bankAccount = bankAccount;
        }
        public void Deposit(int amount)
        {
            _bankAccount.Deposit(amount, _calendarWrapper.GeteDate());

        }
        public void Withdraw(int amount)
        {
            _bankAccount.Withdraw(amount, _calendarWrapper.GeteDate());
        }

        internal void PrintStatement()
        {
            var transactions = _bankAccount.GetTransactions();
            _consolWrapper.Write(BuildStatement(transactions));
            
        }

        private string[] BuildStatement(IList<Transaction> transactions)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("fr-FR");

            var ListStatement = new List<string> { "Date | Amount | Balance" };
            foreach (var transaction in transactions)
            {
                ListStatement.Add(string.Join(" | ", transaction.Date.ToShortDateString(), transaction.Amount, transaction.Balance));
            }
            return ListStatement.ToArray();
        }
    }
   
}