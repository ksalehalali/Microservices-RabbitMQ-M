using Orchestrator.Presistance;
using Microsoft.EntityFrameworkCore;
using Core;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<OrchSagaDbContext>((provider, dbContextBuilder) =>
{
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    dbContextBuilder.UseSqlServer(connectionString, sqlServerOptionsAction: sqlOptions =>
    {
        sqlOptions.MigrationsAssembly(typeof(OrchSagaDbContext).Assembly.FullName);
        sqlOptions.MigrationsHistoryTable($"__{nameof(OrchSagaDbContext)}");
    });
});

builder.Services.AddHostedService<RecreateDatabaseHostedService<OrchSagaDbContext>>();


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
