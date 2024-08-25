using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using ContaComException.Entities.Exceptions;

namespace ContaComException.Entities
{
    internal class Account
    {
        public int Number { get; set; }

        public string Holder { get; set; }

        public double Balance { get; protected set; }

        public double WithDrawLimit { get; set; }

        public Account() { }

        public Account(int number, string holder, double balance, double withDrawLimit)
        {
            Number = number;
            Holder = holder;
            Balance = balance;
            WithDrawLimit = withDrawLimit;
        }

        void Deposit(double amount)
        {
           
            Balance += amount;
        }

        public void Withdraw(double amount)
        {


            ExceedLimit(amount);
            InsufficientBalance(amount);
            Balance -= amount;
            DisplayInfo();
        }

        private void InsufficientBalance(double amount)
        {
            if (Balance < amount)
            {
                throw new DomainException("Insufficient account balance");
            }

        }

        private void ExceedLimit(double amount)
        {

            if (WithDrawLimit < amount)
            {
                throw new DomainException("The amount exceeds withdraw limit");
            }

        }

        public void DisplayInfo()
        {
            Console.WriteLine($"New Balance: {Balance:C}");
        }
    }
}
