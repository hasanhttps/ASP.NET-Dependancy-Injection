using ASP.NET_Dependancy_Injection.Middlewares;

namespace ASP.NET_Dependancy_Injection.Extensions;

public static class MiddlewareExtention {

    public static IApplicationBuilder UseMyLogMiddleware(this IApplicationBuilder app) {

        app.UseMiddleware<LogMiddleware>();
        return app;
    }
}