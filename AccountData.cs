using System;
using System.Collections.Generic;
using System.Text;

namespace WebAdressbookTests
{
    public class AccountData
    {
        public string Username { get; set; }
        public string Password { get; set; }

    public AccountData(string username, string password) 
        {
           Username = username;
           Password = password;
        }
    }
}
