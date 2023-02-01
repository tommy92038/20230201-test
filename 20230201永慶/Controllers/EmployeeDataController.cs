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
        public IActionResult getEmployeeData()
        {
            DBM dbm = new DBM();
            SqlConnection conn = new SqlConnection(dbm.ConnStr);
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM EmployeeData", conn);
            SqlDataReader dr = cmd.ExecuteReader();
            List<EmployeeData>Employees= new List<EmployeeData>();
            while(dr.Read())
            {
                Employees.Add(new EmployeeData()
                {
                    Id = (string)dr.GetValue(0),
                    Name = (string)dr.GetValue(1),
                    Address = (string)dr.GetValue(2),
                    Email = (string)dr.GetValue(3),
                });
            }
            return View(Employees);
        }
        public IActionResult Create(EmployeeData EmployeeData)
        {
            DBM dbm = new DBM();
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
            return RedirectToAction("getEmployeeData");
        }
    }
}
