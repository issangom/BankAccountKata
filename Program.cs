using BankAccountKata.Application.Modules;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BankAccountKata
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("fr-FR");
            var bankAccount = new BankAccount();
            bankAccount.Deposit(1000, new DateTime(2020, 08, 01));
            bankAccount.Withdraw(600, new DateTime(2020, 08, 10));
            var transactions = bankAccount.GetTransactions();
            PrintStatments(bankAccount.GetTransactions());
        }

        public static void PrintStatments(IList<Transaction> transactions)
        {
            var report = new StringBuilder();
            Console.WriteLine("Date | Amount | Balance");
            foreach (var transaction in transactions)
            {
                report.Insert(0,
                    string.Format("{0} | {1} | {2}" + Environment.NewLine,
                    transaction.Date,
                    transaction.Amount,
                    transaction.Balance));
            }
            Console.Write(report.ToString());
            Console.ReadKey();
        }
    }
}
