using classes;
using classes.BankNewServies;
using classes.OpenBankAccount;

BankAccount acount = new BankAccount();

acount.MakeDeposit(100, DateTime.Now, "Freind paid me back");
Console.WriteLine(acount.Balance);
try
{
    acount.MakeWithDrawal(50, DateTime.Now, "Rent payment");
    Console.WriteLine(acount.Balance);
}
catch (InvalidOperationException e)
{
    Console.WriteLine("Exception coght trying to overdraw");
    Console.WriteLine(e.ToString());
}
Console.WriteLine(acount.GetAccountHistory());
//test of aplication
//BankAccount invalidAccount;
//try
//{
//    invalidAccount = new BankAccount("invelid", -55);
//}
//catch (ArgumentOutOfRangeException e)
//{
//    Console.WriteLine("Exception caught creating account with negative balance");
//    Console.WriteLine(e.ToString());
//}
var giftCard = new GiftCardAcount("Gift card", 100, 50);
giftCard.MakeWithDrawal(20, DateTime.Now, "get expensive coffee");
giftCard.MakeWithDrawal(20, DateTime.Now, "buy groceries");
giftCard.PerformMonthEndTransaction();
giftCard.MakeDeposit(27.50m, DateTime.Now, "Add some addtional spending money");
Console.WriteLine(giftCard.GetAccountHistory());
var saving = new InterestEarningAccount("Saving accont", 10000);
saving.MakeDeposit(750, DateTime.Now, "save some money");
saving.MakeDeposit(1250, DateTime.Now, "Add more savings");
saving.MakeWithDrawal(250, DateTime.Now, "Needed to apy monthly bills");
saving.PerformMonthEndTransaction();
Console.WriteLine(saving.GetAccountHistory());

var lineOfCredit = new LineOfCreditAccount("Line of credit", 0, 2000);
lineOfCredit.MakeWithDrawal(1000m, DateTime.Now, "Take out monthly advance");
lineOfCredit.MakeWithDrawal(50m, DateTime.Now, "pay back small amout");
lineOfCredit.MakeWithDrawal(5000m, DateTime.Now, "Emergency founds for repairs");
lineOfCredit.MakeWithDrawal(150m, DateTime.Now, "Partial restauration on repairs");
lineOfCredit.PerformMonthEndTransaction();
Console.WriteLine(lineOfCredit.GetAccountHistory());

