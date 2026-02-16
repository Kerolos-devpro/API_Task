using System;
using System.Collections.Generic;
using API_Task.Models;
using Microsoft.EntityFrameworkCore;

namespace API_Task.Data;

public partial class SchoolContext : DbContext
{
    public SchoolContext()
    {
    }

    public SchoolContext(DbContextOptions<SchoolContext> options)
        : base(options)
    {
    }

    public virtual DbSet<MedicalReport> MedicalReport { get; set; }

    public virtual DbSet<Student> Student { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=Pasaa;Database=School;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<MedicalReport>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__MedicalR__3214EC071B595FB6");

            entity.HasIndex(e => e.stdId, "UQ__MedicalR__BA08FEBAD1680578").IsUnique();

            entity.Property(e => e.BloodType)
                .HasMaxLength(3)
                .IsUnicode(false);

            entity.HasOne(d => d.std).WithOne(p => p.MedicalReport)
                .HasForeignKey<MedicalReport>(d => d.stdId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__MedicalRe__stdId__3A81B327");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Student__3214EC07DD5C678E");

            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Phone)
                .HasMaxLength(13)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
