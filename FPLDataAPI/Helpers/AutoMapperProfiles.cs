using AutoMapper;
using FPLDataAPI.DTOs;
using FPLDataAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FPLDataAPI.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Team, TeamDTO>().ReverseMap();
            CreateMap<TeamCreationDTO, Team>();

            CreateMap<Player, PlayerDTO>()
                .ForMember(dest => dest.TeamName, opt => opt.MapFrom(src => src.TeamName.Name));

        }
    }
}
