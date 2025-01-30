using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata.Ecma335;

namespace DataLayer
{
    [Table("Employees")]
    public class Employee
    {
        public int ID { get; set; }

        public int DepartmentId { get; set; }
        public string? name { get; set; }

    }
}