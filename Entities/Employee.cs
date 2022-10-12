using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Entities
{
    public class Employee : BaseEntity
    {
        public string Name { get; set; }
        [Required]
        public DateTime DOB { get; set; }
       public string Email { get; set; }
        public string Mobile { get; set; }
        public int City { get; set; }
        public string CityName { get; set; }
        [DataType(DataType.MultilineText)]
        [StringLength(200)]
        public string Address { get; set; }
        public int PinCode { get; set; }
        public string? Image { get; set; }
        public bool IsDeleted { get; set; }
        public DateTimeOffset InsertedDate { get; set; }
        public DateTimeOffset UpdatedDate { get; set; }
        public DateTimeOffset DeleteDate { get; set; }
    }
}