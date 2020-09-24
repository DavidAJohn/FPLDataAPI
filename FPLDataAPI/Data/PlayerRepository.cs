using AutoMapper;
using FPLDataAPI.DTOs;
using FPLDataAPI.Entities;
using FPLDataAPI.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace FPLDataAPI.Data
{
    public class PlayerRepository : IPlayerRepository
    {
        private readonly AppDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public PlayerRepository(AppDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<List<Player>> GetPlayers(PaginationDTO pagination)
        {
            var queryable = _context.Players.AsQueryable();

            // add custom headers to the response to help clients with pagination
            await _httpContextAccessor.HttpContext.AddPaginationParamsToResponse(queryable, pagination.RecordsPerPage);

            var players = await queryable.Paginate(pagination)
                .Include(p => p.TeamName)
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