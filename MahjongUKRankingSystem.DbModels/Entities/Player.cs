using System;
using System.Collections.Generic;

namespace MahjongUKRankingSystem.DbModels;

public partial class Player
{
    public int Id { get; set; }

    public string? EmaNumber { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Country { get; set; } = null!;

    public virtual ICollection<TournamentResult> TournamentResults { get; set; } = new List<TournamentResult>();
}
