using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace StudentApp.Filters
{
    public class LogRequestBody : ActionFilterAttribute
    {
        private MemoryStream requestBody;
        private MemoryStream responseBody;

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            this.requestBody = new MemoryStream();
            this.responseBody = new MemoryStream();
            // redirect the real stream to our own memory stream 
            context.HttpContext.Request.Body = requestBody;
            context.HttpContext.Response.Body = responseBody;
        }

        public override void OnResultExecuted(ResultExecutedContext context)
        {
            requestBody.Seek(0, SeekOrigin.Begin);

            using (StreamReader sr = new StreamReader(requestBody))
            {
                var actionResult = sr.ReadToEnd();
                Console.WriteLine(actionResult);
            }

            responseBody.Seek(0, SeekOrigin.Begin);

            // read our own memory stream 
            using (StreamReader sr = new StreamReader(responseBody))
            {
                var actionResult = sr.ReadToEnd();
                // create new stream and assign it to body
                // context.HttpContext.Response.Body = ;
                string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

                // Append text to an existing file named "WriteLines.txt".
                using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, "RequestBodyLogs.txt"), true))
                {
                    outputFile.WriteLine(DateTime.Now.ToString() + actionResult);
                }
            }

            // ERROR on the next line!

            base.OnResultExecuted(context);
        }






        //public override void OnActionExecuting(ActionExecutingContext context)
        //{
        //    string bodyData = ReadBodyAsString(context.HttpContext.Request);

        //}

        //public override void OnActionExecuted(ActionExecutedContext context)
        //{
        //    string bodyData = ReadBodyAsString(context.HttpContext.Request);
        //}

        //private string ReadBodyAsString(HttpRequest request)
        //{
        //    var initialBody = request.Body; // Workaround

        //    try
        //    {

        //        using (StreamReader reader = new StreamReader(request.Body))
        //        {

        //            string text = reader.ReadToEnd();
        //            return text;
        //        }
        //    }
        //    finally
        //    {
        //        // Workaround so MVC action will be able to read body as well
        //        request.Body = initialBody;
        //    }

        //    return string.Empty;
        //}
    }
}
