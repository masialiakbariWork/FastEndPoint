using FastEndpoints;
using MyFastEndPointLearning.Models;

namespace MyFastEndPointLearning.Endpoints;

public class GetPersonEndPoint: EndpointWithoutRequest<GetPersonResponse>
{
    public override void Configure()
    {
        Get("/api/person");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var person = new { FullName = "Masoud Aliakbari", Age = 20 };

        Response.FullName = person.FullName;
        Response.Age = person.Age;
    }

    //public override Task HandleAsync(CancellationToken ct)
    //{
    //    Response = new()
    //    {
    //        FullName = "john doe",
    //        Age = 124
    //    };
    //    return Task.CompletedTask;
    //}
}
