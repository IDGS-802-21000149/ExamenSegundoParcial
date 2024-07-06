using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace TareasAPI.Models;

public partial class BdtareasContext : DbContext
{
    public BdtareasContext()
    {
    }

    public BdtareasContext(DbContextOptions<BdtareasContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Tarea> Tareas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Tarea>(entity =>
        {
            entity.HasKey(e => e.IdTarea).HasName("PK__Tarea__756A5402495A31DF");

            entity.ToTable("Tarea");

            entity.Property(e => e.IdTarea).HasColumnName("idTarea");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.Descripcion)
            .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("descripcion");
            entity.Property(e => e.precio)
            .HasColumnName("precio");
            entity.Property(e => e.imagen)
                .IsUnicode(false)
                .HasColumnName("imagen");
            entity.Property(e => e.categoria)
            .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("categoria");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
