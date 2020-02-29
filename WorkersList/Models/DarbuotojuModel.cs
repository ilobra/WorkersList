namespace WorkersList.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DarbuotojuModel : DbContext
    {
        public DarbuotojuModel()
            : base("name=DarbuotojuModel")
        {
        }

        public virtual DbSet<Darbuotojas> Darbuotojas { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Darbuotojas>()
                .Property(e => e.Vardas)
                .IsUnicode(true);

            modelBuilder.Entity<Darbuotojas>()
                .Property(e => e.Pavarde)
                .IsUnicode(true);

            modelBuilder.Entity<Darbuotojas>()
                .Property(e => e.Asmens_kodas)
                .IsUnicode(false);

            modelBuilder.Entity<Darbuotojas>()
                .Property(e => e.Adresas)
                .IsUnicode(true);
            modelBuilder.Entity<Darbuotojas>()
                .Property(e => e.Aktyvumo_pozymis);
        }
    }
}
