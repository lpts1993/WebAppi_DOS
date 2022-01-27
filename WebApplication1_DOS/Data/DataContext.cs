using Microsoft.EntityFrameworkCore;

namespace WebApplication1_DOS.Data
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options): base(options)    { }

        public DbSet<paginados> datapaginados { get; set; }


    }
}
