using ASP.NET_MVC_CRUD_WITHOUT_ENTITY_FRAMEWORK.Models;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.Mvc;

namespace ASP.NET_MVC_CRUD_WITHOUT_ENTITY_FRAMEWORK.Controllers
{
    public class ProductController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            Objects.dt = new DataTable();
            Objects.con.Open();
            Objects.da = new SqlDataAdapter("SELECT * FROM Product", Objects.con);
            Objects.da.Fill(Objects.dt);
            Objects.con.Close();
            return View(Objects.dt);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(new ProductModel());
        }

        //
        // POST: /Product/Create
        [HttpPost]
        public ActionResult Create(ProductModel productModel)
        {
            Objects.con.Open();
            string query = "INSERT INTO Product VALUES (@ProductName, @Price, @Count)";
            Objects.cmd = new SqlCommand(query, Objects.con);
            Objects.cmd.Parameters.AddWithValue("@ProductName", productModel.ProductName);
            Objects.cmd.Parameters.AddWithValue("@Price", productModel.Price);
            Objects.cmd.Parameters.AddWithValue("@Count", productModel.Count);
            Objects.cmd.ExecuteNonQuery();
            Objects.con.Close();
            return RedirectToAction("Index");
        }

        //
        // GET: /Product/Edit/5
        public ActionResult Edit(int param_ProductID)
        {
            ProductModel productModel = new ProductModel();
            Objects.con.Open();
            string query = "SELECT * FROM Product Where ProductID = @ProductID";
            Objects.cmd = new SqlCommand(query, Objects.con);
            Objects.cmd.CommandType = System.Data.CommandType.Text;
            Objects.cmd.Parameters.AddWithValue("@ProductID", param_ProductID);
            Objects.dr = Objects.cmd.ExecuteReader();
            if (Objects.dr.Read() && Objects.dr.GetValue(0) != DBNull.Value)
            {
                productModel.ProductID = param_ProductID;
                productModel.ProductName = Objects.dr["ProductName"].ToString();
                productModel.Price = Convert.ToDecimal(Objects.dr["Price"].ToString());
                productModel.Count = Convert.ToInt32(Objects.dr["Count"].ToString());
                Objects.con.Close();
                return View(productModel);
            }
            else
            {
                Objects.con.Close();
                return RedirectToAction("Index");
            }
        }

        //
        // POST: /Product/Edit/5
        [HttpPost]
        public ActionResult Edit(ProductModel productModel)
        {
            Objects.con.Open();
            string query = "UPDATE Product SET ProductName = @ProductName , Price = @price , Count = @Count WHere ProductID = @ProductID";
            Objects.cmd = new SqlCommand(query, Objects.con);
            Objects.cmd.Parameters.AddWithValue("@ProductID", productModel.ProductID);
            Objects.cmd.Parameters.AddWithValue("@ProductName", productModel.ProductName);
            Objects.cmd.Parameters.AddWithValue("@Price", productModel.Price);
            Objects.cmd.Parameters.AddWithValue("@Count", productModel.Count);
            Objects.cmd.ExecuteNonQuery();
            Objects.con.Close();
            return RedirectToAction("Index");
        }

        //
        // GET: /Product/Delete/5
        public ActionResult Delete(int param_ProductID)
        {
            Objects.con.Open();
            string query = "DELETE FROM Product WHere ProductID = @ProductID";
            Objects.cmd = new SqlCommand(query, Objects.con);
            Objects.cmd.Parameters.AddWithValue("@ProductID", param_ProductID);
            Objects.cmd.ExecuteNonQuery();
            Objects.con.Close();
            return RedirectToAction("Index");
        }

    }
}
