using WebShop.Web.Exceptions;
using WebShop.Web.Models;

namespace WebShop.Web.Services
{
    public class AOPTransferService : ITransferService
    {
        public void Transfer(Transfer transfer)
        {
            ValidateBalance();

            transfer.TransferringAccount.Charge(transfer.Amount);
            transfer.ReceivingAccount.Debit(transfer.Amount);

            void ValidateBalance()
            {
                if (transfer.Amount > transfer.TransferringAccount.Balance)
                    throw new NotEnoughBalanceException($"Sending accounts balance is not enough. Account name: {transfer.TransferringAccount.Owner}, Balance : {transfer.TransferringAccount.Balance}, Amount: {transfer.Amount}");
            }
        }
    }
}
