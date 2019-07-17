using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace SPExample.Models
{
    public class SQLSalaryRepository : ISalaryRepository
    {
        private string connectionString = "server=(localdb)\\MSSQLLocalDB;database=SalaryDB;Trusted_Connection=True";
        private List<EmployeeSalary> SalaryList = new List<EmployeeSalary>();
        public IEnumerable<EmployeeSalary> GetAllSalary()
        {
            DataTable dt = new DataTable();
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                string procName = "[Get_Salary]";
                using (SqlCommand sqlCommand = new SqlCommand(procName, sqlConnection))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    //sqlCommand.Parameters.AddWithValue("@Employee_Name", name);
                    sqlConnection.Open();
                    using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand))
                    {
                        sqlDataAdapter.Fill(dt);
                    }
                }
            }
            foreach (DataRow row in dt.Rows)
            {
                var temp = new EmployeeSalary()
                {
                    EmployeeName = Convert.ToString(row["Employee_Name"]),
                    Salary = Convert.ToInt32(row["Salary"])
                };
                SalaryList.Add(temp);
            }
            return SalaryList;
        }

        public EmployeeSalary GetSalaryByName(string name)
        {
            DataTable dt = new DataTable();
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                string procName = "[Get_Salary]";
                using (SqlCommand sqlCommand = new SqlCommand(procName, sqlConnection))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@Employee_Name", name);
                    sqlConnection.Open();
                    using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand))
                    {
                        sqlDataAdapter.Fill(dt);
                    }
                }
            }
            var row = dt.Rows[0];
            var temp = new EmployeeSalary()
            {
                EmployeeName = Convert.ToString(row["Employee_Name"]),
                Salary = Convert.ToInt32(row["Salary"])
            };
            return temp;
        }
    }
}
