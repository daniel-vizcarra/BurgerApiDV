using System;
using System.Collections.Generic;
using ApiBurgerDV.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiBurgerDV.Data;

public partial class DvdbContext : DbContext
{
    public DvdbContext()
    {
    }

    public DvdbContext(DbContextOptions<DvdbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ArtPieceDv> ArtPieceDvs { get; set; }

    public virtual DbSet<Artist> Artists { get; set; }

    public virtual DbSet<BurgerDv> BurgerDvs { get; set; }

    public virtual DbSet<PromoDv> PromoDvs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=DVDB;Trusted_Connection=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ArtPieceDv>(entity =>
        {
            entity.HasKey(e => e.ArtPieceId);

            entity.ToTable("ArtPieceDV");

            entity.HasIndex(e => e.ArtistId, "IX_ArtPieceDV_ArtistId");

            entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.Artist).WithMany(p => p.ArtPieceDvs).HasForeignKey(d => d.ArtistId);
        });

        modelBuilder.Entity<Artist>(entity =>
        {
            entity.ToTable("Artist");
        });

        modelBuilder.Entity<BurgerDv>(entity =>
        {
            entity.ToTable("BurgerDV");

            entity.Property(e => e.Precio).HasColumnType("decimal(18, 2)");
        });

        modelBuilder.Entity<PromoDv>(entity =>
        {
            entity.HasKey(e => e.PromoId);

            entity.ToTable("PromoDV");

            entity.HasIndex(e => e.BurgerId, "IX_PromoDV_BurgerID");

            entity.Property(e => e.PromoId).HasColumnName("PromoID");
            entity.Property(e => e.BurgerId).HasColumnName("BurgerID");

            entity.HasOne(d => d.Burger).WithMany(p => p.PromoDvs).HasForeignKey(d => d.BurgerId);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
