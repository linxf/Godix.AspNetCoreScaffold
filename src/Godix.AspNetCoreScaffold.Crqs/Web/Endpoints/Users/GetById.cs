
using Godix.AspNetCoreScaffold.Crqs.Application.Abstractions.Messaging;
using Godix.AspNetCoreScaffold.Crqs.SharedKernel;
using Godix.AspNetCoreScaffold.Crqs.Web.Extensions;
using Godix.AspNetCoreScaffold.Crqs.Web.Infrastructure;

namespace Godix.AspNetCoreScaffold.Crqs.Web.Endpoints.Users;

public sealed class GetById : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("users/{userId}", async (
            Guid userId,
            IQueryHandler<GetUserByIdQuery, UserResponse> handler,
            CancellationToken cancellationToken) =>
                {
                    var query = new GetUserByIdQuery(userId);

                    Result<UserResponse> result = await handler.Handle(query, cancellationToken);

                    return result.Match(Results.Ok, CustomResults.Problem);
                });
    }

    public sealed record GetUserByIdQuery(Guid UserId) : IQuery<UserResponse>;

    public sealed record UserResponse
    {
        public Guid Id { get; init; }

        public required string Email { get; init; }

        public required string FirstName { get; init; }

        public required string LastName { get; init; }
    }
}
