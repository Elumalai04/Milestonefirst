using Microsoft.EntityFrameworkCore;
using Models;

namespace DataContext
{
    public class EMSDataContext : DbContext
    {
        public EMSDataContext(DbContextOptions<EMSDataContext> options) : base(options) { }

        public DbSet<Student> Student { get; set; }
        public DbSet<School> School { get; set; }
    }

    //public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<EMSDataContext>
    //{
    //    public EMSDataContext CreateDbContext(string[] args)
    //    {
    //        //IConfigurationRoot configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile(@Directory.GetCurrentDirectory() + "/../EMS/appsettings.json").Build();
    //        //var builder = new DbContextOptionsBuilder<EMSDataContext>();
    //        //var connectionString = configuration.GetConnectionString("DatabaseConnection");
    //        //builder.UseSqlServer(connectionString);
    //        //return new EMSDataContext(builder.Options);
    //    }
    //}
}
