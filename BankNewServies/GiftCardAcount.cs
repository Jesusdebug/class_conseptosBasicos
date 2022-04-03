using classes.OpenBankAccount;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace classes.BankNewServies
{
    public class GiftCardAcount : BankAccount
    {
        private readonly decimal _monthDeposit = 0;
        public GiftCardAcount(string name, decimal initialBalance, decimal monthDeposit = 0) : base(name, initialBalance)
        {
            _monthDeposit = monthDeposit;
        }
        public override void PerformMonthEndTransaction()
        {
            if (_monthDeposit != 0)
            {
                MakeDeposit(_monthDeposit, DateTime.Now, "Add monthly deposit");
            }
        }
    }
}
