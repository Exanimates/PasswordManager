using Microsoft.EntityFrameworkCore;

namespace PasswordManager.Models
{
    public class PasswordsContext : DbContext
    {
        public DbSet<Password> Passwords { get; set; }
        public PasswordsContext(DbContextOptions<PasswordsContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
