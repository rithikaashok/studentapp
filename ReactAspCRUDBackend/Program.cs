using Microsoft.EntityFrameworkCore;
using ReactAspCRUDBackend.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<StudentDbContext>(options =>
   options.UseSqlServer(builder.Configuration.GetConnectionString("StudentDbContext")));

var app = builder.Build();

app.UseCors(policy => policy.AllowAnyHeader()
                            .AllowAnyMethod()
                            .SetIsOriginAllowed(origin => true)
                            .AllowCredentials());

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.MapControllers();

// Only use HTTPS redirection in Production
if (!app.Environment.IsDevelopment())
{
    app.UseHttpsRedirection();
}

app.Run();
