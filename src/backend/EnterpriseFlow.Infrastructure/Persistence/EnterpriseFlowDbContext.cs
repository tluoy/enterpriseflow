using EnterpriseFlow.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EnterpriseFlow.Infrastructure.Persistence;

public class EnterpriseFlowDbContext : DbContext
{
    public EnterpriseFlowDbContext(DbContextOptions<EnterpriseFlowDbContext> options) : base(options)
    {
    }

    public DbSet<User> Users => Set<User>();

    public DbSet<Organization> Organizations => Set<Organization>();

    public DbSet<OrganizationMember> OrganizationMembers => Set<OrganizationMember>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(EnterpriseFlowDbContext).Assembly);

        base.OnModelCreating(modelBuilder);
    }
}
