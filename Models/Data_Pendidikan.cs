using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KaryawanApp.Models
{
    [Table("Data_Pendidikan")]
    public class Data_Pendidikan
    {
        [Key]
        [Required]
        public int PDK_ID { get; set; }

        public string? PDK_DESC { get; set; }

        public string? PDK_INSTITUSI { get; set; }

        public string? PDK_JURUSAN { get; set; }

        public int? PDK_TAHUN_LULUS { get; set; }

        public double? PDK_IPK { get; set; }

    }
}
