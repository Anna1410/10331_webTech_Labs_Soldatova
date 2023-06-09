using Microsoft.AspNetCore.Mvc;

namespace _10331_webTech_Labs.Components
{
    public class CartViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
