using Godix.AspNetCoreScaffold.Crqs.Application.Abstractions.Authentication;
using Godix.AspNetCoreScaffold.Crqs.Application.Abstractions.Data;
using Godix.AspNetCoreScaffold.Crqs.Application.Abstractions.Messaging;
using Godix.AspNetCoreScaffold.Crqs.Domain.Users;
using Godix.AspNetCoreScaffold.Crqs.SharedKernel;
using Microsoft.EntityFrameworkCore;

namespace Godix.AspNetCoreScaffold.Crqs.Application.Users;

internal sealed class RegisterUserCommandHandler(IApplicationDbContext context, IPasswordHasher passwordHasher)
    : ICommandHandler<RegisterUserCommand, Guid>
{
    public async Task<Result<Guid>> Handle(RegisterUserCommand command, CancellationToken cancellationToken)
    {
        if (await context.Users.AnyAsync(u => u.Email == command.Email, cancellationToken))
        {
            return Result.Failure<Guid>(UserErrors.EmailNotUnique);
        }

        var user = new User
        {
            Id = Guid.NewGuid(),
            Email = command.Email,
            FirstName = command.FirstName,
            LastName = command.LastName,
            PasswordHash = passwordHasher.Hash(command.Password)
        };

        user.Raise(new UserRegisteredDomainEvent(user.Id));

        context.Users.Add(user);

        await context.SaveChangesAsync(cancellationToken);

        return user.Id;
    }
}
