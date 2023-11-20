using MediatR;

namespace ConsMediatR
{
    public class SampleRequestHandler : IRequestHandler<SampleRequest, string>
    {
        public Task<string> Handle(SampleRequest request, CancellationToken cancellationToken)
        {
            // Process the request and return the result
            string result = "Hello, " + request.Message + "!";
            return Task.FromResult(result);
        }
    }


}
