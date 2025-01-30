using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata.Ecma335;

namespace DataLayer
{
    [Table("Departments")]
    public class Department
    {
        public int ID { get; set; }
        public string? Name { get; set; }

        public virtual ICollection<Employee>? DepartmentEmployees { get; set; }
    }
}