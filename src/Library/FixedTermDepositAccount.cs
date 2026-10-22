using System;
using Ucu.Poo.Dbc;

namespace Ucu.Poo.Dbc.Demo
{
    public class FixedTermDepositAccount : BankAccount
    {
        public int Term { get; }
        public DateTime StartDate { get; }
        public bool IsMature
        {
            get
            {
                return (DateTime.Today - this.StartDate.Date).TotalDays >= this.Term;
            }
        }


        public FixedTermDepositAccount(double initialBalance, int term, DateTime startDate)
            : base(initialBalance)
        {
            this.Term = term;
            this.StartDate = startDate;
        }

        [Requires("IsMature", "Debe estar vencido para retirar")]
        public override void Withdraw(double amount)
        {
            base.Withdraw(amount);
        }

    }
}