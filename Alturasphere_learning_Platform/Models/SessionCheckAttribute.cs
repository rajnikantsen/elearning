using System.Web.Mvc;

public class SessionCheckAttribute : ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext filterContext)
    {
        if (filterContext.HttpContext.Session["UserID"] == null)
        {
            filterContext.Controller.TempData["ErrorMessage"] = "Please log in to continue.";
            filterContext.Result = new RedirectToRouteResult(new System.Web.Routing.RouteValueDictionary
            {
                { "controller", "Account" },
                { "action", "Login" },
                { "returnUrl", filterContext.HttpContext.Request.RawUrl }
            });
        }

        base.OnActionExecuting(filterContext);
    }
}
