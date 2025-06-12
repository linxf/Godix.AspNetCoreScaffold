using Godix.AspNetCoreScaffold.Crqs.SharedKernel;

namespace Godix.AspNetCoreScaffold.Crqs.Domain.Users;

public sealed record UserRegisteredDomainEvent(Guid UserId) : IDomainEvent;
