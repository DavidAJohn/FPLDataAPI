using Microsoft.AspNetCore.Http;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FPLDataAPI.Helpers
{
    public static class HttpContextExtensions
    {
        public async static Task AddPaginationParamsToResponse<T>(
            this HttpContext httpContext,
            IQueryable<T> queryable,
            int recordsPerPage
            )
        {
            if (httpContext == null) { throw new ArgumentNullException(nameof(httpContext)); }

            double recordCount = await queryable.CountAsync();
            double totalNumPages = recordCount > 0 ? Math.Ceiling(recordCount / recordsPerPage) : 0;

            httpContext.Response.Headers.Add("X-Pagination-TotalRecordCount", recordCount.ToString());
            httpContext.Response.Headers.Add("X-Pagination-NumOfPages", totalNumPages.ToString());
            httpContext.Response.Headers.Add("X-Pagination-RecordsPerPage", recordsPerPage.ToString());
        }
    }
}
