﻿using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SalesMvc.Data;
using SalesMvc.Services;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

string mysqlconnection = 
    builder.Configuration.GetConnectionString("SalesMvcContext");

builder.Services.AddDbContext<SalesMvcContext>(options =>
    options.UseMySql(mysqlconnection,
        ServerVersion.AutoDetect(mysqlconnection)));

builder.Services.AddScoped<SeedingService>();
builder.Services.AddScoped<SellerService>();
builder.Services.AddScoped<DepartmentService>();
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

var option = new DbContextOptionsBuilder<SalesMvcContext>()
    .UseMySql(mysqlconnection, ServerVersion.AutoDetect(mysqlconnection)).Options
    ;
var dbContext = new SalesMvcContext(option);
var seedingService = new SeedingService(dbContext);
seedingService.Seed();

var enUs = new CultureInfo("en-US");
var localizationOptions = new RequestLocalizationOptions { 
    DefaultRequestCulture = new RequestCulture(enUs),
    SupportedCultures = new List<CultureInfo> { enUs },
    SupportedUICultures = new List<CultureInfo> { enUs }
};

app.UseRequestLocalization(localizationOptions);
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
