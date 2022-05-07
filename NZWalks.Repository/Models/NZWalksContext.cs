using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace NZWalks.Repository.Models
{
    public partial class NZWalksContext : DbContext
    {
        public NZWalksContext()
        {
        }

        public NZWalksContext(DbContextOptions<NZWalksContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Region> Regions { get; set; }
        public virtual DbSet<Walk> Walks { get; set; }
        public virtual DbSet<WalkDifficulty> WalkDifficulties { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Chinese_Taiwan_Stroke_CI_AS");

            modelBuilder.Entity<Region>(entity =>
            {
                entity.ToTable("Regions", "Information");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Area).HasColumnType("float");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Lat).HasColumnType("float");

                entity.Property(e => e.Long).HasColumnType("float");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Population).HasColumnType("float");
            });

            modelBuilder.Entity<Walk>(entity =>
            {
                entity.ToTable("Walks", "Information");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Length).HasColumnType("float");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Region)
                    .WithMany(p => p.Walks)
                    .HasForeignKey(d => d.RegionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Walks_Regions");

                entity.HasOne(d => d.WalkDifficulty)
                    .WithMany(p => p.Walks)
                    .HasForeignKey(d => d.WalkDifficultyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Walks_WalkDifficulty");
            });

            modelBuilder.Entity<WalkDifficulty>(entity =>
            {
                entity.ToTable("WalkDifficulty", "Information");

                entity.Property(e => e.Id)
                    .IsRequired()
                    .HasMaxLength(30);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
