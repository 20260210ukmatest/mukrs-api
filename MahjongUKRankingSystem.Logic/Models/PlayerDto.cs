namespace MahjongUKRankingSystem.Logic.Models;

public record PlayerDto(
    int Id,
    string? EmaNumber,
    string FirstName,
    string LastName,
    string Country);
