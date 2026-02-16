namespace MahjongUKRankingSystem.Logic.Models;

public record TournamentDto(
    int Id,
    int EmaId,
    string Name,
    string Place,
    string Country,
    DateOnly Date,
    int Players,
    decimal MersWeight,
    int MukrsDays);
