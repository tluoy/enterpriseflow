using EnterpriseFlow.Domain.Exceptions;

namespace EnterpriseFlow.Domain.Entities;

public class Organization
{
    public Guid Id { get; private set; }

    public string Name { get; private set; } = string.Empty;

    public DateTime CreatedAt { get; private set; }

    public DateTime UpdatedAt { get; private set; }

    private Organization()
    {
    }

    public Organization(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new DomainException("Organization name is required.");
        }
        Id = Guid.NewGuid();
        Name = name;
        CreatedAt = DateTime.UtcNow;
        UpdatedAt = CreatedAt;
    }
}
