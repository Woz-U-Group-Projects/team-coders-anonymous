using Microsoft.EntityFrameworkCore;

namespace GroupProject3.Models {
    public class ResidentsContext : DbContext {
        public ResidentsContext (DbContextOptions<ResidentsContext> options) : base (options) {

        }
        public DbSet<Resident> Residents { get; set; }
    }
}