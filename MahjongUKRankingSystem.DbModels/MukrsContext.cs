using Microsoft.EntityFrameworkCore;

namespace MahjongUKRankingSystem.DbModels;

public partial class MukrsContext : DbContext
{
    public MukrsContext()
    {
    }

    public MukrsContext(DbContextOptions<MukrsContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Player> Players { get; set; }

    public virtual DbSet<Tournament> Tournaments { get; set; }

    public virtual DbSet<TournamentResult> TournamentResults { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Player>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("players_pkey");

            entity.ToTable("players");

            entity.HasIndex(e => e.EmaNumber, "players_ema_number_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Country).HasColumnName("country");
            entity.Property(e => e.EmaNumber).HasColumnName("ema_number");
            entity.Property(e => e.FirstName).HasColumnName("first_name");
            entity.Property(e => e.LastName).HasColumnName("last_name");
        });

        modelBuilder.Entity<Tournament>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("tournaments_pkey");

            entity.ToTable("tournaments");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Country).HasColumnName("country");
            entity.Property(e => e.Date).HasColumnName("date");
            entity.Property(e => e.EmaId).HasColumnName("ema_id");
            entity.Property(e => e.ExcludedFromIngestion).HasColumnName("excluded_from_ingestion");
            entity.Property(e => e.IngestedOn)
                .HasDefaultValueSql("now()")
                .HasColumnName("ingested_on");
            entity.Property(e => e.IsLatest)
                .HasDefaultValue(true)
                .HasColumnName("is_latest");
            entity.Property(e => e.MersWeight)
                .HasPrecision(2, 1)
                .HasColumnName("mers_weight");
            entity.Property(e => e.MukrsDays).HasColumnName("mukrs_days");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.Place).HasColumnName("place");
            entity.Property(e => e.Players).HasColumnName("players");
        });

        modelBuilder.Entity<TournamentResult>(entity =>
        {
            entity.HasKey(e => new { e.TournamentId, e.PlayerId }).HasName("tournament_results_pkey");

            entity.ToTable("tournament_results");

            entity.Property(e => e.TournamentId).HasColumnName("tournament_id");
            entity.Property(e => e.PlayerId).HasColumnName("player_id");
            entity.Property(e => e.BaseRank).HasColumnName("base_rank");

            entity.HasOne(d => d.Player).WithMany(p => p.TournamentResults)
                .HasForeignKey(d => d.PlayerId)
                .HasConstraintName("tournament_results_player_id_fkey");

            entity.HasOne(d => d.Tournament).WithMany(p => p.TournamentResults)
                .HasForeignKey(d => d.TournamentId)
                .HasConstraintName("tournament_results_tournament_id_fkey");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
