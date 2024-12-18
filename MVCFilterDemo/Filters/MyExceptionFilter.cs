using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;

namespace MVCFilterDemo.Filters
{
    public class MyExceptionFilter : ExceptionFilterAttribute
    {
       
        public override void OnException(ExceptionContext context)
        {
            // we log exception here
           Debug.WriteLine($"[MyExceptionFilter] Exception caught : {context.Exception.Message}");

            //redirects to error page
            context.Result = new RedirectToActionResult("Error", "Home", null);

            
            context.ExceptionHandled = true;
        }
    }
}
