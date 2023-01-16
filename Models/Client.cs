using System;
using System.ComponentModel.DataAnnotations.Schema;


namespace zpnet.Models
{
    [Table("Clients")]
    public class Client
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? Imie { get; set; }
        public string? Nazwisko { get; set; }

        public int? Telefon { get; set; }

        public string? Email { get; set; }



        // public ICollection<Sale>? Sales { get; set; }
    }
}
