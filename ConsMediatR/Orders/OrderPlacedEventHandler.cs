using MediatR;

namespace ConsMediatR.Orders
{
    // Define a handler for the event
    public class OrderPlacedEventHandler : INotificationHandler<OrderPlacedEvent>
    {
        public Task Handle(OrderPlacedEvent notification, CancellationToken cancellationToken)
        {
            Console.WriteLine($"Order placed - OrderId: {notification.OrderId}, OrderDate: {notification.OrderDate}, CustomerId: {notification.CustomerId}");
            // Perform any additional logic or actions here
            return Task.CompletedTask;
        }
    }

}
