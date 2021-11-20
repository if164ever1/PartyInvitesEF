using Microsoft.EntityFrameworkCore;
using PartyInvites.Model;

namespace PartyInvites.Entity
{
    public class DataContext : DbContext
    {
        public DbSet<GuestResponse> Response { get; set; }

        public DataContext(DbContextOptions<DataContext> options)
            :base (options)
        { 
        }
    }
}
