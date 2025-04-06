var builder = WebApplication.CreateBuilder(args);
builder.WebHost.UseUrls("http://localhost:5000");

// 1. Add services to the container
builder.Services.AddCors(options =>
{
    options.AddPolicy("MyCorsPolicy", policyBuilder =>
    {
        policyBuilder
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});

// 2. Build the application
var app = builder.Build();

// 3. Use the CORS policy
app.UseCors("MyCorsPolicy");

// 4. Map your endpoints
app.MapGet("/api/products", () =>
{
    return new[]
    {
        new { Id = 1, Name = "Laptop", Price = 1200.50, Stock = 25 },
        new { Id = 2, Name = "Headphones", Price = 50.00, Stock = 100 }
    };
});



// 5. Run the app
app.Run();
