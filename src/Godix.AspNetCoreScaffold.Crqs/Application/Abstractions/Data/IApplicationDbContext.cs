using Godix.AspNetCoreScaffold.Crqs.Domain.Users;
using Microsoft.EntityFrameworkCore;

namespace Godix.AspNetCoreScaffold.Crqs.Application.Abstractions.Data;

public interface IApplicationDbContext
{
    DbSet<User> Users { get; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
