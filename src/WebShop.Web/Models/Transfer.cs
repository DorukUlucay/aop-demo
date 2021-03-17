namespace WebShop.Web.Models
{
    public class Transfer
    {
        public Transfer(Account transferringAccount, Account receivingAccount, decimal amount)
        {
            TransferringAccount = transferringAccount;
            ReceivingAccount = receivingAccount;
            Amount = amount;
        }

        public Account TransferringAccount { get; }
        public Account ReceivingAccount { get; }
        public decimal Amount { get; }
    }
}
