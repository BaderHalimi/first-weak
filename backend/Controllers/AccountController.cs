using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Learning.Models;

public class AccountController : Controller
{
    private readonly ApplicationDbContext _db;

    public AccountController(ApplicationDbContext db)
    {
        _db = db;
    }

    [HttpGet]
    public IActionResult Login(string? returnUrl = null)
    {
        ViewData["ReturnUrl"] = returnUrl;
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Login(string username, string password, string? returnUrl = null)
    {
        if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
        {
            ModelState.AddModelError("", "أدخل اسم المستخدم وكلمة المرور");
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        var user = await _db.Users.SingleOrDefaultAsync(u => u.Username == username);
        if (user == null || !PasswordHasher.VerifyPassword(password, user.PasswordHash, user.PasswordSalt))
        {
            ModelState.AddModelError("", "البيانات غير صحيحة");
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        var claims = new List<Claim> 
        { 
            new Claim(ClaimTypes.Name, user.Username), 
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Email, user.Email ?? ""),
            new Claim("PhoneNumber", user.PhoneNumber ?? "")
        };
        var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
        var principal = new ClaimsPrincipal(identity);

        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
        return Redirect(returnUrl ?? "/");
    }

    [HttpGet]
    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Register(string username, string email, string phoneNumber, string password, string confirmPassword)
    {
        if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
        {
            ModelState.AddModelError("", "أدخل الحقول المطلوبة");
            return View();
        }

        if (!string.Equals(password, confirmPassword))
        {
            ModelState.AddModelError("", "كلمتا المرور غير متطابقتين");
            return View();
        }

        var usernameExists = await _db.Users.AnyAsync(u => u.Username == username);
        if (usernameExists)
        {
            ModelState.AddModelError("", "اسم المستخدم مستخدم مسبقاً");
            return View();
        }

        var emailExists = await _db.Users.AnyAsync(u => u.Email == email);
        if (emailExists)
        {
            ModelState.AddModelError("", "البريد الإلكتروني مستخدم مسبقاً");
            return View();
        }

        var (hash, salt) = PasswordHasher.HashPassword(password);

        var user = new AppUser
        {
            Username = username,
            Email = email,
            PhoneNumber = phoneNumber,
            PasswordHash = hash,
            PasswordSalt = salt
        };

        _db.Users.Add(user);
        await _db.SaveChangesAsync();

        return RedirectToAction(nameof(Login));
    }

    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        return RedirectToAction("Index", "Home");
    }

    public IActionResult AccessDenied() => Content("Access denied");
}