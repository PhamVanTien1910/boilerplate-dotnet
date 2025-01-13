using DotnetBoilerplate.Api;
using DotnetBoilerplate.Api.Filters;
using DotnetBoilerplate.Api.Middlewares;
using DotnetBoilerplate.Api.Validators;
using DotnetBoilerplate.Application.Dtos;
using FluentValidation;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Add validators from the current assembly
builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

// Add validation filter globally
builder.Services.AddControllers(options =>
{
    options.Filters.Add<ValidationFilter>();
});

// Add Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "DotnetBoilerplate", Version = "v1" });

    // Add JWT Bearer authorization to Swagger
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "JWT Authorization header using the Bearer scheme." +
                      "Enter 'Bearer' [space] and then your token in the text input below." +
                      "Example: 'Bearer 12345abcdef'",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement()
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                },
                Scheme = "oauth2",
                Name = "Bearer",
                In = ParameterLocation.Header
            },
            new List<string>()
        }
    });
});

// Add HttpContextAccessor to access HTTP context
builder.Services.AddHttpContextAccessor();

// Add application DI for services
builder.Services.AddAppDI(builder.Configuration);

var app = builder.Build();

// Health check endpoint
app.MapGet("/", async context =>
{
    await context.Response.WriteAsync("Server live!");
});

// Use custom exception middleware
app.UseMiddleware<ExceptionMiddlewares>();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger(); // Enable Swagger UI in development environment
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();  // Enforce HTTPS
app.UseAuthentication();    // Enable authentication middleware
app.UseAuthorization();     // Enable authorization middleware

app.MapControllers();       // Map controller routes

app.Run();  // Run the application
