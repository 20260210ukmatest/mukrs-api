using Microsoft.EntityFrameworkCore;
using MahjongUKRankingSystem.DbModels;

var builder = WebApplication.CreateBuilder(args);

var connectionString =
    builder.Configuration.GetConnectionString("MukrsConnection")
        ?? throw new InvalidOperationException("Connection string not found.");

builder.Services.AddDbContext<MukrsContext>(options =>
    options.UseNpgsql(connectionString));

var app = builder.Build();

app.Run();
