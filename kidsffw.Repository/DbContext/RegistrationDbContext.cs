namespace kidsffw.Repository.DbContext;

using Microsoft.EntityFrameworkCore;
using kidsffw.Domain.Entity;

public class RegistrationDbContext : DbContext
{
    public DbSet<SalesPartnerEntity>? SalesPartners { get; set; }
    public DbSet<CouponEntity>? Coupons { get; set; }

    public DbSet<OtpEntity>? otpEntities { get; set; }
    public DbSet<UserRegistrationEntity>? UserRegistrationEntities { get; set; }

    public RegistrationDbContext()
    {

    }

    public RegistrationDbContext(DbContextOptions options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder) =>
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(RegistrationDbContext).Assembly);

}