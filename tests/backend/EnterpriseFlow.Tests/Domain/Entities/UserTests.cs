using EnterpriseFlow.Domain.Entities;
using EnterpriseFlow.Domain.Exceptions;

namespace EnterpriseFlow.Tests.Domain.Entities;

public class UserTests
{
    [Fact]
    public void Constructor_ShouldCreateUserWithExpectedValues()
    {
        // Arrange
        const string email = "alice@example.com";
        const string displayName = "Alice";

        // Act
        var user = new User(email, displayName);

        // Assert
        Assert.NotEqual(Guid.Empty, user.Id);
        Assert.Equal(email, user.Email);
        Assert.Equal(displayName, user.DisplayName);
        Assert.NotEqual(default, user.CreatedAt);
        Assert.Equal(user.CreatedAt, user.UpdatedAt);
    }

[Fact]
public void Constructor_ShouldNormalizeEmailAndDisplayName()
{
    // Act
    var user = new User(
        "  ALICE@EXAMPLE.COM  ",
        "  Alice Smith  ");

    // Assert
    Assert.Equal("alice@example.com", user.Email);
    Assert.Equal("Alice Smith", user.DisplayName);
}

[Theory]
[InlineData("")]
[InlineData("   ")]
public void Constructor_ShouldRejectInvalidEmail(string email)
{
    // Act
    var action = () => new User(email, "Alice");

    // Assert
    var exception = Assert.Throws<DomainException>(action);
    Assert.Equal("Email is required.", exception.Message);
}

[Theory]
[InlineData("")]
[InlineData("   ")]
public void Constructor_ShouldRejectInvalidDisplayName(string displayName)
{
    // Act
    var action = () => new User("alice@example.com", displayName);

    // Assert
    var exception = Assert.Throws<DomainException>(action);
    Assert.Equal("Display name is required.", exception.Message);
}
}
