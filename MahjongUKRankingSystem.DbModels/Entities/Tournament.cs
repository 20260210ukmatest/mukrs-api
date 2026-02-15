using System;
using System.Collections.Generic;

namespace MahjongUKRankingSystem.DbModels;

public partial class Tournament
{
    public int Id { get; set; }

    public int EmaId { get; set; }

    public string Name { get; set; } = null!;

    public string Place { get; set; } = null!;

    public string Country { get; set; } = null!;

    public DateOnly Date { get; set; }

    public int Players { get; set; }

    public decimal MersWeight { get; set; }

    public int MukrsDays { get; set; }

    public bool ExcludedFromIngestion { get; set; }

    public DateTime IngestedOn { get; set; }

    public bool IsLatest { get; set; }

    public virtual ICollection<TournamentResult> TournamentResults { get; set; } = new List<TournamentResult>();
}
