using MediatR;

namespace ConsMediatR.Orders
{
    public class OrderPlacedEvent : INotification
    {
        public Guid OrderId { get; }
        public DateTime OrderDate { get; }
        public string CustomerId { get; }

        public OrderPlacedEvent(Guid orderId, DateTime orderDate, string customerId)
        {
            OrderId = orderId;
            OrderDate = orderDate;
            CustomerId = customerId;
        }
    }

}
