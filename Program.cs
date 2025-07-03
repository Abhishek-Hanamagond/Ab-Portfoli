using Microsoft.EntityFrameworkCore;
using portfolio.Data;
using portfolio.Models;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>(options =>
     options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        policy =>
        {
            policy.AllowAnyOrigin()
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});
var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    dbContext.Database.Migrate();
    // Seed sample data if Projects table is empty
    if (!dbContext.Projects.Any())
    {
        dbContext.Projects.AddRange(
            new Projects { ID = 1, Title = "Portfolio Website", Description = "My personal portfolio site.", ImagePath = "/images/portfolio.png" }
        ); 
        dbContext.SaveChanges();
    }
    if (!dbContext.CaseStudy.Any())
    {
        dbContext.CaseStudy.AddRange(
            new CaseStudy { Id = 1, title = "Portfolio Website", problem = "My personal portfolio site.", imageUrl = "/images/portfolio.png", solution = "", outcome = "", imageHint = "", tags = ["a", "b"] }
        );
        dbContext.SaveChanges();
    }
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("AllowAll");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
