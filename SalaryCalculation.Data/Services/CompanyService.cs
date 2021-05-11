using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalaryCalculation.Data.Services
{
    public class CompanyService
    {
        public static List<tbl_Employee> GetAllTbl_Employees()
        {
            using (CompanyEntities dbContext = new CompanyEntities())
            {
                return dbContext.tbl_Employee.ToList();
            }								   
        }

        public static void CreateNewEmployee(tbl_Employee employee)
        {
            using (CompanyEntities dbContext = new CompanyEntities())
            {
                dbContext.tbl_Employee.Add(employee);
                dbContext.SaveChanges();
            }
        }
    }
}
