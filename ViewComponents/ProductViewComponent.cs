using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TH3_Harmic.Models;

namespace TH3_Harmic.ViewComponents
{
    public class ProductViewComponent : ViewComponent
    {
        private readonly BanHoaQuaContext _context;

        public ProductViewComponent(BanHoaQuaContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            // truy cập bảng TbProducts trong cơ sở dữ liệu
            // Include(m => m.CategoryProduct) bao gồm thông tin từ bảng liên quan để tránh truy vấn lồng nhau
            var items = _context.TbProducts.Include(m => m.CategoryProduct)
                //lọc các loại sản phẩm đang hoạt động và các sản phẩm mới
                .Where(m => (bool)m.IsActive).Where(m => m.IsNew);
            //items.OrderByDescending(m => m.ProductId sắp xếp các sản phẩm theo id giảm dần
            //ToList() chuyển kết quả truy vấn thành danh sách và hiển thị
            return await Task.FromResult<IViewComponentResult>
                (View(items.OrderByDescending(m => m.ProductId).ToList()));
        }
    }
}
