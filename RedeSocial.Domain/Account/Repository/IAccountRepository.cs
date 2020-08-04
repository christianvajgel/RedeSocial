using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RedeSocial.Domain.Repository
{
    public interface IAccountRepository
    {
        Task <Domain.Account.Account> GetAccountByEmailPassword(string email, string password);
        Task <Domain.Account.Account> GetAccountByUserNamePassword(string username, string password);
    }
}
