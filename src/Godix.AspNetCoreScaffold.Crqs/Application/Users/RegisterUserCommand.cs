using Godix.AspNetCoreScaffold.Crqs.Application.Abstractions.Messaging;

namespace Godix.AspNetCoreScaffold.Crqs.Application.Users;

public sealed record RegisterUserCommand(string Email, string FirstName, string LastName, string Password)
    : ICommand<Guid>;
