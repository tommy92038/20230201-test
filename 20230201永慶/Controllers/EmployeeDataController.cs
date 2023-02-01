using _20230201永慶.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace _20230201永慶.Controllers
{
    public class EmployeeDataController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create(EmployeeData EmployeeData)
        {
            DBM dbm= new DBM();
            SqlConnection conn=new SqlConnection(dbm.ConnStr);
            conn.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO EmployeeData(Id,Name,Address,Email)VALUES(@Id,@Name,@Address,@Email) ", conn);
            cmd.Parameters.AddWithValue("Id", EmployeeData.Id);
            cmd.Parameters.AddWithValue("Name", EmployeeData.Name);
            cmd.Parameters.AddWithValue("Address", EmployeeData.Address);
            cmd.Parameters.AddWithValue("Email", EmployeeData.Email);
            SqlDataReader dr=cmd.ExecuteReader();
            dr.Dispose();
            conn.Close();
            return View("Index");
        }
        public IActionResult getEmployeeData()
        {
            return View();
        }
    }
}
