using Microsoft.AspNetCore.Mvc;
using TH3_Harmic.Models;

namespace TH3_Harmic.ViewComponents
{
    public class BlogViewComponent : ViewComponent

    {
        private readonly BanHoaQuaContext _context;

        public BlogViewComponent(BanHoaQuaContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var items = _context.TbBlogs.Where(m => (bool)m.IsActive);
            return await Task.FromResult<IViewComponentResult>
                (View(items.OrderByDescending(m => m.BlogId).ToList()));
        }
    }

}
