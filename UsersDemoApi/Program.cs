using UsersDemoApi.Repositories;



var builder = WebApplication.CreateBuilder(args);

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.AllowAnyOrigin();//ANY PORT
                          policy.AllowAnyHeader();
                          policy.AllowAnyMethod();

                      });
});


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//--------------------------------------------------------------------------------
//--Create Singelton opbject used by anywhere in the application
//--any time this is in the controller constructor it will be injected automaticlly 
//--into constractor
builder.Services.AddSingleton<IUserRepository,DbUserRepository>();
builder.Services.AddSingleton<CompaniesRepository>();
var app = builder.Build();
//--------------------------------------------------------------------------------


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
///**enable run static files (Client APP live and hosted together with server origion)
app.UseStaticFiles();
app.MapControllers();
app.UseCors(MyAllowSpecificOrigins);
app.Run();
