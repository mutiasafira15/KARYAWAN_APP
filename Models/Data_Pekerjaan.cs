using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KaryawanApp.Models
{
    [Table("Data_Pekerjaan")]
    public class Data_Pekerjaan
    {
        [Key]
        [Required]
        public int PKJ_ID { get; set; }

        public string? PKJ_PERUSAHAAN { get; set; }

        public string? PKJ_POSISI { get; set; }

        public int? PKJ_GAJI_TERAKHIR { get; set; }

        public int? PKJ_TAHUN { get; set; }
    }
}
