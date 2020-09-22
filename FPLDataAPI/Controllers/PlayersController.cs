using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FPLDataAPI;
using FPLDataAPI.Entities;
using AutoMapper;
using FPLDataAPI.DTOs;
using Microsoft.Extensions.Logging;
using FPLDataAPI.Data;

namespace FPLDataAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayersController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ILogger<PlayersController> _logger;
        private readonly IPlayerRepository _repo;

        public PlayersController(IPlayerRepository repo,
                                 IMapper mapper,
                                 ILogger<PlayersController> logger)
        {
            _mapper = mapper;
            _logger = logger;
            _repo = repo;
        }

        // GET: api/Players
        [HttpGet]
        public async Task<ActionResult<List<PlayerDTO>>> GetPlayers()
        {
            var players = await _repo.GetPlayers();
            var playersDTO = _mapper.Map<List<PlayerDTO>>(players);
            return playersDTO;
        }

        // GET: api/Players/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PlayerDTO>> GetPlayer(int id)
        {
            var player = await _repo.GetPlayerById(id);

            if (player == null)
            {
                return NotFound();
            }

            var playerDTO = _mapper.Map<PlayerDTO>(player);
            return playerDTO;
        }

    }
}
