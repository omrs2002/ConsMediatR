using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


namespace ConsMediatR
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            var host = new HostBuilder()
                  .ConfigureServices(async services =>
                  {
                      services.AddMediatR(
                          cfg =>
                          {
                              cfg.RegisterServicesFromAssembly(typeof(Program).Assembly);
                              //cfg.BehaviorsToRegister.Add<OrderPlacedEvent, OrderPlacedEventHandler>();
                          }
                      );
                      var serviceProvider = services.BuildServiceProvider();

                      // Resolve the service and use it
                      var mediator = serviceProvider.GetRequiredService<IMediator>();

                      // Create a sample request
                      var request = new SampleRequest { Message = "World" };

                      // Send the request and get the response
                      var response = await mediator.Send(request);

                      // Display the response
                      Console.WriteLine(response);
                  })
                  .Build();


        }
    }
}