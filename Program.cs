using Aura.Data;

var builder = WebApplication.CreateBuilder(args);

// Agrega los servicios al contenedor de DI.
builder.Services.AddControllersWithViews();

// Registra LiteDbService para la inyección de dependencias
builder.Services.AddSingleton<LiteDbService>(new LiteDbService());


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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
