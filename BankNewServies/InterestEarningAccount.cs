using classes.OpenBankAccount;

namespace classes.BankNewServies
{

    public class InterestEarningAccount : BankAccount
    {
        public InterestEarningAccount(string name, decimal initialBalance) : base(name, initialBalance) { }
        public override void PerformMonthEndTransaction()
        {
            if (Balance > 500m)
            {
                decimal interes = Balance * 0.5m;
                MakeDeposit(interes, DateTime.Now, "Apply monthly interest");
            }
        }
    }
}
