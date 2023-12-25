var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews(); // Los controllers tendrán una vista
builder.Services.AddRazorPages(); // Indicamos que usaremos Razor

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
