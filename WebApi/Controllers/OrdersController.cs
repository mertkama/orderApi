using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MySqlConnector;
using WebApi.DbOperations;
using WebApi.Models;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]s")]
    public class OrderController : ControllerBase
    {
        // private readonly SupplierDbContext _context;

        // public SupplierController(SupplierDbContext context)
        // {
        //     _context = context;
        // }

        // asagida yazdigim db baglantilari duzeltilecek. 
        // DI ile yapmaya calisacagim,  simdilik gecici olarak bu sekilde kullandim.

        MySqlConnection connection = new MySqlConnection("Server=localhost\\SQLEXPRESS;Database=master;Trusted_Connection=True;");

        [HttpGet]
        public IActionResult Index()
        {
            List<GetOrderViewModel> orders = new List<GetOrderViewModel>();

            connection.Open();

            MySqlCommand cmd = new MySqlCommand("select * from Suppliers", connection);
            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {

                GetOrderViewModel order = new GetOrderViewModel();

                order.Id = Convert.ToInt32(reader["id"]);
                order.UserId =Convert.ToInt32(reader["user_id"]);
                order.ItemCount = Convert.ToInt32(reader["item_count"]);
                order.TotalPrice = float.Parse(reader["total_price"].ToString());
                order.PaidPrice = float.Parse(reader["paid_price"].ToString());
                order.DiscountedPrice = float.Parse(reader["discounted_price"].ToString());
                order.PaidDate = DateTime.Parse(reader["paid_date"].ToString());
                order.OrderDate = DateTime.Parse (reader["order_date"].ToString());
                order.Status = Convert.ToString (reader["status"]);
                order.Notes = Convert.ToString (reader["notes"]);

                orders.Add(order);
            }

            reader.Close();
            connection.Close();
            return Ok(orders);
        }

        [HttpGet("{id}")]
        public IActionResult Show(int id) // model ile olmali
        {
            connection.Open();

            MySqlCommand cmd = new MySqlCommand("select * from Orders where id = @id", connection);
            cmd.Parameters.AddWithValue("@id", id);

            MySqlDataReader reader = cmd.ExecuteReader();

            GetOrderDetailViewModel order = new GetOrderDetailViewModel();

            while (reader.Read())
            {
                order.Id = Convert.ToInt32(reader["id"]);
                order.UserId = Convert.ToInt32(reader["user_id"]);
                order.ItemCount = Convert.ToInt32(reader["item_count"]);
                order.TotalPrice = float.Parse(reader["total_price"].ToString());
                order.PaidPrice = float.Parse(reader["paid_price"].ToString());
                order.DiscountedPrice = float.Parse(reader["discounted_price"].ToString());
                order.PaidDate = DateTime.Parse(reader["paid_date"].ToString());
                order.OrderDate = DateTime.Parse(reader["order_date"].ToString());
                order.Status = Convert.ToString(reader["status"]);
                order.Notes = Convert.ToString(reader["notes"]);

            }

            reader.Close();
            connection.Close();
            return Ok(order);
        }

        [HttpPost]
        public IActionResult Store([FromBody] CreateOrderModel newOrder) // model ile olmali
        {
            connection.Open();
            MySqlCommand cmd = new MySqlCommand("insert into Orders (userid, itemcount, totalprice, paidprice, discountedprice, paiddate, orderdate, status, notes) values (@p1,@p2,@p3,@p4,@p5,@p6,@p7, @p8)", connection);
            cmd.Parameters.AddWithValue("@p1", newOrder.UserId);
            cmd.Parameters.AddWithValue("@p2", newOrder.ItemCount);
            cmd.Parameters.AddWithValue("@p3", newOrder.TotalPrice);
            cmd.Parameters.AddWithValue("@p4", newOrder.PaidPrice);
            cmd.Parameters.AddWithValue("@p5", newOrder.DiscountedPrice);
            cmd.Parameters.AddWithValue("@p6", newOrder.PaidDate);
            cmd.Parameters.AddWithValue("@p7", newOrder.OrderDate);
            cmd.Parameters.AddWithValue("@p8", newOrder.Notes);
            cmd.ExecuteNonQuery();

            connection.Close();

            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Edit(int id, [FromBody] Order updatedSupplier) // model ile olmali
        {

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Destroy(int id)
        {
            return Ok();
        }
    }
}