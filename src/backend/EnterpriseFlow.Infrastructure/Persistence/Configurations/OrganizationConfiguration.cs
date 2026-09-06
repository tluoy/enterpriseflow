using EnterpriseFlow.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EnterpriseFlow.Infrastructure.Persistence.Configurations;

public class OrganizationConfiguration : IEntityTypeConfiguration<Organization>
{
    public void Configure(EntityTypeBuilder<Organization> builder)
    {
        builder.ToTable("organizations");

        builder.HasKey(organization => organization.Id);

        builder.Property(organization => organization.Id)
            .ValueGeneratedNever();

        builder.Property(organization => organization.Name)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(organization => organization.CreatedAt)
            .IsRequired();

        builder.Property(organization => organization.UpdatedAt)
            .IsRequired();
    }
}
