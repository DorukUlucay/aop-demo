using System;

namespace WebShop.Web.Exceptions
{
    public class NotEnoughBalanceException : Exception
    {
        public NotEnoughBalanceException() : base()
        {
        }

        public NotEnoughBalanceException(string message) : base(message)
        {
        }

        public NotEnoughBalanceException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
