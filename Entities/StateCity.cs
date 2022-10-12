using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Entities
{
    public class StateCity
    {
        public int Id { get; set; }
        public int ParentId { get; set; }
        [StringLength(150)]
        public string Name { get; set; }
        [StringLength(50)]
        public string Abbreviation { get; set; }
        [StringLength(50)]
        public string AlternateAbbreviation { get; set; }
        [StringLength(50)]
        public string Code { get; set; }
        public int CountryId { get; set; }
        public bool Isdeleted { get; set; } = false;
        public bool IsActive { get; set; } = true;
        public int InsertedBy { get; set; }
        public DateTime InsertedDate { get; set; }
        public int UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int DeletedBy { get; set; }
        public DateTime? DeletedDate { get; set; }
    }
}