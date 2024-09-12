using Data.BlazorDatabaseApis;
using Data.BlazorDatabaseApis.DataOperations.EFDataOperations;
using Data.BlazorDatabaseApis.Interfaces;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

#region Injections
builder.Services.AddScoped<IUserDataOperations, EFUserDataOperations>();

builder.Services.AddScoped(provider =>
{
    return new DiscordEntities();
});
#endregion

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

WebApplication app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "BlazorDatabaseApis v1");
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();