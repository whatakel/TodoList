using Microsoft.AspNetCore.Builder;
using TodoList.Routes;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGetRotas(); // adiciona as rotas que criamos

app.Run();