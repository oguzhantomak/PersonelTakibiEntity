using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFAPersonelTakibi.Models
{
    public class Employee
    {
        public int EmployeeID { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeLastName { get; set; }
        public DateTime EmployeeBirthDate { get; set; }
        public string EmployeeMail { get; set; }
        public Gender EmployeeGender { get; set; }
        public string EmployeeAddress { get; set; }
        public string EmployeePhone { get; set; }
        public Department EmployeeDepartment { get; set; }
        public string EmployeeImageUrl { get; set; }

    }
}
