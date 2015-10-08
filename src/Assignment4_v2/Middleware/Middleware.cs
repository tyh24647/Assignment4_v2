using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Http;
using System.Net;

namespace Assignment4_v2.Middleware {
    // You may need to install the Microsoft.AspNet.Http.Abstractions package into your project
    public class Middleware {
        private readonly RequestDelegate _next;

        public Middleware(RequestDelegate next) {
            _next = next;
        }

        public Task Invoke(HttpContext httpContext) {

            var currentContext = httpContext.Request.Method.ToUpper();

            if ((currentContext == "POST" || currentContext == "PUT" || currentContext == "PATCH") && httpContext.Request.ContentType != "application/json") {
                httpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            }

            return _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class MiddlewareExtensions {
        public static IApplicationBuilder UseMiddleware(this IApplicationBuilder builder) {
            return builder.UseMiddleware<Middleware>();
        }
    }
}
