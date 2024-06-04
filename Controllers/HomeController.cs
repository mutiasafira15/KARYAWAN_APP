using KaryawanApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace KaryawanApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly Datas.ApplicationDBContext _db;
        private IConfiguration Configuration;
        private IWebHostEnvironment _hostingEnvironment;
        public HomeController(Datas.ApplicationDBContext db, ILogger<HomeController> logger, IConfiguration configuration, IWebHostEnvironment hostingEnvironment)
        {
            _db = db;
            _logger = logger;
            Configuration = configuration;
            _hostingEnvironment = hostingEnvironment;

        }

        //Controller SignUp
        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SignUp(string USR_EMAIL, string USR_PASS, bool USR_ADMIN)
        {
            if (!string.IsNullOrEmpty(USR_EMAIL) && !string.IsNullOrEmpty(USR_PASS))
            {
                var data_User = new Data_User
                {
                    USR_EMAIL = USR_EMAIL,
                    USR_PASS = USR_PASS,
                    USR_ADMIN = USR_ADMIN
                };
                // Add the user to the database
                _db.Data_Users.Add(data_User);
                _db.SaveChanges();

                // Redirect or do any other necessary actions
                return RedirectToAction("Login");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Email and password are required.");
            }

            // If the model is not valid or an error occurred, return to the view
            return View();
        }

        // Controller Login
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string USR_EMAIL, string USR_PASS)
        {
            Data_User data = _db.Data_Users.FirstOrDefault(x => x.USR_EMAIL == USR_EMAIL && x.USR_PASS == USR_PASS);
            if (data == null)
            {
                ModelState.AddModelError(string.Empty, "Email dan password tidak terdaftar.");
                return View();
            }

            // Set session values
            HttpContext.Session.SetString("UserRole", (bool)data.USR_ADMIN ? "True" : "False");

            return RedirectToAction("Homepage", "Home");
        }

        [HttpPost]
        public IActionResult Logout()
        {
            // Clear the session
            HttpContext.Session.Clear();
            return RedirectToAction("Login", "Account");
        }

        // Controller Homepage
        public IActionResult Homepage()
        {
            return View();
        }

        //Controller Create Biodata
        public IActionResult Update_Biodata(int id)
        {
            if (id > 0)
            {
                var bd = _db.Data_Karyawans.Find(id);
                if (bd == null) return NotFound();
                return View(bd);
            }
            else
            {
                return View(new Models.Data_Karyawan());
            }
        }

        [HttpPost]
        public IActionResult Update_Biodata(Models.Data_Karyawan data, int KRY_ID)
        {
            if (KRY_ID > 0)
            {
                _db.Data_Karyawans.Update(data);
                _db.SaveChanges();
                return RedirectToAction("Homepage");
            }
            else
            {
                if (_db.Data_Karyawans.Any(x => x.KRY_ID == data.KRY_ID))
                {
                    data.KRY_ID = 0;
                    return Ok("data sudah ada");
                }
                else
                {
                    _db.Add(data);
                    _db.SaveChanges();
                    return RedirectToAction("Homepage");
                }
                
                
            }
        }

        public IActionResult List_Biodata(string search = "")
        {
            IEnumerable<Data_Karyawan> data_Karyawans = _db.Data_Karyawans;
            if (string.IsNullOrEmpty(search))
            {
                data_Karyawans = _db.Data_Karyawans;
            }
            return View(data_Karyawans);
        }

        public IActionResult Detail_Biodata(int id)
        {
            if (id > 0)
            {
                var bd = _db.Data_Karyawans.Find(id);
                if (bd == null) return NotFound();
                return View(bd);
            }
            else
            {
                return View(new Models.Data_Karyawan());
            }
        }

        [HttpGet]
        public IActionResult Delete_Biodata(int id)
        {
            Models.Data_Karyawan data_Karyawan = _db.Data_Karyawans.Find(id);
            if (data_Karyawan == null)
            {
                return Ok("Data tidak ditemukan");
            }
            else
            {
                _db.Data_Karyawans.Remove(data_Karyawan);
                _db.SaveChanges();
                return RedirectToAction("List_Biodata");
            }
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}