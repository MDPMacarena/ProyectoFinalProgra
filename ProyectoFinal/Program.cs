using Microsoft.EntityFrameworkCore;
using ProyectoFinal.Models;
using ProyectoFinal.Models.DTOs;
using ProyectoFinal.Repositories;
using ProyectoFinal.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddDbContext<CodePlaygroundContext>();

builder.Services.AddScoped<CodePlaygroundService>();
builder.Services.AddScoped(typeof(Repository<>));

var app = builder.Build();

app.UseFileServer();
app.MapControllers();
app.Run();