namespace ConsMediatR.Orders
{
    public interface IOrderService
    {
        Task PlaceOrder(Guid orderId, DateTime orderDate, string customerId);
    }
}