using FastEndpoints;
using Microsoft.AspNetCore.Http.HttpResults;
using MyFastEndPointLearning.Models;

namespace MyFastEndPointLearning.Endpoints;

public class UnionTypeReturningHandler
    : Endpoint<MyRequest,
        Results<Ok<MyResponse>,
            NotFound,
            ProblemDetails>>
{
    public override void Configure()
    {
        // ...
    }

    public override async Task<Results<Ok<MyResponse>, 
        NotFound,
        ProblemDetails>> ExecuteAsync(MyRequest req, CancellationToken ct)
    {
        await Task.CompletedTask;

        if (req.Age == 0)
        {
            return TypedResults.NotFound();
        }

        if (req.Age == 1)
        {
            AddError(r => r.Age, "value has to be greater than 1");
            return new ProblemDetails(ValidationFailures);
        }

        return TypedResults.Ok(new MyResponse
        {
            FullName = req.Age.ToString()
        });
    }
}
