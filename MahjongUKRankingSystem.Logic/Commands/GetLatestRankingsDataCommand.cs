using Microsoft.EntityFrameworkCore;
using MahjongUKRankingSystem.DbModels;
using MahjongUKRankingSystem.Logic.Models;

namespace MahjongUKRankingSystem.Logic.Commands;

public class GetLatestRankingsDataCommand(MukrsContext dbContext)
{
    public async Task<GetLatestRankingsDataDto> ExecuteAsync(DateOnly notBefore, CancellationToken cancellationToken)
    {
        var tournaments = await dbContext.Tournaments
            .Where(t => t.IsLatest)
            .Where(t => t.Date >= notBefore)
            .Select(t => new TournamentDto(
                t.Id,
                t.EmaId,
                t.Name,
                t.Place,
                t.Country,
                t.Date,
                t.Players,
                t.MersWeight,
                t.MukrsDays))
            .ToListAsync(cancellationToken);

        var tournamentIds = tournaments.Select(t => t.Id).ToList();

        var tournamentResults = await dbContext.TournamentResults
            .Where(tr => tournamentIds.Contains(tr.TournamentId))
            .Select(tr => new TournamentResultDto(
                tr.TournamentId,
                tr.PlayerId,
                tr.BaseRank))
            .ToListAsync(cancellationToken);

        var playerIds = tournamentResults.Select(tr => tr.PlayerId).Distinct().ToList();

        var players = await dbContext.Players
            .Where(p => playerIds.Contains(p.Id))
            .Select(p => new PlayerDto(
                p.Id,
                p.EmaNumber,
                p.FirstName,
                p.LastName,
                p.Country))
            .ToListAsync(cancellationToken);

        return new GetLatestRankingsDataDto(
            tournaments,
            players,
            tournamentResults);
    }
}