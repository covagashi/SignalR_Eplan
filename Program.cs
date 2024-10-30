using EGC.Hubs;
using EGC.Controllers;

var builder = WebApplication.CreateBuilder(args);

// SignalR
builder.Services.AddSignalR();

// Agregar servicios de controladores
builder.Services.AddControllers();

builder.WebHost.ConfigureKestrel(serverOptions =>
{
    serverOptions.ListenAnyIP(5210);
    serverOptions.ListenAnyIP(443);
});

var app = builder.Build();

// Archivos estáticos
app.UseStaticFiles();
app.UseRouting();

// Mapear controladores
app.MapControllers();

// SignalR Hub
app.MapHub<TestHub>("/testHub");

// Ruta por defecto para index.html
app.MapGet("/", async (HttpContext context) =>
{
    context.Response.ContentType = "text/html";
    await context.Response.SendFileAsync("wwwroot/index.html");
});

app.Run();