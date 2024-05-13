using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KaryawanApp.Models
{
    [Table("Data_Admin")]
    public class Data_Admin
    {
        [Key]
        [Required]
        public int ADM_ID { get; set; }

        public int? ADM_USER_ID { get; set; }
    }
}
