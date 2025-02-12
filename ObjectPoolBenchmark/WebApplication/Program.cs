using Microsoft.AspNetCore.Mvc;
using PoolsLib;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddSingleton<SimpleCache>();
builder.Services.AddSingleton<ObjectPoolCache>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapGet("/simplecache", ([FromServices] SimpleCache simpleCache, [FromQuery] string key) =>
    {
        var expensiveObject = simpleCache.Get(key);
        simpleCache.Remove(key);
        return Results.Ok();
    })
    .WithName("SimpleCache");

app.MapGet("/objectpoolcache", ([FromServices] ObjectPoolCache objectPoolCache, [FromQuery] string key) =>
    {
        var expensiveObject = objectPoolCache.Get(key);
        objectPoolCache.Remove(key);
        return Results.Ok();
    })
    .WithName("ObjectPoolCache");

app.Run();