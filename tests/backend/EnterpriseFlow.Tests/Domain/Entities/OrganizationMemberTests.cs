using EnterpriseFlow.Domain.Entities;
using EnterpriseFlow.Domain.Enums;
using EnterpriseFlow.Domain.Exceptions;

namespace EnterpriseFlow.Tests.Domain.Entities;

public class OrganizationMemberTests
{
    [Fact]
    public void Constructor_ShouldCreateMemberWithExpectedValues()
    {
        // Arrange
        var userId = Guid.NewGuid();
        var organizationId = Guid.NewGuid();

        // Act
        var member = new OrganizationMember(
            userId,
            organizationId,
            OrganizationRole.Admin);

        // Assert
        Assert.NotEqual(Guid.Empty, member.Id);
        Assert.Equal(userId, member.UserId);
        Assert.Equal(organizationId, member.OrganizationId);
        Assert.Equal(OrganizationRole.Admin, member.Role);
        Assert.NotEqual(default, member.JoinedAt);
    }

    [Fact]
public void Constructor_ShouldRejectEmptyUserId()
{
    var action = () => new OrganizationMember(
        Guid.Empty,
        Guid.NewGuid(),
        OrganizationRole.Member);

    var exception = Assert.Throws<DomainException>(action);

    Assert.Equal("User ID is required.", exception.Message);
}

[Fact]
public void Constructor_ShouldRejectEmptyOrganizationId()
{
    var action = () => new OrganizationMember(
        Guid.NewGuid(),
        Guid.Empty,
        OrganizationRole.Member);

    var exception = Assert.Throws<DomainException>(action);

    Assert.Equal("Organization ID is required.", exception.Message);
}

[Fact]
public void Constructor_ShouldRejectInvalidRole()
{
    var action = () => new OrganizationMember(
        Guid.NewGuid(),
        Guid.NewGuid(),
        (OrganizationRole)999);

    var exception = Assert.Throws<DomainException>(action);

    Assert.Equal("A valid organization role is required.", exception.Message);
}
}
