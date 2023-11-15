namespace TexbotApi;

using Microsoft.EntityFrameworkCore;
using TexbotApi.Models;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        string? connString = builder.Configuration.GetConnectionString("Default");
        var serverVersion = ServerVersion.AutoDetect(connString);
        builder.Services.AddDbContext<ApiContext>(
                (dbContextOptions) => dbContextOptions.UseMySql(connString, serverVersion).LogTo(Console.WriteLine, LogLevel.Information).EnableSensitiveDataLogging().EnableDetailedErrors()
        );

        builder.Services.AddControllers();
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

        app.UseAuthorization();


        app.MapControllers();

        app.Run();
    }
}
