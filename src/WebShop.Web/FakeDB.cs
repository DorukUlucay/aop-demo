using System.Collections.Generic;
using WebShop.Web.Models;

namespace WebShop.Web
{
    public class FakeDB
    {
        public static List<Account> Accounts { get; set; }

        FakeDB() {

            Accounts.Add(new Account(100, "Doruk"));
            Accounts.Add(new Account(200, "Rıza"));

        }

        static FakeDB _instance;

        public static FakeDB Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new FakeDB();
                }

                return _instance;
            }
        }
    }
}
