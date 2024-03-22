using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ICE_Task_One.Data;
using ICE_Task_One.Models;
using System;
using System.Linq;

namespace ICE_Task_One.Models;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new ICE_Task_OneContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<ICE_Task_OneContext>>()))
        {
            // Look for any movies.
            if (context.Books.Any())
            {
                return;   // DB has been seeded
            }
            context.Books.AddRange(
                new Books
                {
                    Title = "When Harry Met Sally",
                    Author = "Steven King",
                    Genre = "Romantic Comedy",
                    Rating = "R",
                    Price = 7.99M
                },
                new Books
                {
                    Title = "Ghostbusters ",
                    Author = "Michael Joe",
                    Genre = "Comedy",
                    Rating = "R",
                    Price = 8.99M
                },
                new Books
                {
                    Title = "Ghostbusters 2",
                    Author = "Dorthy Goodman",
                    Genre = "Comedy",
                    Rating = "R",
                    Price = 9.99M
                },
                new Books
                {
                    Title = "Rio Bravo",
                    Author = "JG Queintal",
                    Genre = "Western",
                    Rating = "R",
                    Price = 3.99M
                }
            );
            context.SaveChanges();
        }
    }
}