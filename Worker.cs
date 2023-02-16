
using System;
using System.Threading;
using System.Threading.Tasks;
using Company.Activities;
using Contracts;
using MassTransit;
using Microsoft.Extensions.Hosting;

namespace MassTransitDemo
{

    public class Worker : BackgroundService
    {
        readonly IBus _bus;

        public Worker(IBus bus)
        {
            _bus = bus;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                await _bus.Publish(new SendCartContract { CartId = "30096" }, stoppingToken);
                
                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}