namespace Company.Consumers
{
    using MassTransit;

    public class RoutingSlipCompletedConsumerDefinition :
        ConsumerDefinition<RoutingSlipCompletedConsumer>
    {
        protected override void ConfigureConsumer(IReceiveEndpointConfigurator endpointConfigurator, IConsumerConfigurator<RoutingSlipCompletedConsumer> consumerConfigurator)
        {
            endpointConfigurator.UseMessageRetry(r => r.Intervals(500, 1000));
        }
    }
}