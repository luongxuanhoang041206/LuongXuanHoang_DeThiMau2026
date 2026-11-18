using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LuongXuanHoang_241224477.Models;

namespace LuongXuanHoang_241224477.ViewComponents
{
    public class TheLoaiMenuViewComponent : ViewComponent
    {
        private readonly QLNhaSachContext _db;
        public TheLoaiMenuViewComponent(QLNhaSachContext db) => _db = db;

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var ds = await _db.TheLoais.OrderBy(t => t.MaTl).ToListAsync();
            return View(ds);
        }
    }
}
