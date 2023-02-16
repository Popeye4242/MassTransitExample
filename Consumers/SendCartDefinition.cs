namespace Company.Consumers
{
    using MassTransit;

    public class SendCartDefinition :
        ConsumerDefinition<SendCartConsumer>
    {
        public SendCartDefinition()
        {
        }
        protected override void ConfigureConsumer(IReceiveEndpointConfigurator endpointConfigurator, IConsumerConfigurator<SendCartConsumer> consumerConfigurator)
        {
            endpointConfigurator.UseMessageRetry(r => r.Intervals(500, 1000));
            
        }
    }
}