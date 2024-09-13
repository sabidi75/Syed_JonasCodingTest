using System.Diagnostics;
using System.Web.Http.Filters;

namespace WebApi.Logging
{
    public class LogApiRequestAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            base.OnActionExecuted(actionExecutedContext);

            var request = actionExecutedContext.Request;
            var response = actionExecutedContext.Response;

            //Log the request and response, It can be logged wherever you want, like database, file, console etc.
            Debug.WriteLine($"Request: {request.Method} {request.RequestUri}");
            Debug.WriteLine($"Response: {response?.StatusCode}");
        }
    }
}