using System;
using System.ComponentModel.DataAnnotations.Schema;


namespace zpnet.Models
{
    [Table("Categories")]
    public class Category
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? Nazwa { get; set; }
        public string? Opis { get; set; }
        
        public ICollection<Car>? Cars { get; set; }
    }
}
