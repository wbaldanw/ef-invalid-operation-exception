// See https://aka.ms/new-console-template for more information
using Microsoft.EntityFrameworkCore;
using TestEF;

Console.WriteLine("Hello, World!");

using var context = new AppDbContext();

//The data seed for this POC is in the migration file

//works fine
var dataAsNoTracking = context.Places.AsNoTracking().Include(x => x.Organization).FirstOrDefault();

//This will throw an exception
var data = context.Places.Include(x => x.Organization).FirstOrDefault();

Console.ReadLine();