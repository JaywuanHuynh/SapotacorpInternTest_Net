using Microsoft.EntityFrameworkCore;
using TestAPI.Models;
using TestAPI.Context;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<TestDBContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
});
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
