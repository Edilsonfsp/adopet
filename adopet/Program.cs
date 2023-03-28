using adopet.endpoints.tutor;
using adopet.infra.data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var service = builder.Services;
var configuration = builder.Configuration;

service.AddDbContext<ApplicationDbContext>(
	options => options.UseMySql(configuration["dataDase:mySqlString"],
	Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.25-mysql"))
	);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

var summaries = new[]
{
		"Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
	var forecast = Enumerable.Range(1, 5).Select(index =>
			new WeatherForecast
			(
					DateTime.Now.AddDays(index),
					Random.Shared.Next(-20, 55),
					summaries[Random.Shared.Next(summaries.Length)]
			))
			.ToArray();
	return forecast;
})
.WithName("GetWeatherForecast");

//Tutors Endpoints
app.MapMethods(TutorPost.Template, TutorPost.Methods, TutorPost.Handle);
app.MapMethods(TutorGetById.Template, TutorGetById.Methods, TutorGetById.Handle);
app.MapMethods(TutorGetAll.Template, TutorGetAll.Methods, TutorGetAll.Handle);
app.MapMethods(TutorPut.Template, TutorPut.Methods, TutorPut.Handle);
app.MapMethods(TutorDelete.Template, TutorDelete.Methods, TutorDelete.Handle);

app.Run();

internal record WeatherForecast(DateTime Date, int TemperatureC, string? Summary)
{
	public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}