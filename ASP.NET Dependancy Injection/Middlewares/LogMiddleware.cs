namespace ASP.NET_Dependancy_Injection.Middlewares;

public class LogMiddleware {

    // Fields

    public RequestDelegate? Next;

    // Constructors

    public LogMiddleware(RequestDelegate next) {
        Next = next;
    }

    // Methods

    public async Task Invoke(HttpContext context) {
        await Console.Out.WriteLineAsync("LogMiddleware Start");
        await Next?.Invoke(context);
        await Console.Out.WriteLineAsync("LogMiddleware End");
    }
}
