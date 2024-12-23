using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;

namespace MVCFilterDemo.Filters
{
    public class MyResourceFilter : Attribute, IResourceFilter
    {
        public void OnResourceExecuted(ResourceExecutedContext context)
        {
            Debug.WriteLine("OnResourceExecuted: Resource filter executed");

            
        }

        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            Debug.WriteLine("OnResourceExecuting: Resource filter executing");

            //logic added to demonstrate caching
            if (context.HttpContext.Request.Path == "/Home/About")
            {
                context.Result = new ContentResult
                {
                    Content = "This page is cached and no further processing is done."
                };
            }
        }
    }
}
