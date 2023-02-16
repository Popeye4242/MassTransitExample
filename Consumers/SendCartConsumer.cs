using System;
using System.Collections.Generic;
using Company.Activities;

namespace Company.Consumers
{
    using System.Threading.Tasks;
    using MassTransit;
    using Contracts;

    public class SendCartConsumer :
        IConsumer<SendCartContract>
    {
        private readonly IEndpointNameFormatter _formatter;

        public SendCartConsumer(IEndpointNameFormatter formatter)
        {
            _formatter = formatter;
        }
        
        public Task Consume(ConsumeContext<SendCartContract> context)
        {
            
            var builder = new RoutingSlipBuilder(NewId.NextGuid());

            var queueName = _formatter.ExecuteActivity<CreateCartPdfActivity, CreateCartPdfArguments>();
            builder.AddVariable("CartId", context.Message.CartId);
            builder.AddActivity("CreatePDF", new Uri($"queue:{queueName}"), new
            {
                Value = "test"   
            });
            
            queueName = _formatter.ExecuteActivity<MoveFileActivity, MoveFileArguments>();
            builder.AddActivity("MovePDF", new Uri($"queue:{queueName}"), new
            {
                DestinationPath = @"D:\"
            });
            context.Execute(builder.Build());

            return Task.CompletedTask;
        }
    }
}