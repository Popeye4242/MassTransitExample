using MassTransit.Courier.Contracts;

namespace Company.Consumers
{
    using System.Threading.Tasks;
    using MassTransit;
    using Contracts;

    public class RoutingSlipCompletedConsumer :
        IConsumer<RoutingSlipCompleted>
    {
        public Task Consume(ConsumeContext<RoutingSlipCompleted> context)
        {
            return Task.CompletedTask;
        }
    }
}