namespace MahjongUKRankingSystem.Logic.Models;

public record GetLatestRankingsDataDto(
    IReadOnlyCollection<TournamentDto> Tournaments,
    IReadOnlyCollection<PlayerDto> Players,
    IReadOnlyCollection<TournamentResultDto> TournamentResults);