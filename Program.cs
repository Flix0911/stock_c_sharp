using api.Data;
using api.Interfaces;
using api.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// add controller
builder.Services.AddControllers();

// hook up db context ~ must be before app
builder.Services.AddDbContext<ApplicationDBContext>(options => {
    // will go to app.settings json
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
});

// add our services
builder.Services.AddScoped<IStockRepository, StockRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
// this is what is controlling the http request pipeline

if (app.Environment.IsDevelopment())
// where your middleware will be
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Apply database migrations on application startup
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDBContext>();
    dbContext.Database.Migrate();
}

// mapcontroller
app.MapControllers();

app.Run();

