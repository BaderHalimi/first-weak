using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Learning.Models;
using System.Security.Claims;

namespace MyApp.Namespace
{
    [Authorize]
    public class DashboardController : Controller
    {
        private readonly ApplicationDbContext _db;

        public DashboardController(ApplicationDbContext db)
        {
            _db = db;
        }

        // GET: DashboardController
        public async Task<ActionResult> Index()
        {
            // الحصول على ID المستخدم المسجل دخوله
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null)
            {
                return RedirectToAction("Login", "Account");
            }

            // جلب بيانات المستخدم الحالي من قاعدة البيانات
            var currentUser = await _db.Users.FindAsync(int.Parse(userId));
            if (currentUser == null)
            {
                return RedirectToAction("Login", "Account");
            }

            // استخدام بيانات المستخدم الحقيقية
            ViewData["userName"] = currentUser.Username;
            ViewData["email"] = currentUser.Email;
            ViewData["phoneNumber"] = currentUser.PhoneNumber ?? "غير محدد";
            ViewData["createdAt"] = currentUser.CreatedAt.ToString("yyyy-MM-dd");
            ViewData["userId"] = currentUser.Id;

            // بيانات إضافية يمكن تخصيصها لاحقاً
            ViewData["name"] = currentUser.Username; // يمكن إضافة حقل منفصل للاسم الكامل لاحقاً
            ViewData["major"] = "غير محدد"; // يمكن إضافة هذا الحقل للنموذج لاحقاً
            ViewData["isGraduated"] = false; // يمكن إضافة هذا الحقل للنموذج لاحقاً
            ViewData["avg"] = 0.0; // يمكن إضافة هذا الحقل للنموذج لاحقاً

            return View();
        }

    }
}
