using hero_api_dotnet.interfaces;
using hero_api_dotnet.Models;
using Microsoft.EntityFrameworkCore;
using static hero_api_dotnet.Context.HeroeDbContext;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var connectionString = builder.Configuration.GetConnectionString("Default")
    ?? "Data Source=heroes.db";

builder.Services.AddDbContext<hero_api_dotnet.Context.HeroeDbContext.HeroesDbContext>(opt =>
    opt.UseSqlite(connectionString));
var app = builder.Build();

app.MapGet("/heroes", async (HeroesDbContext db) => await db.Heroes.ToListAsync());
//app.MapGet("/heroes/{id}", );
app.MapPost("/heroes", async (HeroesDbContext db,Hero h) => { db.Heroes.Add(h); await db.SaveChangesAsync(); return Results.Created($"/heroes/{h.Id}", h); });
app.MapPut("/heroes/{id}", (int id, IHero hero) => $"heroi {id} atualizado");

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.Run();
