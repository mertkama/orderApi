using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using StackExchange.Redis;
using WebApi.Models;

namespace WebApi.DbOperations
{
    public class OrderDbContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public OrderDbContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // connect to mysql with connection string from app settings
            var connectionString = Configuration.GetConnectionString("OrderDb");
            options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        }
        public DbSet<Order> Orders { get; set; }
            
    }
}