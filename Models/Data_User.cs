using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KaryawanApp.Models
{
    [Table("Data_User")]
    public class Data_User
    {
        [Key]
        [Required]
        public int USR_ID { get; set; }

        public string? USR_EMAIL { get; set; }

        public string? USR_PASS { get; set; }  

        public bool? USR_ADMIN { get; set; }
    }
}
