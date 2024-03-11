using BookStore.Context;
using BookStore.Interface;
using BookStore.Repository;
using Microsoft.EntityFrameworkCore;

namespace BookStore;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddDbContext<BookStoreContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

        builder.Services.AddScoped<IBookRepository, BookRepository>();
        //services.AddScoped<IBookRepository, BookRepository>();


        builder.Services.AddCors(options =>
        {
            options.AddPolicy("AllowSabrin", builder =>
            {
                builder.WithOrigins("http://localhost:4200")
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            });
        });

        //builder.Services.AddCors(options =>
        //{

        //    options.AddDefaultPolicy(
        //        policy =>
        //        {
        //            policy.AllowAnyOrigin()
        //                .AllowAnyHeader()
        //                .AllowAnyMethod();
        //        });
        //});

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
            app.UseDeveloperExceptionPage();
        }
        //app.UseCors("AllowAllOrigins");
        app.UseCors("AllowSabrin");

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();
 
        app.Run();
    }
}

