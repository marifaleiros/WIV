using System.Data.Entity;
using WIV.Domain;

namespace WIV.Data
{
    public class WIVContext : DbContext
    {
        public WIVContext()
            : base("WIVContext")
        {
            Database.SetInitializer(new WIVContextInitializer());
        }

        public DbSet<WorkItem> WorkItems { get; set; }
    }
}
