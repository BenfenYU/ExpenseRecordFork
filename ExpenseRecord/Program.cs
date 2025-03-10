using ExpenseRecord.Interfaces;
using ExpenseRecord.Services;
using ExpenseRecord.SettingDTOs;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();

//
builder.Services.Configure<ExpenseStorageDBSetting>(builder.Configuration.GetSection("ExpenseStorageDB"));
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IExpenseRecordsService, ExpenseRecordsRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html");
;

app.Run();

public partial class Program { }