using ASP.NET_Dependancy_Injection.Extensions;
using ASP.NET_Dependancy_Injection.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

#region Middlewares

/*
 Use  =>  Middlewared'dan sonra novbeti middleware cagira bilir.
 Run  =>  Middlewared'dan sonra novbeti middleware cagira bilmez.
 Map  =>  Middlewared'dan sonra novbeti middleware cagira bilir.
 MapWhen  =>  Middlewared'dan sonra novbeti middleware cagira bilir. Yoxlanis isledikde middleware ise dusur
 */

//app.Use(async (context, next) => {
//    Console.WriteLine("Worked");
//    await next(); // Diger middlewarei isledir
//    Console.WriteLine("Worked2");

//});

//app.Run(async (context) => {
//    Console.WriteLine("Worked3");
//});

//app.Map("/test", app => {
//    app.Run(async context => {
//        await context.Response.WriteAsync("Hello World!");
//    });

//    app.Use(async (context, next) => {
//        await context.Response.WriteAsync("Hello World!");
//        await next();
//        await context.Response.WriteAsync("Hello World! End");
//    });
//});

//app.MapWhen(context => context.Request.Query.ContainsKey("id"), app => {
//    app.Use(async (context, next) => {
//        await context.Response.WriteAsync("Hello World!");
//        await next();
//        await context.Response.WriteAsync("Hello World! End");
//    });
//});

#endregion

#region Extension Middlewares
// app.UseMiddleware<LogMiddleware>();
app.UseMyLogMiddleware();
#endregion

#region MVC

#endregion

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
