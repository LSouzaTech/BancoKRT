using Amazon.DynamoDBv2;
using BancoKRT.Repositories;
using BancoKRT.Services;

var builder = WebApplication.CreateBuilder(args);

// Adiciona serviços ao contêiner
builder.Services.AddControllers();
builder.Services.AddAWSService<IAmazonDynamoDB>();
builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
builder.Services.AddScoped<ClienteService>();

var app = builder.Build();

app.UseAuthorization();
app.MapControllers();
app.Run();

