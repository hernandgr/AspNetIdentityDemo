using AuthenticationTest.Entities;
using AuthenticationTest.Services;
using AuthenticationTest.Services.Interfaces;
using Microsoft.AspNet.Identity;
using System;
using System.Threading.Tasks;

namespace AuthenticationTest.IdentityProvider.Stores
{
    public class RoleStore : IRoleStore<Role>
    {
        private readonly IRoleService _roleService;

        public RoleStore()
        {
            _roleService = new RoleService();
        }

        public Task CreateAsync(Role role)
        {
            //_roleService.CreateRole(role);

            throw new NotImplementedException();
        }

        public Task DeleteAsync(Role role)
        {
            throw new NotImplementedException();
        }

        public Task<Role> FindByIdAsync(string roleId)
        {
            throw new NotImplementedException();
        }

        public Task<Role> FindByNameAsync(string roleName)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Role role)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}