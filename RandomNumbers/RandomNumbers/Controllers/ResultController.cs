using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RandomNumbers.Service;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RandomNumbers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResultController : ControllerBase
    {
        private readonly ILogger<ResultController> _logger;

        private readonly ResultService _resultService;

        public ResultController(ILogger<ResultController> logger, ResultService resultService)
        {
            _logger = logger;
            _resultService = resultService;
        }


        // GET: api/<MatchController>
        [HttpGet]
        [Route("finished")]
        public async Task<IActionResult> GetFinishedMatchResults()
        {
            try
            {
                var finishedResults = await _resultService.GetFinishedMatchResults(DateTime.Now);

                return Ok(finishedResults);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500);
            }

        }

        // GET: api/<ResultController>
        [HttpPost]
        public async Task<IActionResult> PostResult(int number, Guid userId)
        {
            try
            {
                await _resultService.AddResult(number, userId);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500);
            }
        }
    }
}
