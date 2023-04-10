using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
namespace BTLWeb.Models.Authenication
{
    public class Authenication:ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.HttpContext.Session.GetString("Username") == null)
            {
                context.Result = new RedirectToRouteResult(
                    new RouteValueDictionary {
                        {"Controller", "Access" },
                        {"Action", "Login" }
                        });
            }
        }
    }
}
