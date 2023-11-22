using MediatR;



namespace ConsMediatR.Requests
{

    public class SampleRequest : IRequest<string>
    {
        public string? Message { get; set; }
    }

    public class SampleResponse
    {
        public string? Result { get; set; }
    }


}
