using EnterpriseFlow.Domain.Entities;

namespace EnterpriseFlow.Tests.Domain.Entities;

public class OrganizationTests
{
    [Fact]
    public void Constructor_ShouldCreateOrganizationWithExpectedValues()
    {
        // Arrange
        const string name = "Acme Corporation";

        // Act
        var organization = new Organization(name);

        // Assert
        Assert.NotEqual(Guid.Empty, organization.Id);
        Assert.Equal(name, organization.Name);
        Assert.NotEqual(default, organization.CreatedAt);
        Assert.Equal(organization.CreatedAt, organization.UpdatedAt);
    }
}
