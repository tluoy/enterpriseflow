using EnterpriseFlow.Domain.Enums;
using EnterpriseFlow.Domain.Exceptions;

namespace EnterpriseFlow.Domain.Entities;

public class OrganizationMember
{
    public Guid Id { get; private set; }

    public Guid UserId { get; private set; }

    public Guid OrganizationId { get; private set; }

    public OrganizationRole Role { get; private set; }

    public DateTime JoinedAt { get; private set; }

    private OrganizationMember()
    {
    }

    public OrganizationMember(
    Guid userId,
    Guid organizationId,
    OrganizationRole role)
    {
        if (userId == Guid.Empty)
        {
            throw new DomainException("User ID is required.");
        }

        if (organizationId == Guid.Empty)
        {
            throw new DomainException("Organization ID is required.");
        }

        if (!Enum.IsDefined(role))
        {
            throw new DomainException("A valid organization role is required.");
        }

        Id = Guid.NewGuid();
        UserId = userId;
        OrganizationId = organizationId;
        Role = role;
        JoinedAt = DateTime.UtcNow;
    }
}
