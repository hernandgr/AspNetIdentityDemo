using Microsoft.AspNet.Identity;

namespace AuthenticationTest.Entities
{
    public class Role : IRole
    {
        public string Id { get; set; }

        public string Name { get; set; }
    }
}