using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication3.ContextHelpers
{
    public class College
    {
        [Key]
        public string CollegeName { get; set; }

        [DataType(DataType.Date)]
        public DateTime Established { get; set; }
      
        public virtual ICollection<Building>
            Buildings
        { get; set; }
     
    }

    public class Building
    {
        [Key, Column(Order = 0)]
        public string BuildingName { get; set; }

        [Key, Column(Order = 1)]
        public string CollegeName { get; set; }

        public string StreetAddress { get; set; }
        public string City { get; set; }

        public virtual College College
        { get; set; }

        public virtual ICollection<Room> Rooms { get; set; }

    }

    public class Room
    {
        [Key, Column(Order = 0)]
        public string RoomID { get; set; }

        [Key, Column(Order = 1)]
        public string BuildingName { get; set; }

        [Key, Column(Order = 2)]
        public string CollegeName { get; set; }

        public int SeatingCapacity { get; set; }

        public virtual Building Building
        { get; set; }
    }


    public class NewCollegeDBContext : DbContext
    {
        public NewCollegeDBContext(DbContextOptions<NewCollegeDBContext> options)
            : base(options) { }
        // Define entity collections.
        public DbSet<College> Colleges { get; set; }
        public DbSet<Building> Buildings { get; set; }
        public DbSet<Room> Rooms { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
            modelBuilder.Entity<Building>()
                .HasKey(b => new { b.BuildingName, b.CollegeName });

            modelBuilder.Entity<Room>()
                .HasKey(r => new { r.RoomID, r.BuildingName, r.CollegeName });

            modelBuilder.Entity<Building>()
                .HasOne(b => b.College)
                .WithMany(b => b.Buildings) //Why not stores? A building has many stores
                .HasForeignKey(fk => new { fk.CollegeName })
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Room>()
                .HasOne(r => r.Building)
                .WithMany(r => r.Rooms)
                .HasForeignKey(fk => new {fk.BuildingName, fk.CollegeName})
                .OnDelete(DeleteBehavior.Restrict);
        }

    }
}
