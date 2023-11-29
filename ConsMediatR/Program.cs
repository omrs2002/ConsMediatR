using MediatR;
using ConsMediatR.Orders;
using ConsMediatR.Requests;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;

namespace ConsMediatR
{
    internal class Program
    {
        private static async Task Main(string[] args)
        {
            Console.WriteLine("Hello MediatR!");

            var serviceProvider = ConfigureServices();

            try
            {
                await ExecuteApplicationLogic(serviceProvider);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }

            Console.WriteLine("Press any key to end...");
            Console.ReadKey();
        }



        private static IServiceProvider ConfigureServices()
        {
            var services = new ServiceCollection();

            services.AddMediatR(
                        cfg =>
                        {
                            cfg.RegisterServicesFromAssembly(typeof(Program).Assembly);
                            //cfg.BehaviorsToRegister.Add<OrderPlacedEvent, OrderPlacedEventHandler>();
                        }
                    );

            services.AddSingleton<IMediator, Mediator>();

            // Register other services and dependencies here
            services.AddTransient<IOrderService, OrderService>();


            // Add logging
            services.AddLogging(builder =>
            {
                builder.AddConsole();
                // Add additional logging providers if needed
            });

            var serviceProvider = services.BuildServiceProvider();
            return serviceProvider;
        }


        private static async Task ExecuteApplicationLogic(IServiceProvider serviceProvider)
        {
            var mediator = serviceProvider.GetRequiredService<IMediator>();

            // Create a sample request
            var request = new SampleRequest { Message = "World" };

            // Send the request and get the response
            var response = await mediator.Send(request);

            // Display the response
            Console.WriteLine(response);

            var orderService = serviceProvider.GetRequiredService<IOrderService>();

            // Place an order
            await orderService.PlaceOrder(Guid.NewGuid(), DateTime.Now, "12345");
        }

    }
}