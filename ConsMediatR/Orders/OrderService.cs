using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsMediatR.Orders
{

    // Create an instance of Mediator
    public class OrderService : IOrderService
    {
        private readonly IMediator mediator;

        public OrderService(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task PlaceOrder(Guid orderId, DateTime orderDate, string customerId)
        {
            // Perform order placement logic here

            // Publish the OrderPlacedEvent
            await mediator.Publish(new OrderPlacedEvent(orderId, orderDate, customerId));
        }
    }

}
