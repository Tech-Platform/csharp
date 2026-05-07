var builder = WebApplication.CreateBuilder(args);

// Configura os serviços que serão usados pela aplicação.
// Esses serviços são registrados no container de injeção de dependência.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
// Registra os controllers da API para que as rotas sejam resolvidas.
builder.Services.AddControllers();
// Registra o gerador do Swagger/OpenAPI para a documentação interativa.
builder.Services.AddSwaggerGen();
// Registra o repositório de clientes em memória como singleton.
builder.Services.AddSingleton<ICustomerRepository, InMemoryCustomerRepository>();
// Registra o caso de uso de cadastro de cliente como scoped.
builder.Services.AddScoped<AddCustomerUseCase>();

var app = builder.Build();

// Configura o pipeline de requisições HTTP.
if (app.Environment.IsDevelopment())
{
    // Mapeia o endpoint OpenAPI apenas em desenvolvimento.
    app.MapOpenApi();
}

// Ativa o JSON do Swagger e a interface do Swagger UI.
app.UseSwagger();
app.UseSwaggerUI();

// Mapeia as rotas dos controllers para a API.
app.MapControllers();

// Redirecionamento HTTPS está comentado para evitar problemas se não houver porta HTTPS configurada.
// app.UseHttpsRedirection();

// Dados de exemplo para o endpoint de previsão do tempo.
var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
    // Gera uma lista de previsões de tempo com dados fictícios.
    var forecast =  Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast");

// Endpoints de saúde básica da API.
app.MapGet("/", () => "API is running");

// Inicia o servidor web e começa a ouvir requisições.
app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
