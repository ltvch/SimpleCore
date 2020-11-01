using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleCore.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "nvarchar(24)")]
        [DisplayName("Last Name")]
        [Required(ErrorMessage = "This Field is required.")]
        [MaxLength(24, ErrorMessage = "Maximum 24 characters only")]

        public string LastName { get; set; }
        [Column(TypeName = "nvarchar(24)")]
        [DisplayName("Name")]
        [Required(ErrorMessage = "This Field is required.")]
        [MaxLength(24, ErrorMessage = "Только 24 знака для ввода.")]
        public string Name { get; set; }

        [Column(TypeName = "nvarchar(24)")]
        [DisplayName("Position")]
        [Required(ErrorMessage = "This Field is required.")]
        [MaxLength(24, ErrorMessage = "Только 24 знака для ввода.")]
        public string Position { get; set; }

        [Column(TypeName = "DECIMAL(5,0)")]
        [DisplayName("Salary")]
        [Required(ErrorMessage = "This Field is required.")]
        public decimal Salary { get; set; }

        [Column(TypeName = "date")]
        [DefaultValue(null)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [DataType(DataType.Date)]
        public DateTime? Hired { get; set; }

        [Column(TypeName = "date")]
        [DefaultValue(null)]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd'/'MM'/'yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? Fired { get; set; }
    }
}
