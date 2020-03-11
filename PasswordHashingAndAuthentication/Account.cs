using System;
using System.Collections.Generic;
using System.Text;

namespace PasswordHashingAndAuthentication
{
    class Account
    {
        public List<string> userNames = new List<string>(); // LIST TO STORE USERNAMES (COMPARE LATER)

        public Dictionary<string, User> userInformation = new Dictionary<string, User>(); // SET KEY TO HASH OF USER PASSWORD - USER MUST PUT IN PROPPER PASSWORD TO GET PROPPER HASH TO ACCESS DATA
    }
}
