using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FPLDataAPI.Entities
{
    public class PlayerParameters : QueryStringParameters
    {
        public int MinGoals { get; set; } = 0;
        public int MinAssists { get; set; } = 0;

    }
}
