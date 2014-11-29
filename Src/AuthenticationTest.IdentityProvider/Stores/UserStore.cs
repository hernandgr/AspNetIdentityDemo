using AuthenticationTest.Entities;
using AuthenticationTest.Services;
using AuthenticationTest.Services.Interfaces;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AuthenticationTest.IdentityProvider.Stores
{
    public class UserStore : IUserStore<User>,
                             IUserPasswordStore<User>,
                             IUserRoleStore<User>
    {
        private readonly IUserService _userService;

        public UserStore()
        {
            _userService = new UserService();
        }

        #region IUserStore members

        public Task CreateAsync(User user)
        {
            IdentityResult result;
            try
            {
                _userService.CreateUser(user);
                result = IdentityResult.Success;
            }
            catch (Exception ex)
            {
                result = IdentityResult.Failed(ex.Message);
            }

            return Task.FromResult<IdentityResult>(result);
        }

        public Task DeleteAsync(User user)
        {
            throw new NotImplementedException();
        }

        public Task<User> FindByIdAsync(string userId)
        {
            //Implementar
            return Task.FromResult<User>(null);;
        }

        public Task<User> FindByNameAsync(string userName)
        {
            // Implementar
            return Task.FromResult<User>(null);
        }

        public Task UpdateAsync(User user)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region IUserPassword members

        public Task<string> GetPasswordHashAsync(User user)
        {
            throw new NotImplementedException();
        }

        public Task<bool> HasPasswordAsync(User user)
        {
            throw new NotImplementedException();
        }

        public Task SetPasswordHashAsync(User user, string passwordHash)
        {
            user.Password = passwordHash;
            return Task.FromResult<IdentityResult>(IdentityResult.Success);
        }

        #endregion

        #region IUserRoleStore members

        public Task AddToRoleAsync(User user, string roleName)
        {
            //throw new NotImplementedException();
            return Task.FromResult<object>(null);
        }

        public Task<IList<string>> GetRolesAsync(User user)
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsInRoleAsync(User user, string roleName)
        {
            throw new NotImplementedException();
        }

        public Task RemoveFromRoleAsync(User user, string roleName)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}