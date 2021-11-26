using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using ClassNoticias.Models;

#nullable disable

namespace ClassNoticias.Data
{
    public partial class NoticiasContext : DbContext
    {
        public NoticiasContext()
        {
        }

        public NoticiasContext(DbContextOptions<NoticiasContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Categoria> Categorias { get; set; }
        public virtual DbSet<Mundiale> Mundiales { get; set; }
        public virtual DbSet<Noticiass> Noticiasses { get; set; }
        public virtual DbSet<Paise> Paises { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Categoria>(entity =>
            {
                entity.HasKey(e => e.IdCategorias)
                    .HasName("PK__categori__0185FF0715ADB916");

                entity.ToTable("categorias");

                entity.Property(e => e.Categoria1)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("Categoria");
            });

            modelBuilder.Entity<Mundiale>(entity =>
            {
                entity.HasKey(e => e.IdMundiales)
                    .HasName("PK__Mundiale__0FCF53BC89E02720");

                entity.Property(e => e.Continente)
                    .HasMaxLength(40)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Noticiass>(entity =>
            {
                entity.HasKey(e => e.IdNoticias)
                    .HasName("PK__Noticias__EBE18655EAB71BC9");

                entity.ToTable("Noticiass");

                entity.Property(e => e.Autor)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Descripcion).IsUnicode(false);

                entity.Property(e => e.Fecha).HasColumnType("datetime");

                entity.Property(e => e.Imagen).HasColumnType("image");

                entity.Property(e => e.Link)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Titulo)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdCategoriasNavigation)
                    .WithMany(p => p.Noticiasses)
                    .HasForeignKey(d => d.IdCategorias)
                    .HasConstraintName("fk_categorias");

                entity.HasOne(d => d.IdPaisNavigation)
                    .WithMany(p => p.Noticiasses)
                    .HasForeignKey(d => d.IdPais)
                    .HasConstraintName("fk_Pais");
            });

            modelBuilder.Entity<Paise>(entity =>
            {
                entity.HasKey(e => e.IdPais)
                    .HasName("PK__Paises__FC850A7B560D0085");

                entity.Property(e => e.Pais)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdMundialesNavigation)
                    .WithMany(p => p.Paises)
                    .HasForeignKey(d => d.IdMundiales)
                    .HasConstraintName("fk_Mundiales");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
