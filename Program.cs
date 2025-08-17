using hero_api_dotnet.Dto;
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
app.MapGet("/heroes/{id}", async (HeroesDbContext db, int id) =>
{
    var hero = await db.Heroes.FindAsync(id);
    return hero is null
        ? Results.NotFound(new { message = $"Herói com ID {id} não encontrado." })
        : Results.Ok(hero);
});


app.MapPost("/heroes", async (HeroesDbContext db,Hero h) => { db.Heroes.Add(h); await db.SaveChangesAsync(); return Results.Created($"/heroes/{h.Id}", h); });
app.MapPut("/heroes/{id:int}", async (HeroesDbContext db, int id, HeroDtoUpdate dto) =>
{
    var hero = await db.Heroes.FindAsync(id);
    if (hero is null)
        return Results.NotFound(new { message = $"Herói com ID {id} não encontrado." });

    if (!string.IsNullOrWhiteSpace(dto.Name)) hero.Name = dto.Name;
    if (dto.Type.HasValue) hero.Type= dto.Type.Value;
    if (dto.Sex.HasValue) hero.Sex = dto.Sex.Value;
    if (!string.IsNullOrWhiteSpace(dto.Abilities)) hero.Abilities = dto.Abilities;
    if (!string.IsNullOrWhiteSpace(dto.Superpower)) hero.Superpower = dto.Superpower;

    await db.SaveChangesAsync();
    return Results.Ok(hero);
});

app.MapDelete("/heroes/{id}", async (HeroesDbContext db, int id) => {
    var hero = await db.Heroes.FindAsync(id);
    if (hero is null) return Results.NotFound();
    db.Heroes.Remove(hero);
    await db.SaveChangesAsync();
    return Results.NoContent();
});

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.Run();
