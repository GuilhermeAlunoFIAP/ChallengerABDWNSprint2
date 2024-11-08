using System.Reflection;
using ABDWNSprint1.Persistence;
using ABDWNSprint1.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
builder.Services.AddScoped<IClinicaRepository, ClinicaRepository>();
builder.Services.AddScoped<IRelatorioRepository, RelatorioRepository>();
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(swagger =>
{
    swagger.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Sprint 2 - OdontoPrev",
        Version = "v1",
        Description = "Documentação do Sprint 2 para gerenciamento dos clientes, clinicas e relatórios.",
        Contact = new OpenApiContact()
        {
            
            Name = "Equipe de Desenvolvimento"
        }
    });

    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

    swagger.IncludeXmlComments(xmlPath);
});

builder.Services.AddDbContext<FIAPDbContext>(options =>
{
    options.UseOracle(builder.Configuration.GetConnectionString("OracleFIAPDbContext"));
});

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
