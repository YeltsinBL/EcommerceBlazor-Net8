using EcommerceServer.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews(); // Indicamos que utilizaremos Controllers de Api y Vistas de Razor
builder.Services.AddRazorPages(); // Indicamos que usaremos Razor

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// Al iniciar la App
// Configuramos el DbContext con la conexion a la BD
builder.Services.AddDbContext<AppDbContext>(options=>{
    options.UseSqlServer(builder.Configuration.GetConnectionString("SQLConnection")?? throw new InvalidOperationException("No se logro conectar a la BD"));
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseWebAssemblyDebugging(); // Indicamos que usaremos WebAssembly
}

app.UseHttpsRedirection();
app.UseBlazorFrameworkFiles();// Marco de trabajo de blazor
app.UseStaticFiles(); // para tener acceso al wwwroot del client
app.UseAuthorization();

app.MapRazorPages(); // para tener autorización a los razorpages 
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();
