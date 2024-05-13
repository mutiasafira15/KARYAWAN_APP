using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using KaryawanApp.Datas;

namespace KaryawanApp.Datas
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {

        }
        public DbSet<Models.Data_Admin> Data_Admins { get; set; }
        public DbSet<Models.Data_Karyawan> Data_Karyawans { get; set; }
        public DbSet<Models.Data_Pekerjaan> Data_Pekerjaans { get; set; }
        public DbSet<Models.Data_Pelatihan> Data_Pelatihans { get; set; }
        public DbSet<Models.Data_Pendidikan> Data_Pendidikans { get; set; }
        public DbSet<Models.Data_User> Data_Users { get; set; }
    }
}
