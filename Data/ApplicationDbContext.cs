using Microsoft.EntityFrameworkCore;
using VetClinicSystemAPI.Models;

namespace VetClinicSystemAPI.Data
{

    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<VetDoctor> VetDoctors { get; set; }
        public DbSet<Pet> Pets { get; set; }
        public DbSet<PetProfile> PetProfiles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // VetDoctor 1 → many Pets
            modelBuilder.Entity<VetDoctor>()
                .HasMany(d => d.Pets)
                .WithOne(p => p.VetDoctor)
                .HasForeignKey(p => p.VetDoctorId);

            // Pet 1 → 1 PetProfile
            modelBuilder.Entity<Pet>()
                .HasOne(p => p.PetProfile)
                .WithOne(pp => pp.Pet)
                .HasForeignKey<PetProfile>(pp => pp.PetId);
        }
    }
}
