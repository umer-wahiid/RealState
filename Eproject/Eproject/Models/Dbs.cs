using Microsoft.EntityFrameworkCore;

namespace Eproject.Models
{
    public class Dbs: DbContext
    {
        public Dbs(DbContextOptions<Dbs> options) : base(options) { }
        public DbSet<Login> UserLogins { get; set; }
        public DbSet<Admin> AdminLogins { get; set; }
        public DbSet<Agent> AgentLogins { get; set; }
    }
}
