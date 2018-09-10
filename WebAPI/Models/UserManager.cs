using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class UserManager
    {
        private AuthenticationDemoEntities _Context;

        public UserManager()
        {
            _Context = new AuthenticationDemoEntities();
        }

        public bool ValidateUser(string userName, string Password)
        {
            var result = _Context.usermasters.SingleOrDefault(x => x.UserName.Equals(userName, StringComparison.OrdinalIgnoreCase) && x.Password == Password);

            return result != null ? true : false;
        }
    }
}