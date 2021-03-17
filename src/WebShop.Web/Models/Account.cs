namespace WebShop.Web.Models
{
    public class Account
    {
        public Account(decimal balance, string owner)
        {
            Balance = balance;
            Owner = owner;
        }

        public decimal Balance { get; private set; }
        public string Owner { get; init; }

        public void Debit(decimal amount) => Balance += amount;

        public void Charge(decimal amount) => Balance -= amount;
    }

}
