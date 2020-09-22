using FPLDataAPI.Entities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace FPLDataAPI.Data
{
    public class DbContextSeed
    {
        public static async Task SeedAsync(AppDbContext context, ILoggerFactory loggerFactory)
        {
            try
            {
                if (!context.Teams.Any())
                {
                    var teamsData = File.ReadAllText("./Data/SeedData/teams.json");
                    var teams = JsonSerializer.Deserialize<List<Team>>(teamsData);

                    foreach (var team in teams)
                    {
                        context.Teams.Add(team);
                    }

                    await context.SaveChangesAsync();
                }

                if (!context.Players.Any())
                {
                    var playersData = File.ReadAllText("./Data/SeedData/players.json");
                    var players = JsonSerializer.Deserialize<List<Player>>(playersData);

                    foreach (var player in players)
                    {
                        context.Players.Add(player);
                    }

                    await context.SaveChangesAsync();
                }

            }
            catch (Exception ex)
            {
                var logger = loggerFactory.CreateLogger<AppDbContext>();
                logger.LogError(ex.Message);
            }
        }
    }
}
