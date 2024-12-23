using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;

namespace MVCFilterDemo.Filters
{
    public class MyAuthorizationFilter : Attribute ,IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        
        {
            Debug.WriteLine("Authorization filter triggered");
            //check if user is authenticated or not
            if (!context.HttpContext.User.Identity.IsAuthenticated)
            {
                Debug.WriteLine("User is not authenticated. Redirecting to login.");
                //if not authenticated, redirects to login page
                context.Result = new RedirectToActionResult("Login", "Home", null);
            }
        }
    }
}
