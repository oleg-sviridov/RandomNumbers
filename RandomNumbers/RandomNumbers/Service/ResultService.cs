using Microsoft.EntityFrameworkCore;
using RandomNumbers.Database;
using RandomNumbers.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RandomNumbers.Service
{
    public class ResultService
    {
        public DataContext _datacontext;
        public MatchService _matchService;

        public ResultService(DataContext datacontext, MatchService matchService)
        {
            _datacontext = datacontext;
            _matchService = matchService;
        }

        public async Task<List<Result>> GetFinishedMatchResults(DateTime endTime)
        {
            var query = _datacontext.Results
                .Where(r => _datacontext.Matches.Where(m => m.EndTime < endTime).Any(m => m.MatchId == r.MatchId))
                .GroupBy(r => r.MatchId).Select(g => new Result()
                {
                    MatchId = g.Key,
                    UserId = g.Max(row => row.UserId),
                    Number = g.Max(row => row.Number)
                });

            var results = await query.ToListAsync();

            return results;
        }

        public async Task AddResult(int number, Guid userId)
        {
            var match = await _matchService.GetCurrentMatch();
            var result = new Result() { 
                ResultId = Guid.NewGuid(),
                MatchId = match.MatchId,
                UserId = userId,
                Number = number
            };
            await _datacontext.Results.AddAsync(result);
            await _datacontext.SaveChangesAsync();
        }

    }
}
