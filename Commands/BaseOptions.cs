using System.CommandLine;

namespace CommandLineExample.Commands;

internal abstract class BaseOptions
{
    private readonly BaseCommand _command;

    protected BaseOptions(BaseCommand command)
    {
        _command = command;
        
        Verbosity = Option(command.Verbosity);
    }
    
    public VerbosityLevel Verbosity { get; }

    protected T Argument<T>(Argument<T> argument) => _command.Result!.GetValueForArgument(argument);

    protected T? Option<T>(Option<T> option) => _command.Result!.GetValueForOption(option);
}