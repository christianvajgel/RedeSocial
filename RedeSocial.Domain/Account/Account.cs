
using RedeSocial.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;

namespace RedeSocial.Domain.Account
{
    public class Account : IdentityUser, IAccountRepository
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime DtBirthday { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
