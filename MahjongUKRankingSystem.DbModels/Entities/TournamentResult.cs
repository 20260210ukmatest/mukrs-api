using System;
using System.Collections.Generic;

namespace MahjongUKRankingSystem.DbModels;

public partial class TournamentResult
{
    public int TournamentId { get; set; }

    public int PlayerId { get; set; }

    public int BaseRank { get; set; }

    public virtual Player Player { get; set; } = null!;

    public virtual Tournament Tournament { get; set; } = null!;
}
