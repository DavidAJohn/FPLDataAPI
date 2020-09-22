using AutoMapper;
using FPLDataAPI.DTOs;
using FPLDataAPI.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FPLDataAPI.Data
{
    public class PlayerRepository : IPlayerRepository
    {
        private readonly AppDbContext _context;

        public PlayerRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Player>> GetPlayers()
        {
            var players = await _context.Players
                .Include(p => p.TeamName)
                .Take(10)
                .ToListAsync();
            return players;
        }

        public async Task<Player> GetPlayerById(int id)
        {
            var player = await _context.Players
                .Include(p => p.TeamName)
                .SingleOrDefaultAsync(p => p.Id == id);
            return player;
        }

    }
}
