using BuyTickets.Data.Enums;
using BuyTickets.Data.Static;
using BuyTickets.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BuyTickets.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var servicescope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = servicescope.ServiceProvider.GetService<AppDbContext>();
                context.Database.EnsureCreated();

                //cinema
                if (!context.Cinemas.Any())
                {
                    context.Cinemas.AddRange(new List<Cinema>()
                    {
                        new Cinema()
                        {
                            Name = "Cinema 1",
                            Description = "This is the description of the first cinema"
                        },
                        new Cinema()
                        {
                            Name = "Cinema 2",
                            Description = "This is the description of the second cinema"
                        },
                        new Cinema()
                        {
                            Name = "Cinema 3",
                            Description = "This is the description of the third cinema"
                        },
                        new Cinema()
                        {
                            Name = "Cinema 4",
                            Description = "This is the description of the fourth cinema"
                        },
                        new Cinema()
                        {
                            Name = "Cinema 5",
                            Description = "This is the description of the fifth cinema"
                        },
                    });
                    context.SaveChanges();
                }
                //movie
                if (!context.Movies.Any())
                {
                    context.Movies.AddRange(new List<Movie>()
                    {
                        new Movie()
                        {
                            Name = "The Sixth Sense",
                            Description = "The Sixth Sense is a 1999 American psychological thriller film written and directed by M. Night Shyamalan. It stars Bruce Willis as a child psychologist whose patient (Haley Joel Osment) claims he can see and talk to the dead.",
                            Price = 35.50,
                            Image = "https://wallpapercave.com/wp/wp4120771.jpg",
                            StartDate = DateTime.Now.AddDays(-10),
                            EndDate = DateTime.Now.AddDays(10),
                            CinemaId = 3,
                            MovieCategory = MovieCategory.Suspense
                        },
                        new Movie()
                        {
                            Name = "Nobody",
                            Description = "A docile family man slowly reveals his true character after his house gets burgled by two petty thieves, which, coincidentally, leads him into a bloody war with a Russian crime boss.",
                            Price = 19.50,
                            Image = "https://th.bing.com/th/id/R.6a0a61b8c3485adf7579d0b42a1983a0?rik=H7QoD%2bQxLZYQJA&pid=ImgRaw&r=0",
                            StartDate = DateTime.Now,
                            EndDate = DateTime.Now.AddDays(3),
                            CinemaId = 1,
                            MovieCategory = MovieCategory.Action
                        },
                        new Movie()
                        {
                            Name = "The Shining",
                            Description = "A family heads to an isolated hotel for the winter where a sinister presence influences the father into violence, while his psychic son sees horrific forebodings from both past and future.",
                            Price = 37.50,
                            Image = "https://wallpapercave.com/wp/wp1901282.jpg",
                            StartDate = DateTime.Now,
                            EndDate = DateTime.Now.AddDays(7),
                            CinemaId = 4,
                            MovieCategory = MovieCategory.Horror
                        },
                        new Movie()
                        {
                            Name = "Free Solo",
                            Description = "FREE SOLO is both an edge-of-your seat thriller and an inspiring portrait of an athlete who exceeded our current understanding of human physical and mental potential.",
                            Price = 39.50,
                            Image = "https://media-cache.cinematerial.com/p/500x/t4joxqjv/free-solo-movie-poster.jpg?v=1539514421",
                            StartDate = DateTime.Now.AddDays(-10),
                            EndDate = DateTime.Now.AddDays(-5),
                            CinemaId = 1,
                            MovieCategory = MovieCategory.Documentary
                        },
                        new Movie()
                        {
                            Name = "Megamind",
                            Description = "Megamind is a 2010 American computer-animated superhero comedy film directed by Tom McGrath, produced by DreamWorks Animation, and distributed by Paramount Pictures. ",
                            Price = 19.50,
                            Image = "https://th.bing.com/th/id/OIP.8OnlBCKPLKe1cig7kzj92AHaLk?pid=ImgDet&rs=1",
                            StartDate = DateTime.Now.AddDays(-10),
                            EndDate = DateTime.Now.AddDays(-2),
                            CinemaId = 1,
                            MovieCategory = MovieCategory.Cartoon
                        },
                        new Movie()
                        {
                            Name = "The Hateful Eight",
                            Description = "The Hateful Eight (sometimes marketed as The H8ful Eight) is a 2015 American western mystery thriller film, written and directed by Quentin Tarantino. ",
                            Price = 49.50,
                            Image = "https://th.bing.com/th/id/R.4d9fa8b2905f5fdde2f490b24cdab90e?rik=dwIlG4Om%2f7IhYg&riu=http%3a%2f%2fwww.filmofilia.com%2fwp-content%2fuploads%2f2015%2f11%2fHateful_Eight_Payoff_poster.jpg&ehk=CP58Ig%2fUuuhPG2RWrZli3TWx0%2fG9Mf%2bVlgsu03uGWRI%3d&risl=&pid=ImgRaw&r=0",
                            StartDate = DateTime.Now.AddDays(3),
                            EndDate = DateTime.Now.AddDays(20),
                            CinemaId = 1,
                            MovieCategory = MovieCategory.Drama
                        }
                    });
                    context.SaveChanges();
                }

            }

        }

        public static async Task SeedUsersAndRolesASync(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                //roles 
                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));

                if (!await roleManager.RoleExistsAsync(UserRoles.User))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.User));

                //users
                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
                string adminUserEmail = "admin@buytickets.com";

                var adminUser = await userManager.FindByEmailAsync(adminUserEmail);
                if(adminUser == null)
                {
                    var newAdminUser = new ApplicationUser()
                    {
                        FullName = "Admin User",
                        UserName = "admin-user",
                        Email = adminUserEmail,
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newAdminUser, "Coding@1234?");
                    await userManager.AddToRoleAsync(newAdminUser, UserRoles.Admin);
                }
                
                string appUserEmail = "user@buytickets.com";
                var appUser = await userManager.FindByEmailAsync(appUserEmail);
                if (appUser == null)
                {
                    var newAppUser = new ApplicationUser()
                    {
                        FullName = "Application User",
                        UserName = "app-user",
                        Email = appUserEmail,
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newAppUser, "Coding@1234?");
                    await userManager.AddToRoleAsync(newAppUser, UserRoles.User);
                }
            }
        }
    }
}


