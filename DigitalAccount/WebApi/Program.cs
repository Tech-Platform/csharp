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
// Registra os casos de uso de atualização e deleção de cliente.
builder.Services.AddScoped<UpdateCustomerUseCase>();
builder.Services.AddScoped<DeleteCustomerUseCase>();

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

// Endpoints de saúde básica da API.
app.MapGet("/", () => "API is running");

// Inicia o servidor web e começa a ouvir requisições.
app.Run();

// Sample endpoints removed
