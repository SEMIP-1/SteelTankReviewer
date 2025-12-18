using SteelTankReviewer.Api.Auth;
using SteelTankReviewer.Application.Abstractions.Security;
using SteelTankReviewer.Application.Projects.CreateProject;
using SteelTankReviewer.Application.Projects.GetProjects;

var builder = WebApplication.CreateBuilder(args);

// Add controllers
builder.Services.AddControllers();

#region DependencyInjection

// Dependency Injection for Engineer Context
builder.Services.AddScoped<IEngineerContext, EngineerContext>();

// Dependency Injection for CreateProjectHandler
builder.Services.AddScoped<CreateProjectHandler>();

// Dependency Injection for GetProjectsHandler
builder.Services.AddScoped<GetProjectsHandler>();

#endregion
// Add services to the container.

var app = builder.Build();

// Configure the HTTP request pipeline.

#region Middleware

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

#endregion

app.Run();