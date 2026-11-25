using JobTot.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddInfrastructure();

var app = builder.Build();

// TODO: Add application endpoints as features are implemented.
app.MapGet("/", () => Results.Ok(new { name = "JobTot API", status = "Skeleton" }));

app.Run();
