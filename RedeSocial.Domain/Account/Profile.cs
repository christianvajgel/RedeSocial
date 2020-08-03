using System;
using System.Collections.Generic;
using System.Text;

namespace RedeSocial.Domain.Account
{
    public class Profile
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public List<Account> Accounts { get; set; }
        //public Account Account { get; set; }
        //public Guid AccountId { get; set; }
    }
}
