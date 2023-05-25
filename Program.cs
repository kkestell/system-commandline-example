using System.CommandLine.Builder;
using System.CommandLine.Parsing;
using RootCommand=CommandLineExample.Commands.RootCommand;

namespace CommandLineExample;

internal abstract class Program
{
    private static int Main(string[] args) =>
        new CommandLineBuilder(new RootCommand())
            .UseVersionOption("--version", "-v")
            .UseParseErrorReporting()
            .UseHelp()
            .UseTypoCorrections()
            .Build()
            .Invoke(args);
}