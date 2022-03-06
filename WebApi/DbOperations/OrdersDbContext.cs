using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MySqlConnector;
using WebApi.Models;

namespace WebApi.DbOperations
{
    public class OrderDbContext : DbContext
    {
        protected readonly MySqlConnection _connection;

        public OrderDbContext(MySqlConnection connection)
        {
            _connection = connection;
        }

        public DbSet<Order> Orders { get; set; }



    }
}
