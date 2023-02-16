namespace Company.Activities
{
    public interface MoveFileArguments
    {
        string Filename { get; set; }
        string DestinationDirectory { get; set; }
    }
}