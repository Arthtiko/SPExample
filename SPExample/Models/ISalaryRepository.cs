using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SPExample.Models
{
    public interface ISalaryRepository
    {
        IEnumerable<EmployeeSalary> GetAllSalary();
        EmployeeSalary GetSalaryByName(string name); // retrieves salary by name
    }
}
