using Godix.AspNetCoreScaffold.Crqs.Application;
using Godix.AspNetCoreScaffold.Crqs.Infrastructure;
using Godix.AspNetCoreScaffold.Crqs.Web.Extensions;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddApplication()
    //.AddPresentation()
    .AddInfrastructure(builder.Configuration);

builder.Services.AddEndpoints(Assembly.GetExecutingAssembly());

var app = builder.Build();

app.MapEndpoints();

app.MapGet("/", () => "Hello World!");

await app.RunAsync();

