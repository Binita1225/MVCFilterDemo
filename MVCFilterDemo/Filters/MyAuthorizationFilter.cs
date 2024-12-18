using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace MVCFilterDemo.Filters
{
    public class MyAuthorizationFilter : Attribute ,IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            //check if user is authenticated or not
            if (!context.HttpContext.User.Identity.IsAuthenticated)
            {
                //if not authenticated, redirects to login page
                context.Result = new RedirectToActionResult("Login", "Account", null);
            }
        }
    }
}
