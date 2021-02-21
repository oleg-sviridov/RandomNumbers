using Microsoft.EntityFrameworkCore;
using RandomNumbers.Database;
using RandomNumbers.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RandomNumbers.Service
{
    public class MatchService
    {
        public DataContext _datacontext;

        public MatchService(DataContext datacontext)
        {
            _datacontext = datacontext;
        }

        public async Task<Match> GetCurrentMatch()
        {
            var match = await _datacontext.Matches.FirstOrDefaultAsync(x => x.StartTime >= DateTime.Now && x.EndTime <= DateTime.Now);
            return match;
        }
    }
}
