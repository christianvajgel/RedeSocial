using RedeSocial.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace RedeSocial.Services.Account
{
    public class AccountServices : IAccountService
    {
        private IAccountRepository AccountRepository { get; set; }

        public AccountServices(IAccountRepository accountRepository) 
        {
            this.AccountRepository = accountRepository;
        }
    }
}
