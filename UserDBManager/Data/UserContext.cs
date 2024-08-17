using Microsoft.EntityFrameworkCore;
using UserDBManager.Model;

namespace UserDBManager.Data;

public class UserContext : DbContext
{
    public DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-4BOPE1O\SQLEXSPRESS;Initial Catalog=UserDbManager;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
    }
}
