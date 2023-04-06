using KiemTraLan2.Models;
using Microsoft.AspNetCore.Mvc;

namespace KiemTraLan2.ViewComponents
{
    public class TranDauMenuViewComponent : ViewComponent
    {
        QlbongDaContext db = new QlbongDaContext();
        public TranDauMenuViewComponent() { }

        public IViewComponentResult Invoke()
        {
            var lstTranDau = db.Trandaus.ToList();
            return View(lstTranDau);
        }
    }
}
