using Godix.AspNetCoreScaffold.Crqs.SharedKernel;

namespace Godix.AspNetCoreScaffold.Crqs.Infrastructure.DomainEvents;

public interface IDomainEventsDispatcher
{
    Task DispatchAsync(IEnumerable<IDomainEvent> domainEvents, CancellationToken cancellationToken = default);
}
