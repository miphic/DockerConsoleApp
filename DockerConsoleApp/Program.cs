// See https://aka.ms/new-console-template for more information
using hw4.Domain;
using hw4Sber.Controlllers;
using hw4Sber.Domain.Entity;
using hw4Sber.Repos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.Extensions.Configuration;
using System;
using System.Configuration;
using System.IO;




public static class Program
{
    public static Random rand = new Random();

    public static readonly string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
    public static readonly string digits = "0123456789";

    public static IConfiguration Config = new ConfigurationBuilder()
                        .SetBasePath(Directory.GetCurrentDirectory())
                        .AddJsonFile("appsettings.json", optional: false).Build();
    private static void Main(string[] args)
    {
        using (DataContext db = new DataContext())
        {            
            if (db != null)
            {
                db.Database.AutoSavepointsEnabled = true;
                db.Database.Migrate();
                db.SaveChanges();
                db.Database.EnsureDeleted();
                db.Database.EnsureCreated();
                db.SaveChanges();
                //db.Update(db.Database);//System.InvalidOperationException: "The entity type 'DatabaseFacade' was not found. Ensure that the entity type has been added to the model."


                var user = db.Users.Add(new User()
                {
                    FirstName = "Ivan",
                    LastName = "Ivanov",
                    Email = "IvanovIvan@mail.org",
                });
                db.SaveChanges();
                var acc = db.Accounts.Add(new Account()
                {
                    UserId = user.Property<Guid>("Id").CurrentValue,
                    Ballance = new decimal(
                            123 * rand.Next(0, 10000) 
                            /
                            rand.Next(1, 3)),
                    strNumber = GetNewAccountNumber(),
                });
                db.SaveChanges();
                var opp = db.Operations.Add(new Operation()
                {
                    Account = acc.Property<Guid>("Id").CurrentValue,
                    Date = //DateTime.SpecifyKind(DateTime.Now.AddDays(rand.Next(0, 20)), DateTimeKind.Utc).AddHours(TimeZone.CurrentTimeZone..GetUtcOffset().TotalHours),
                            DateTime.Now.AddDays(rand.Next(0,20)).ToUniversalTime(),
                    Delta = rand.Next(10, 10000) / rand.Next(1, 10)
                });                
                db.SaveChanges();

                user = db.Users.Add(new User() { 
                    FirstName = "Petor",
                    LastName = "Petrov",
                    Email = "petrov@gmail.ru",
                });
                //db.SaveChanges();



                acc = db.Accounts.Add(new Account()
                {
                    UserId = user.Property<Guid>("Id").CurrentValue,
                    Ballance = new decimal(),
                    strNumber = string.Empty,
                });
                //db.SaveChanges();





                //var acc_contr = new AccountController(db.repo)
            }
        }
    }

    public static string RandomString(string chars, int length)
    {
        return new string(Enumerable.Repeat(chars, length)
            .Select(s => s[rand.Next(s.Length)]).ToArray());
    }

    private static string GetNewAccountNumber() 
        => RandomString(digits, 20);
}

