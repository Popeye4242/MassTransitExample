using System.IO;

namespace Company.Activities
{
    using System.Threading.Tasks;
    using MassTransit;

    public class MoveFileActivity :
        IActivity<MoveFileArguments, MoveFileLog>
    {
        public async Task<ExecutionResult> Execute(ExecuteContext<MoveFileArguments> context)
        {
            await Task.Delay(100);

            return context.Completed<MoveFileLog>(new 
            {
                FilePath = context.Arguments.DestinationDirectory + Path.GetFileName(context.Arguments.Filename)
            });
        }

        public async Task<CompensationResult> Compensate(CompensateContext<MoveFileLog> context)
        {
            await Task.Delay(100);
            
            return context.Compensated();
        }
    }
}