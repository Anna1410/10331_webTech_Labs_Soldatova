using _10331_webTech_Labs.DAL.Data;
using _10331_webTech_Labs.DAL.Entities;
using _10331_webTech_Labs.Extensions;
using _10331_webTech_Labs.Models;
using Microsoft.AspNetCore.Mvc;

namespace _10331_webTech_Labs.Controllers
{
    public class ProductController : Controller
    {
        ApplicationDbContext _context;
        int _pageSize;
        public ProductController(ApplicationDbContext context)
        {
            _pageSize = 3;
            _context = context;
        }

        [Route("Catalog")]
        [Route("Catalog/Page_{pageNo}")]

        public IActionResult Index(int? group, int pageNo = 1)
        {
            var dishesFiltered = _context.Dishes.Where(d => !group.HasValue || d.DishGroupId == group.Value);
            // Поместить список групп во ViewData
            ViewData["Groups"] = _context.DishGroups;
            // Получить id текущей группы и поместить в TempData
            ViewData["CurrentGroup"] = group ?? 0;
            var model = ListViewModel<Dish>.GetModel(dishesFiltered, pageNo, _pageSize);
            if (Request.IsAjaxRequest())
                return PartialView("_listpartial", model);
            else
                return View(model);
        }
    }
}
