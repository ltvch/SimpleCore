using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleCore.Models
{
    public class Seat
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "nvarchar(24)")]
        [DisplayName("Position")]
        [Required(ErrorMessage = "This Field is required.")]
        [MaxLength(24, ErrorMessage = "Maximum 24 characters only")]
        public string Position { get; set; }
    }
}
