using Microsoft.EntityFrameworkCore;
using WebListOfBooks.DbStuff;
using WebListOfBooks.Services;

var builder = WebApplication.CreateBuilder(args);

var connectionString = "Server=(localdb)\\MSSQLLocalDB; Database=WebListOfBooks; Integrated Security=True";
builder.Services.AddDbContext<WebDbContext>(x => x.UseSqlServer(connectionString));

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<BookBuilder>();

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
    pattern: "{controller=Books}/{action=Index}/{id?}");

app.Run();
