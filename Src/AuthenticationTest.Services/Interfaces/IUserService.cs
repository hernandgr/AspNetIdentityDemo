using AuthenticationTest.Entities;

namespace AuthenticationTest.Services.Interfaces
{
    public interface IUserService
    {
        void CreateUser(User user);
    }
}