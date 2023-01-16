using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace zpnet.Models
{

    [Table("Sales")]
    public class Sale
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]

        [Display(Name = "Auto")]
        public string? Auto { get; set; }

        public string? Platnosc { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Data sprzedazy")]
        public DateTime? Data_s { get; set; }

        public int? ClientId { get; set; }
        [ForeignKey("ClientId")]
        public Client? Client { get; set; }


    }
}
