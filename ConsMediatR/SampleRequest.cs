using MediatR;



namespace ConsMediatR
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
