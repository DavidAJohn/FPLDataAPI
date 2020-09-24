using FPLDataAPI.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FPLDataAPI.Entities
{
    public interface IPlayerRepository
    {
        Task<List<Player>> GetPlayers(PlayerParameters playerParams);
        Task<Player> GetPlayerById(int id);
    }
}
