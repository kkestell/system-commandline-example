using System.CommandLine;
using CommandLineExample.Commands.Archive;
using CommandLineExample.Commands.Download;

namespace CommandLineExample.Commands;

public class RootCommand : System.CommandLine.RootCommand
{
    public RootCommand() : base("Example")
    {
        AddCommand(new ArchiveCommand());
        AddCommand(new DownloadCommand());
    }
}