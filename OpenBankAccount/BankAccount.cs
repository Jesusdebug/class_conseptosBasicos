namespace classes.OpenBankAccount;
public class BankAccount
{
    private readonly decimal _minimumBalance;
    public string Number { get; }
    public string Owner { get; set; }
    public decimal Balance
    {
        get
        {
            decimal balance = 0;
            foreach (var item in allTransactions)
            {
                balance += item.Amount;
            }
            return balance;
        }
    }
    public BankAccount()
    {

    }
    public BankAccount(string name, decimal initialBalance) : this(name, initialBalance, 0) { }
    public BankAccount(string name, decimal initialBalance, decimal minimumBalace)
    {
        Number = accountNomberSeed.ToString();
        accountNomberSeed++;
        Owner = name;
        _minimumBalance = minimumBalace;
        if (initialBalance > 0)
        {
            MakeDeposit(initialBalance, DateTime.Now, "Inicial Balance");
        }
    }
    public void MakeDeposit(decimal amount, DateTime date, string note)
    {
        if (amount <= 0)
        {
            throw new ArgumentException(nameof(amount), "Amount of deposit be positive");
        }
        var deposit = new Transaction(amount, date, note);
        allTransactions.Add(deposit);
    }
    public void MakeWithDrawal(decimal amount, DateTime date, string note)
    {
        if (amount <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(amount), "Amount Withdrawal must be positive");
        }
        Transaction? overdraftTransaction = CheckWithDrawalLimit(Balance - amount < _minimumBalance);
        Transaction? withdrawal = new(-amount, date, note);
        allTransactions.Add(withdrawal);
        if (overdraftTransaction!=null)
        {
            allTransactions.Add(overdraftTransaction);
        }
        //if (Balance - amount < _minimumBalance)
        //{
        //    throw new InvalidOperationException("No suffcient funds for this withdrawal");
        //}
        //var withdrawal = new Transaction(-amount, date, note);
        //allTransactions.Add(withdrawal);
    }
    protected virtual Transaction? CheckWithDrawalLimit(bool isOverdrawn)
    {
        if (isOverdrawn)
        {
            throw new InvalidOperationException("no suficient funds for this withdrawal");
        }
        else
        {
            return default;
        }
    }

    private static int accountNomberSeed = 1234567890;

    private List<Transaction> allTransactions = new List<Transaction>();
    public string GetAccountHistory()
    {
        var report = new System.Text.StringBuilder();
        decimal balance = 0;
        report.AppendLine("Data\t\tAmount\tBalance\tNote");
        foreach (var transaction in allTransactions)
        {
            balance += transaction.Amount;
            report.AppendLine($"{transaction.Date.ToShortDateString()}\t{transaction.Amount}\t{balance}\t{transaction.Note}");
        }
        return report.ToString();
    }
    public virtual void PerformMonthEndTransaction()
    {

    }
}
