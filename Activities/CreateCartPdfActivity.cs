namespace Company.Activities
{
    using System.Threading.Tasks;
    using MassTransit;

    public class CreateCartPdfActivity :
        IActivity<CreateCartPdfArguments, CreateCartPdfLog>
    {
        public async Task<ExecutionResult> Execute(ExecuteContext<CreateCartPdfArguments> context)
        {
            await Task.Delay(100);

            var filename = $@"C:\test_{context.Arguments.CartId}.pdf";
            return context.CompletedWithVariables<CreateCartPdfLog>(new
            {
                Filename = filename
            }, new 
            {
                Filename = filename
            });
        }

        public async Task<CompensationResult> Compensate(CompensateContext<CreateCartPdfLog> context)
        {
            await Task.Delay(100);
            
            return context.Compensated();
        }
    }
}