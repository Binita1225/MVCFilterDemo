using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;

namespace MVCFilterDemo.Filters
{
    public class MyResultFilter : Attribute, IResultFilter
    {
       

        public void OnResultExecuting(ResultExecutingContext context)
        {
           Debug.WriteLine("OnResultExecuting: before result is sent to client");
           var controller = context.Controller as Controller;
            if (controller != null)
            {
                controller.ViewBag.Message = "This message was added by MyResultFilter";
            }

        }

        public void OnResultExecuted(ResultExecutedContext context)
        {
            Debug.WriteLine("OnResultExecuted: after result is sent to client");
        }
    }
}
