using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Maiboroda_Flowers.Models;

public partial class DbOrderContext : DbContext
{
    public DbOrderContext()
    {
    }

    public DbOrderContext(DbContextOptions<DbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Order> Orders { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlite("Data Source=D:\\Maiboroda_Flowers\\db.db");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasIndex(e => e.Id, "IX_Orders_Id").IsUnique();

            entity.Property(e => e.ProductWeight).HasColumnType("NUMERIC");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
