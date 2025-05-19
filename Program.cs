using Microsoft.EntityFrameworkCore;
using TodoList.Data;

var builder = WebApplication.CreateBuilder(args);

//Configura EF Core com SQLite
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=TodoList.db"));

// Configurar Controllers
builder.Services.AddControllers();

var app = builder.Build();

app.MapControllers();

app.Run();