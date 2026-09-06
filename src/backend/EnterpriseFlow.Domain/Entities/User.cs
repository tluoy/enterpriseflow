using EnterpriseFlow.Domain.Exceptions;

namespace EnterpriseFlow.Domain.Entities;

public class User
{
    public Guid Id { get; private set; }

    public string Email { get; private set; } = string.Empty;

    public string DisplayName { get; private set; } = string.Empty;

    public DateTime CreatedAt { get; private set; }

    public DateTime UpdatedAt { get; private set; }

    private User()
    {
    }

    public User(string email, string displayName)
    {
        if (string.IsNullOrWhiteSpace(email))
        {
            throw new DomainException("Email is required.");
        }

        if (!new System.ComponentModel.DataAnnotations.EmailAddressAttribute().IsValid(email))
        {
            throw new DomainException("A valid email is required.");
        }

        if (string.IsNullOrWhiteSpace(displayName))
        {
            throw new DomainException("Display name is required.");
        }

        Id = Guid.NewGuid();
        Email = email.Trim().ToLowerInvariant();
        DisplayName = displayName.Trim();
        CreatedAt = DateTime.UtcNow;
        UpdatedAt = CreatedAt;
    }
}
