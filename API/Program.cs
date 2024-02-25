using API;
using API.Controllers;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

DBController dbc = new DBController();
Request req = new Request()
{
    Name = "Куриное филе",
    Kcal = 113,
    Proteins = 24,
    Fats = 2,
    Carbohydrates = 0
};
dbc.AddRequest(req);

app.Run();