using Godix.AspNetCoreScaffold.Crqs.SharedKernel;

namespace Godix.AspNetCoreScaffold.Crqs.Domain.Users;

public sealed class User : Entity
{
    public Guid Id { get; set; }
    public required string Email { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string PasswordHash { get; set; }
}
