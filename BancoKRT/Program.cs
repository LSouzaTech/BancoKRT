using Amazon.DynamoDBv2;
using BancoKRT.Repositories;
using BancoKRT.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddAWSService<IAmazonDynamoDB>();
builder.Services.AddScoped<IClienteRepository, GestaoLimiteRepository>();
builder.Services.AddScoped<GestaoLimiteService>();
builder.Services.AddScoped<PixService>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
