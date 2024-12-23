using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using System.Diagnostics;

namespace MVCFiltersDemo.Filters
{
    public class MyLogActionFilter : ActionFilterAttribute
    {
        // Runs BEFORE the action method executes
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            //var controller = context.RouteData.Values["controller"];
            //var action = context.RouteData.Values["action"];

            // Debug.WriteLine($"[MyLogActionFilter] Executing action: {controller}/{action}");
            Debug.WriteLine("Action Executing: " + context.ActionDescriptor.DisplayName);
            base.OnActionExecuting(context);
        }

        // Runs AFTER the action method executes
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            var controller = context.RouteData.Values["controller"];
            var action = context.RouteData.Values["action"];
            //Log("OnActionExecuting", context.RouteData);
            Debug.WriteLine($"[MyLogActionFilter] Finished executing action: {controller}/{action}");
        }

        //// Runs BEFORE the result (e.g., View or JSON) is executed
        //public override void OnResultExecuting(ResultExecutingContext context)
        //{
        //    Log("OnResultExecuting", context.RouteData);
        //}

        //// Runs AFTER the result has been executed
        //public override void OnResultExecuted(ResultExecutedContext context)
        //{
        //    Log("OnResultExecuted", context.RouteData);
        //}

        //// Private helper method for logging to Debug
        //private void Log(string methodName, RouteData routeData)
        //{
        //    var controllerName = routeData.Values["controller"]?.ToString();
        //    var actionName = routeData.Values["action"]?.ToString();

        //    //var message = $"{methodName} controller: {controllerName} action: {actionName}";
        //    var message = String.Format(
        //    "{0} controller:{1} action:{2}", methodName, controllerName, actionName);
        //    Debug.WriteLine(message, "Action Filter Log");
        //}
    }
}
