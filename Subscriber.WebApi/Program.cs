using Microsoft.EntityFrameworkCore;
using Serilog;
using Subscriber.Data;
using Subscriber.WebApi.Config;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
ConfigurationManager configuration = builder.Configuration;

builder.Services.AddControllers();
builder.Services.ConfigureServices();

builder.Host.UseSerilog((context, configuration) =>
{
    configuration.ReadFrom.Configuration(context.Configuration);
});
builder.Services.AddDbContext<WeightWatcherContext>(option =>
{
    option.UseSqlServer(configuration.GetConnectionString("WeightWatchersConnectionString"));
});

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
app.UseSerilogRequestLogging();
app.UseCors(builder =>
{
    builder
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader();
});
app.UseAuthorization();
app.MapControllers();
app.UseMiddleware(typeof(MiddleWare));
app.Run();
