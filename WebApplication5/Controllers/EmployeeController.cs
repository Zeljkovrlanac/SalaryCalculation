using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SalaryCalculation.Data;
using SalaryCalculation.Data.Services;

namespace WebApplication5.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult ShowEmployees()
        {
            var employees = CompanyService.GetAllTbl_Employees();

            return View(employees);
        }

        public ActionResult NewEmployee()
        {
            return View();
        }


        [HttpPost]
        public ActionResult NewEmployee(tbl_Employee employee)
        {
            employee.BrutSalary = CalculateBrutSalary(employee.NetSalary);

            CompanyService.CreateNewEmployee(employee);

            ViewBag.Message = "New employee " + employee.Name + " " + employee.Lastname +" record inserted successfully. " +
                "Brut salary of the employee is: " + employee.BrutSalary;
            ModelState.Clear();
            return View();
        }



        private decimal CalculateBrutSalary(decimal netSalary)
        {
            decimal bruto_1 = (netSalary - 1830) / 0.701m; //(Plata - 1830(10% od neoporezivog iznosa))
            decimal bruto_2 = bruto_1 * (decimal)1.1715;
            return Math.Round(bruto_2, 2);
        }
    }
}