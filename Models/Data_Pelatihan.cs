using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KaryawanApp.Models
{
    [Table("Data_Pelatihan")]
    public class Data_Pelatihan
    {
        [Key]
        [Required]
        public int PLT_ID { get; set; }

        public string? PLT_DESC { get; set; }

        public string? PLT_SERTIF { get; set; }

        public int? PLT_TAHUN { get; set; }

    }
}
