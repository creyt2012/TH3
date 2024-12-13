using Microsoft.AspNetCore.Mvc;
using TH3_Harmic.Models;

namespace TH3_Harmic.ViewComponents
{
    public class MenuTopViewComponent : ViewComponent
    {
        private readonly BanHoaQuaContext _context;

        public MenuTopViewComponent(BanHoaQuaContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var items = _context.TbMenus.Where(m=>m.IsActive)
               .OrderBy(m=>m.Position).ToList();
            return await Task.FromResult<IViewComponentResult>(View(items));
        }
    }
}
