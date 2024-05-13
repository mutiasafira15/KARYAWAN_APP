using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KaryawanApp.Models
{
    [Table("Data_Karyawan")]
    public class Data_Karyawan
    {
        [Key]
        [Required]
        public int KRY_ID { get; set; }

        public int? KRY_USER_ID { get; set; }

        public int? KRY_PDK_ID { get; set; }

        public string? KRY_POSISI_DILAMAR { get; set; }

        public string? KRY_NAMA { get; set; }

        public int? KRY_NO_KTP { get; set; }

        public string? KRY_TEMPAT_LAHIR { get; set; }

        public DateTime? KRY_TANGGAL_LAHIR { get; set; }

        public string? KRY_JENIS_KELAMIN { get; set; }

        public string? KRY_AGAMA { get; set; }

        public string? KRY_GOL_DARAH { get; set; }

        public string? KRY_STATUS { get; set; }

        public string? KRY_ALAMAT_KTP { get; set; }

        public string? KRY_EMAIL { get; set; }

        public int? KRY_NO_TELP { get; set; }

        public string? KRY_NAMA_YANG_DAPAT_DIHUB { get; set; }

        public int? KRY_NO_YANG_DAPAT_DIHUB { get; set; }

        public int? KRY_PLT_ID { get; set; }

        public int? KRY_PKJ_ID { get; set; }

        public string? KRY_SKILL { get; set; }

        public string? KRY_SEDIA_PENEMPATAN_DIMANAPUN { get; set; }

        public int? KRY_EKSPEKTASI_SALARY { get; set; }


    }
}
