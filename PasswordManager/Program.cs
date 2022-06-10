using Microsoft.EntityFrameworkCore;
using PasswordManager.Models;

var builder = WebApplication.CreateBuilder(args);

string con = "Server=(localdb)\\mssqllocaldb;Database=usersdbstore;Trusted_Connection=True;";

// ������������� �������� ������
builder.Services.AddDbContext<PasswordsContext>(options => options.UseSqlServer(con));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options => options.AddDefaultPolicy(policy => 
{                policy.AllowAnyOrigin()
                 .AllowAnyMethod()
                 .AllowAnyHeader()
                 .AllowCredentials();
}));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
