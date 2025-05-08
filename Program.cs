using FlexiBooks.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend",
        b => b.WithOrigins("http://localhost:3000")
              .AllowAnyHeader()
              .AllowAnyMethod());
});

// Register EF Core DbContext
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Middleware
app.UseSwagger();
app.UseSwaggerUI();
app.UseCors("AllowFrontend");
app.UseAuthorization();

app.MapControllers();
app.Run();
