using MahjongUKRankingSystem.Logic.Commands;
using MahjongUKRankingSystem.Logic.Models;
using Microsoft.AspNetCore.Mvc;

namespace MahjongUKRankingSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RankingsController : ControllerBase
    {
        [HttpGet]
        public async Task<GetLatestRankingsDataDto> GetLatestData(
            [FromServices] GetLatestRankingsDataCommand command,
            [FromQuery] DateOnly notBefore,
            CancellationToken cancellationToken)
        {   
            return await command.ExecuteAsync(notBefore, cancellationToken);
        }
    }
}
