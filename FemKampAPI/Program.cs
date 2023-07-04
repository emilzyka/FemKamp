using FemKampAPI.Database;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


// Database services
builder.Services.AddDbContext<AppDbContext>(opt =>
    opt.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

// Mapper services
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Validation services

// Logging services

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
