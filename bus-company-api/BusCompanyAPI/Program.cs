using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using Amazon.Runtime;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddSingleton<IAmazonDynamoDB>(s =>
{
    var creds = new BasicAWSCredentials("fakeMyKeyId", "fakeSecretAccessKey");
    var clientConfig = new AmazonDynamoDBConfig
    {
        ServiceURL = "http://localhost:8000/",
        AuthenticationRegion = "us-east-1"

    };
    return new AmazonDynamoDBClient(creds, clientConfig);
});

var devCorsPolicy = "devCorsPolicy";
builder.Services.AddCors(options =>
{
    options.AddPolicy(devCorsPolicy, builder => {        
        builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();        
    });
});
builder.Services.AddSingleton<IDynamoDBContext, DynamoDBContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(devCorsPolicy);
app.UseAuthorization();

app.MapControllers();

app.Run();
