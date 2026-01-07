using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace ProyectoFinal.Models;

public partial class CodePlaygroundContext : DbContext
{
    public CodePlaygroundContext()
    {
    }

    public CodePlaygroundContext(DbContextOptions<CodePlaygroundContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Ejercicios> Ejercicios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;port=3306;user=root;password=root;database=code_playground", Microsoft.EntityFrameworkCore.ServerVersion.Parse("9.3.0-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_unicode_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Ejercicios>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("ejercicios");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CodigoEsperado)
                .HasColumnType("text")
                .HasColumnName("codigo_esperado");
            entity.Property(e => e.CodigoInicial)
                .HasColumnType("text")
                .HasColumnName("codigo_inicial");
            entity.Property(e => e.Descripcion)
                .HasColumnType("text")
                .HasColumnName("descripcion");
            entity.Property(e => e.ImagenReferencia)
                .HasMaxLength(600)
                .HasColumnName("imagen_referencia");
            entity.Property(e => e.Nivel)
                .HasColumnType("enum('principiante','intermedio','avanzado')")
                .HasColumnName("nivel");
            entity.Property(e => e.Pista)
                .HasMaxLength(500)
                .HasColumnName("pista");
            entity.Property(e => e.Tipo)
                .HasColumnType("enum('html','css')")
                .HasColumnName("tipo");
            entity.Property(e => e.Titulo)
                .HasMaxLength(200)
                .HasColumnName("titulo");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
