using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using CMSApp.Data;
using CMSApp.Models;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// ������� ����� ��������
builder.Services.AddDbContext<CMSDBContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));

// ������� �������� �������� ���� ��������
builder.Services.AddIdentity<Users, IdentityRole>(options =>
{
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequiredLength = 4;
    options.Password.RequireUppercase = false;
    options.Password.RequireLowercase = false;
    options.User.RequireUniqueEmail = true;
    options.SignIn.RequireConfirmedAccount = false;
    options.SignIn.RequireConfirmedEmail = false;
    options.SignIn.RequireConfirmedPhoneNumber = false;
})
.AddEntityFrameworkStores<CMSDBContext>()
.AddDefaultTokenProviders();

// ����� ����� �������� �� ����� ����� ��������
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Account/Login"; // ����� ���� ���� ����� ������
    });

builder.Services.AddAuthorization(); // ����� �������

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// ����� ��������
app.UseAuthentication(); // ����� ��� �����

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Login}/{id?}");

app.Run();
