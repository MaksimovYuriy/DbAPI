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

DBController dBController = new DBController();
Aim newAim1 = new Aim() { Name = "Набрать вес" };
Aim newAim2 = new Aim() { Name = "Сохранять вес" };
dBController.AddAim(newAim1);
dBController.AddAim(newAim2);

app.Run();