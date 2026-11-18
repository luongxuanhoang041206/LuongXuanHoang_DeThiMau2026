using LuongXuanHoang_241224477.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LuongXuanHoang_241224477.Controllers
{
    public class HomeController : Controller
    {
        private readonly QLNhaSachContext _db;
        public HomeController(QLNhaSachContext db) => _db = db;
        public async Task<IActionResult> Index()
        {
            ViewData["Title"] = "BookHub";
            ViewBag.TieuDe = "Luong Xuan Hoang";

            var ds = await _db.Saches
                .Where(s => s.Gia >= 100)
                .OrderBy(s => s.MaSach)
                .ToListAsync();
            return View(ds);
        }
        // loc sach
        [HttpGet]
        public async Task<IActionResult> LocTheoTheLoai(int id)
        {
            var tl = await _db.TheLoais.FindAsync(id);
            var ds = await _db.Saches.Where(s => s.MaTl == id && s.Gia >= 100)
                .OrderBy(s => s.MaSach)
                .Select(s => new
                {
                    s.MaSach,
                    s.TenSach,
                    s.Gia,
                    s.Anh
                }).ToListAsync();

            return Json(new { tenTL = tl?.TenTl ?? "", sach = ds });
        }

        public IActionResult Create()
        {
            ViewBag.DSTheLoai = new SelectList(_db.TheLoais.OrderBy(t => t.MaTl).ToList(), "MaTl", "TenTl");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Sach s)
        {

            ModelState.Remove(nameof(Sach.MaTlNavigation));
            if(ModelState.IsValid)
            {
                _db.Saches.Add(s);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.DSTheLoai = new SelectList(
                _db.TheLoais.OrderBy(t => t.MaTl), "MaTl", "TenTl", s.MaTl);
    
            return View(s);
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
