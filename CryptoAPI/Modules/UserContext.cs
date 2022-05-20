using Microsoft.EntityFrameworkCore;

namespace CryptoAPI.Modules
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext> options)
            : base(options)
        {

        }
        public DbSet<UserDto> Users { get; set; }
    }
}
