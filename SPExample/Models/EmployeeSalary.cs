using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SPExample.Models
{
    public class EmployeeSalary
    {
        [Required]
        [MaxLength(30)]
        public string EmployeeName { get; set; }
        public int Salary { get; set; }
    }
}
