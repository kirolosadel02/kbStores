using DotNetEnv;
using Microsoft.EntityFrameworkCore;
using src.Shared;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.WebHost.UseUrls("http://0.0.0.0:8081");

// Load the .env file
Env.Load();

// Retrieve the connection string from environment variables
var connectionString = Environment.GetEnvironmentVariable("ConnectionStrings__DefaultConnection");

// Register the database context with the connection string
builder.Services.AddDbContext<kbStoresContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddControllers();

// **Add CORS before building the app**
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder => builder.AllowAnyOrigin()
                          .AllowAnyMethod()
                          .AllowAnyHeader());
});

// Add Swagger
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
});

// **Build the application after configuring services**
var app = builder.Build();

// **Now it is safe to use `app.Services`**
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<kbStoresContext>();
    try
    {
        dbContext.Database.CanConnect();
        Console.WriteLine("Successfully connected to the database!");
    }
    catch (Exception ex)
    {
        Console.WriteLine("Database connection failed: " + ex.Message);
    }
}

// Enable CORS
app.UseCors("AllowAll");

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

// Enable middleware to serve generated Swagger as a JSON endpoint
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
});

app.UseRouting();
app.UseAuthorization();
app.MapControllers();

app.Run();
