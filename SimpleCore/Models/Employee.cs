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

        [RegularExpression(@"^[A-Z]+[a-zA-Z]*$", ErrorMessage = "Используйте только буквы для ввода")]
        [Column(TypeName = "nvarchar(24)")]
        [DisplayName("Last Name")]
        [Required(ErrorMessage = "Поле обязательно к заполнению.")]
        [MaxLength(24, ErrorMessage = "Только 24 знака для ввода.")]
        public string LastName { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z]*$", ErrorMessage = "Используйте только буквы для ввода")]
        [Column(TypeName = "nvarchar(24)")]
        [DisplayName("Name")]
        [Required(ErrorMessage = "Поле обязательно к заполнению.")]
        [MaxLength(24, ErrorMessage = "Только 24 знака для ввода.")]
        public string Name { get; set; }

        [Column(TypeName = "nvarchar(24)")]
        [DisplayName("Position")]
        [Required(ErrorMessage = "Поле обязательно к заполнению.")]
        [MaxLength(24, ErrorMessage = "Только 24 знака для ввода.")]
        public string Position { get; set; }

        [Range(1, 10000)]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "Только цифры")]
        [Column(TypeName = "DECIMAL(5,0)")]
        [DisplayName("Salary")]
        [Required(ErrorMessage = "Поле обязательно к заполнению.")]
        public decimal Salary { get; set; }

        [Column(TypeName = "date")]
        [DisplayName("Hired"), DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "Поле обязательно к заполнению.")]
        public DateTime? Hired { get; set; }

        [Column(TypeName = "date")]
        [DefaultValue(null)]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? Fired { get; set; }
    }
}
