﻿using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RedeSocial.Domain.Repository;
using RedeSocial.Repository.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RedeSocial.Repository.Account
{
    public class AccountRepository : IUserStore<Domain.Account.Account>, IAccountRepository
    {
        private bool disposedValue;
        private RedeSocialContext Context { get; set; }

        public AccountRepository(RedeSocialContext redeSocialContext)
        {
            this.Context = redeSocialContext;
        }

        public async Task<IdentityResult> CreateAsync(Domain.Account.Account user, CancellationToken cancellationToken)
        {
            this.Context.Accounts.Add(user);
            await this.Context.SaveChangesAsync();
            return IdentityResult.Success;
        }

        public async Task<IdentityResult> DeleteAsync(Domain.Account.Account user, CancellationToken cancellationToken)
        {
            this.Context.Accounts.Remove(user);
            await this.Context.SaveChangesAsync();
            return IdentityResult.Success;
        }

        public Task<Domain.Account.Account> FindByIdAsync(string userId, CancellationToken cancellationToken)
        {
            return this.Context.Accounts.FirstOrDefaultAsync(x => x.Id == new Guid(userId));
        }

        public Task<Domain.Account.Account> FindByNameAsync(string normalizedUserName, CancellationToken cancellationToken)
        {
            return this.Context.Accounts.FirstOrDefaultAsync(x => x.Id == new Guid(normalizedUserName));
        }

        public Task<string> GetNormalizedUserNameAsync(Domain.Account.Account user, CancellationToken cancellationToken)
        {
            //return Task.FromResult(user.Email);
            return Task.FromResult(user.UserName);
        }

        public Task<string> GetUserIdAsync(Domain.Account.Account user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.Id.ToString());
        }

        public Task<string> GetUserNameAsync(Domain.Account.Account user, CancellationToken cancellationToken)
        {
            //return Task.FromResult(user.Email.ToString());
            return Task.FromResult(user.UserName.ToString());
        }

        public Task SetNormalizedUserNameAsync(Domain.Account.Account user, string normalizedName, CancellationToken cancellationToken)
        {
            //user.Email = normalizedName;
            user.UserName = normalizedName;
            return Task.CompletedTask;
        }

        public Task SetUserNameAsync(Domain.Account.Account user, string userName, CancellationToken cancellationToken)
        {
            //user.Email = userName;
            user.UserName = userName;
            return Task.CompletedTask;
        }

        public async Task<IdentityResult> UpdateAsync(Domain.Account.Account user, CancellationToken cancellationToken)
        {
            var accountToUpdate = await this.Context.Accounts.AsNoTracking().FirstOrDefaultAsync(x => x.Id == user.Id);

            accountToUpdate = user;
            this.Context.Entry(accountToUpdate).State = EntityState.Modified;

            this.Context.Accounts.Add(accountToUpdate);
            await this.Context.SaveChangesAsync();

            return IdentityResult.Success;
        }

        public Task<Domain.Account.Account> GetAccountByEmailPassword(string email, string password)
        {
            return Task.FromResult(this.Context.Accounts
                                                .Include(x => x.Role)
                                                .FirstOrDefault(x => x.Email == email && x.Password == password));
        }

        public Task<Domain.Account.Account> GetAccountByUserNamePassword(string username, string password)
        {
            return Task.FromResult(this.Context.Accounts
                                                .Include(x => x.Role)
                                                .FirstOrDefault(x => x.UserName == username && x.Password == password));
        }

        #region Dispose Implementation
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~AccountRepository()
        // {
        //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
