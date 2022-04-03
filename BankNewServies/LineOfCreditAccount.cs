using classes.OpenBankAccount;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace classes.BankNewServies
{
    public class LineOfCreditAccount : BankAccount
    {
        public LineOfCreditAccount(string name, decimal initialBalance, decimal creditLimit) : base(name, initialBalance, -creditLimit) { }
        public override void PerformMonthEndTransaction()
        {
            if (Balance < 0)
            {
                decimal interst = -Balance * 0.07m;
                MakeWithDrawal(interst, DateTime.Now, "Charge monthly interest");
            }
        }
        protected override Transaction? CheckWithDrawalLimit(bool isOverdrawn) =>
            isOverdrawn
            ? new Transaction(-20, DateTime.Now, "Apply overdraft fee")
            : default;

    }
}
