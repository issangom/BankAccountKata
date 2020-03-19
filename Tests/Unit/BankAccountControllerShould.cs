using BankAccountKata.Application.Interfaces;
using BankAccountKata.Application.Modules;
using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace BankAccountKata.Tests.Unit
{
    [TestFixture]
    public class BankAccountControllerShould
    {
       private ICalendar calendarWrapper;
       private IConsolWrapper consolWrapper;
       private BankAccountController bankAccountController;
       private IBankAccount bankAccount;

       [SetUp]
        public void Setup ()
        {
            consolWrapper = Substitute.For<IConsolWrapper>();
            calendarWrapper = Substitute.For<ICalendar>();
            bankAccount = Substitute.For<IBankAccount>();
            bankAccountController = new BankAccountController(consolWrapper, calendarWrapper, bankAccount);
        }
        [Test]
        public void Deposit()
        {
            var depositDate = new DateTime(2020, 01, 08);
            calendarWrapper.GeteDate().Returns(depositDate);
            bankAccountController.Deposit(1000);
            bankAccount.Received().Deposit(Arg.Is<int>(x => x == 1000), Arg.Is<DateTime>(d => d == depositDate));
        }
        [Test]
        public void Withdraw()
        {
            var WithDrawDate = new DateTime(2020, 03, 08);
            calendarWrapper.GeteDate().Returns(WithDrawDate);
            bankAccountController.Withdraw(600);
            bankAccount.Received().Withdraw(Arg.Is<int>(x => x == 600), Arg.Is<DateTime>(d => d == WithDrawDate));
        }

        [Test]
        public void PrintStatement()
        {
            
            var expectedTransactions = new List<Transaction>()
            {
                new Transaction(1000,new DateTime(2020, 08, 01),1000)
            };
            bankAccount.GetTransactions().Returns(expectedTransactions);
            bankAccountController.PrintStatement();
            string[] expectedStatement = {"Date | Amount | Balance","01/08/2020 | 1000 | 1000"};
            consolWrapper.Received().Write(Arg.Is<string[]>(x => IsEqual(x , expectedStatement)));
        }

        private bool IsEqual(string[] statement, string[] expectedStatement)
        {
            for (int i = 0; i < statement.Length; i++)
            {
                if (statement[i]!= expectedStatement[i])
                {
                    return false;
                }
            }
            return true;
        }
    }
}
