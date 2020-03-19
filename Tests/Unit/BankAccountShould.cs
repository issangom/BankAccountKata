using BankAccountKata.Application.Modules;
using NUnit.Framework;
using System;
using System.Linq;

namespace BankAccountKata.Tests.Unit
{
    [TestFixture]
    class BankAccountShould
    {
        [Test]
        public void Deposit()
        {
         var bankAccount = new BankAccount();
            bankAccount.Deposit(1000, new DateTime(2020, 08, 01));
            bankAccount.Deposit(600, new DateTime(2020, 08, 10));
            var transactions = bankAccount.GetTransactions();

            Assert.That(transactions.First(), Is.EqualTo(new Transaction(600, new DateTime(2020, 08, 10),1600)));
            Assert.That(transactions.Last(), Is.EqualTo(new Transaction(1000, new DateTime(2020, 08, 01), 1000)));
        }
        [Test]
        public void Withdraw()
        {
            var bankAccount = new BankAccount();
            bankAccount.Withdraw(1000, new DateTime(2020, 08, 01));
            bankAccount.Withdraw(600, new DateTime(2020, 08, 10));
            var transactions = bankAccount.GetTransactions();

            Assert.That(transactions.First(), Is.EqualTo(new Transaction(-600, new DateTime(2020, 08, 10), -1600)));
            Assert.That(transactions.Last(), Is.EqualTo(new Transaction(-1000, new DateTime(2020, 08, 01), -1000)));
        }
        

        private bool IsEqual(string[] statement, string[] expectedStatement)
        {
            for (int i = 0; i < statement.Length; i++)
            {
                if (statement[i] != expectedStatement[i])
                {
                    return false;
                }
            }
            return true;
        }
    }
}
