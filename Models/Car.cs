using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace zpnet.Models
{

    [Table("Cars")]
    public class Car
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string? Indeks { get; set; }

        [Display(Name ="Nazwa")]
        public string? Nazwa { get; set; }
        
        public string? Cena { get; set; }
        public string? Vin { get; set; }


        [DataType(DataType.Date)]
        [Display(Name ="Data rejestracji")]
        public DateTime? Data_pr { get; set; }

        public int? CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public Category? Category { get; set; }


    }
}
