using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RandomNumbers.Model;

namespace RandomNumbers.Database
{
    public class DbInitializer : IDbInitializer
    {
        private readonly IServiceScopeFactory _scopeFactory;
        private readonly IConfiguration _configuration;

        public DbInitializer(IServiceScopeFactory scopeFactory, IConfiguration configuration)
        {
            this._scopeFactory = scopeFactory;
            _configuration = configuration;
        }

        public void Initialize()
        {
            using (var serviceScope = _scopeFactory.CreateScope())
            {
                using (var context = serviceScope.ServiceProvider.GetService<DataContext>())
                {
                    context.Database.EnsureCreated();
                    context.Database.Migrate();
                }
            }
        }

        public void SeedData()
        {
            using (var serviceScope = _scopeFactory.CreateScope())
            {
                using (var context = serviceScope.ServiceProvider.GetService<DataContext>())
                {
                    //add next matches
                    DateTime lastMatch;

                    if (context.Matches.Any())
                    {
                        lastMatch = context.Matches.Max(x => x.EndTime);
                    }
                    else {
                        lastMatch = DateTime.Now;
                    }

                    if ((lastMatch - DateTime.Now).TotalHours<2)
                    {
                        for (int i =1; i<100; i=i+2 )
                        {
                            context.Matches.Add(new Match() {
                                MatchId = Guid.NewGuid(), 
                                StartTime = lastMatch.AddMinutes(i*2), 
                                EndTime = lastMatch.AddMinutes(i*2+2) }
                            );
                    }
                        
                    }
                    //add default users
                    if (!context.Users.Any())
                    {
                        var admin = new User { UserId = Guid.NewGuid(), Login = "admin", Password = "admin", Name = "administrator" };
                        var user1 = new User { UserId = Guid.NewGuid(), Login = "user1", Password = "user1", Name = "user1" };

                        context.Users.Add(admin);
                        context.Users.Add(user1);
                    }

                    //just a sample result
                    if (!context.Results.Any())
                    {
                        var result = new Result { ResultId = Guid.NewGuid(), UserId = Guid.NewGuid(), Number =1 };

                        context.Results.Add(result);
                    }

                    context.SaveChanges();
                }
            }
        }
    }
}
