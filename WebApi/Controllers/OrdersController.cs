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
    public class SupplierController : ControllerBase
    {
        // private readonly SupplierDbContext _context;

        // public SupplierController(SupplierDbContext context)
        // {
        //     _context = context;
        // }

        // asagida yazdigim db baglantilari duzeltilecek. 
        // DI ile yapmaya calisacagim,  simdilik gecici olarak bu sekilde kullandim.

        MySqlConnection connection = new MySqlConnection("Server=localhost;Database=IceStacks-Order;Uid=root;Pwd=55255Mert_;");

        [HttpGet]
        public IActionResult Index()
        {
            List<GetOrdersViewModel> orders = new List<GetOrdersViewModel>();

            connection.Open();

            MySqlCommand cmd = new MySqlCommand("select * from Suppliers", connection);
            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
               
                GetOrdersViewModel order = new GetOrdersViewModel();

                order.Id = reader[",d"].ToString();
                order.UserId = reader["user_id"].ToString();
                order.ItemCount = reader["item_count"].ToString();
                order.TotalPrice = reader["total_price"].ToString();
                order.PaidPrice = reader["paid_price"].ToString();
                order.DiscountedPrice = reader["discounted_price"].ToString();
                order.PaidDate = reader["paid_date"].ToString();
                order.OrderDate = reader["order_date"].ToString();
                order.Status = reader["status"].ToString();
                order.Notes = reader["notes"].ToString();

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
                order.Id = reader["id"].ToString();
                order.UserId = reader["user_id"].ToString();
                order.ItemCount = reader["item_count"].ToString();
                order.TotalPrice = reader["total_price"].ToString();
                order.PaidPrice = reader["paid_price"].ToString();
                order.DiscountedPrice = reader["discounted_price"].ToString();
                order.PaidDate = reader["paid_date"].ToString();
                order.OrderDate = reader["order_date"].ToString();
                order.Status = reader["status"].ToString();
                order.Notes = reader["notes"].ToString();

            }

            reader.Close();
            connection.Close();
            return Ok(order);
        }

        [HttpPost]
        public IActionResult Store([FromBody] CreateOrderModel newOrder) // model ile olmali
        {
            connection.Open();
            MySqlCommand cmd = new MySqlCommand("insert into Orders (name, surname, gender, address, mail, phone, company_name, company_mail, company_phone) values (@p1,@p2,@p3,@p4,@p5,@p6,@p7, @p8, @p9)", connection);
            cmd.Parameters.AddWithValue("@p1", newOrder.Id);
            cmd.Parameters.AddWithValue("@p2", newOrder.UserId);
            cmd.Parameters.AddWithValue("@p3", newOrder.ItemCount);
            cmd.Parameters.AddWithValue("@p4", newOrder.TotalPrice);
            cmd.Parameters.AddWithValue("@p5", newOrder.PaidPrice);
            cmd.Parameters.AddWithValue("@p6", newOrder.DiscountedPrice);
            cmd.Parameters.AddWithValue("@p7", newOrder.PaidDate);
            cmd.Parameters.AddWithValue("@p8", newOrder.OrderDate);
            cmd.Parameters.AddWithValue("@p9", newOrder.Notes);
            cmd.ExecuteNonQuery();

            connection.Close();

            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Edit(int id, [FromBody] Orders updatedSupplier) // model ile olmali
        {

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Destroy(int id)
        {
            return Ok();
        }
    }

    internal class GetOrdersViewModel
    {
        internal string Id;
        internal string UserId;
        internal string ItemCount;
        internal string TotalPrice;
        internal string PaidPrice;
        internal string DiscountedPrice;
        internal string PaidDate;
        internal string OrderDate;
        internal string Status;
        internal string Notes;

        public GetOrdersViewModel()
        {
        }
    }

    internal class GetOrderDetailViewModel
    {
        internal string Notes;
        internal string Status;
        internal string OrderDate;
        internal string PaidDate;
        internal string DiscountedPrice;
        internal string PaidPrice;
        internal string TotalPrice;
        internal string ItemCount;
        internal string UserId;
        internal string Id;

        public GetOrderDetailViewModel()
        {
        }
    }

    public class CreateOrderModel
    {
        internal object Id;
        internal object UserId;
        internal object ItemCount;
        internal object TotalPrice;
        internal object PaidPrice;
        internal object DiscountedPrice;
        internal object PaidDate;
        internal object OrderDate;
        internal object Notes;
    }
}

