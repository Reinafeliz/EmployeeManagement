using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Models
{
    public class EmployeeViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [Required]
        public DateTime DOB { get; set; }
        [Required(ErrorMessage = "Email Id Required")]
        [DisplayName("Email ID")]
        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "Email Format is wrong")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please Enter Mobile No")]
        [Display(Name = "Mobile")]
        [StringLength(10, ErrorMessage = "The Mobile must contains 10 characters", MinimumLength = 10)]
        public string Mobile { get; set; }
        public int City { get; set; }
        public string CityName { get; set; }
        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "Please Enter Address")]
        [Display(Name = "Address")]
        [StringLength(200)]
        public string Address { get; set; }
        public int PinCode { get; set; }
        public IFormFile ImageFile { get; set; }
        public string? ImagePath { get; set; }
    }
}