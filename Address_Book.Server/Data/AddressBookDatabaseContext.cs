using System;
using System.Collections.Generic;
using Address_Book.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace Address_Book.Server.Data;

public partial class AddressBookDatabaseContext : DbContext
{
    public AddressBookDatabaseContext(DbContextOptions<AddressBookDatabaseContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AdressBook> AdressBooks { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AdressBook>(entity =>
        {
            entity.HasKey(e => e.TelephoneNumber).HasName("PK__AdressBo__C63DFD2FF6A4BA9B");

            entity.ToTable("AdressBook");

            entity.Property(e => e.TelephoneNumber)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.City)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.Country)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.FirstName)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.Street)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.StreetNumber)
                .HasMaxLength(6)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
