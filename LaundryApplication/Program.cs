using LaundryApplication.Shared;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Add singletons for shared access components.  These should all be implementations of abstractions that the consumers will depend upon
builder.Services.AddSingleton<IStorage, MemoryFileStorage>();
builder.Services.AddSingleton<ISessionInfo, SessionManager>();
builder.Services.AddSingleton<IPricing, PriceManager>();

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromSeconds(3600);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

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

app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "forLogin",
    pattern: "{controller=Home}/{action=Login}/{id?}");

app.MapControllerRoute(
    name: "forCreate",
    pattern: "{controller=Home}/{action=CreateAccount}/{id?}");

app.MapControllerRoute(
    name: "forCheckout",
    pattern: "{controller=Home}/{action=Checkout}/{id?}");

app.Run();
