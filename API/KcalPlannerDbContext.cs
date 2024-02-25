using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace API;

public partial class KcalPlannerDbContext : DbContext
{
    public KcalPlannerDbContext()
    {
    }

    public KcalPlannerDbContext(DbContextOptions<KcalPlannerDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Activity> Activities { get; set; }

    public virtual DbSet<Aim> Aims { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Request> Requests { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserProduct> UserProducts { get; set; }

    public virtual DbSet<Weight> Weights { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=kcal_planner_db;Username=postgres;Password=");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Activity>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("activities_pkey");

            entity.ToTable("activities");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name).HasColumnName("name");
        });

        modelBuilder.Entity<Aim>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("aims_pkey");

            entity.ToTable("aims");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name).HasColumnName("name");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("products_pkey");

            entity.ToTable("products");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Carbohydrates).HasColumnName("carbohydrates");
            entity.Property(e => e.Fats).HasColumnName("fats");
            entity.Property(e => e.Kcal).HasColumnName("kcal");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.Proteins).HasColumnName("proteins");
        });

        modelBuilder.Entity<Request>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("requests_pkey");

            entity.ToTable("requests");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Carbohydrates).HasColumnName("carbohydrates");
            entity.Property(e => e.Fats).HasColumnName("fats");
            entity.Property(e => e.Kcal).HasColumnName("kcal");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.Proteins).HasColumnName("proteins");
            entity.Property(e => e.Status).HasColumnName("status");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("users_pkey");

            entity.ToTable("users");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AimWeight).HasColumnName("aim_weight");
            entity.Property(e => e.CurWeight).HasColumnName("cur_weight");
            entity.Property(e => e.Email).HasColumnName("email");
            entity.Property(e => e.IdActivity).HasColumnName("id_activity");
            entity.Property(e => e.IdAim).HasColumnName("id_aim");
            entity.Property(e => e.InitWeight).HasColumnName("init_weight");
            entity.Property(e => e.KcalPerDay).HasColumnName("kcal_per_day");
            entity.Property(e => e.Nickname).HasColumnName("nickname");
            entity.Property(e => e.Password).HasColumnName("password");
            entity.Property(e => e.Photo).HasColumnName("photo");

            entity.HasOne(d => d.IdActivityNavigation).WithMany(p => p.Users)
                .HasForeignKey(d => d.IdActivity)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("users_id_activity_fkey");

            entity.HasOne(d => d.IdAimNavigation).WithMany(p => p.Users)
                .HasForeignKey(d => d.IdAim)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("users_id_aim_fkey");
        });

        modelBuilder.Entity<UserProduct>(entity =>
        {
            entity.HasKey(e => new { e.IdUser, e.Id }).HasName("user_product_pkey");

            entity.ToTable("user_product");

            entity.Property(e => e.IdUser).HasColumnName("id_user");
            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");
            entity.Property(e => e.Carbohydrates).HasColumnName("carbohydrates");
            entity.Property(e => e.Date).HasColumnName("date");
            entity.Property(e => e.Fats).HasColumnName("fats");
            entity.Property(e => e.IdProduct).HasColumnName("id_product");
            entity.Property(e => e.Kcal).HasColumnName("kcal");
            entity.Property(e => e.Proteins).HasColumnName("proteins");
            entity.Property(e => e.Sum).HasColumnName("sum");

            entity.HasOne(d => d.IdProductNavigation).WithMany(p => p.UserProducts)
                .HasForeignKey(d => d.IdProduct)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("user_product_id_product_fkey");

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.UserProducts)
                .HasForeignKey(d => d.IdUser)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("user_product_id_user_fkey");
        });

        modelBuilder.Entity<Weight>(entity =>
        {
            entity.HasKey(e => e.IdUser).HasName("weights_pkey");

            entity.ToTable("weights");

            entity.Property(e => e.IdUser)
                .ValueGeneratedNever()
                .HasColumnName("id_user");
            entity.Property(e => e.Date).HasColumnName("date");
            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");
            entity.Property(e => e.Weight1).HasColumnName("weight");

            entity.HasOne(d => d.IdUserNavigation).WithOne(p => p.Weight)
                .HasForeignKey<Weight>(d => d.IdUser)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("weights_id_user_fkey");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
