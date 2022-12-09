using Microsoft.EntityFrameworkCore;
using QualaTestCandidateRRP.Models;

namespace QualaTestCandidateRRP.Data
{
    public partial class TestDBContext : DbContext
    {
        public virtual DbSet<MonMonedum> MonMoneda { get; set; } = null!;
        public virtual DbSet<Moneda> Monedas { get; set; } = null!;
        public virtual DbSet<Sede> Sedes { get; set; } = null!;

        public TestDBContext()
        {
        }
        public TestDBContext(DbContextOptions<TestDBContext> options)
            : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MonMonedum>(entity =>
            {
                entity.HasKey(e => e.CodMoneda);

                entity.ToTable("mon_moneda");

                entity.Property(e => e.CodMoneda)
                    .ValueGeneratedNever()
                    .HasColumnName("codMoneda");

                entity.Property(e => e.Abrev)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("abrev");

                entity.Property(e => e.Moneda)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("moneda");
            });

            modelBuilder.Entity<Moneda>(entity =>
            {
                entity.ToTable("monedas");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Codigo)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("codigo");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.Simbolo)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("simbolo");
            });

            modelBuilder.Entity<Sede>(entity =>
            {
                entity.ToTable("sedes");

                entity.HasKey(e => e.Codigo)
                    .HasName("PK_Sedes");

                entity.Property(e => e.Codigo).ValueGeneratedNever();

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Direccion)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.FechaTransaccion)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Identificacion)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NombreMoneda)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Nombre_Moneda");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
