using FPLDataAPI.DTOs;
using FPLDataAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FPLDataAPI.Helpers
{
    public static class QueryableExtensions
    {
        public static IQueryable<T> Paginate<T>(this IQueryable<T> queryable, PlayerParameters playerParams)
        {
            return queryable
                .Skip((playerParams.PageNumber - 1) * playerParams.RecordsPerPage)
                .Take(playerParams.RecordsPerPage);
        }
    }
}