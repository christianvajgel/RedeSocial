using RedeSocial.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace RedeSocial.Services.Account
{
    public class AccountService : IAccountService, IAccountIdentityManager
    {
        private IAccountRepository AccountRepository { get; set; }

        public AccountService(IAccountRepository accountRepository) 
        {
            this.AccountRepository = accountRepository;
        }
    }
}
