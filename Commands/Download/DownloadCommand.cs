using System.CommandLine;

namespace CommandLineExample.Commands.Download;

internal class DownloadCommand : BaseCommand
{
    public Argument<Uri> DownloadUri { get; } = new("uri", "URI of the file to be downloaded");
    
    public Option<FileInfo> OutputFile { get; } =
        new(new[] { "--out", "-o" }, "Destination file to write downloaded content to");
    
    public Option<bool> Overwrite { get; } =
        new(new[] { "--overwrite", "-w" }, () => false, "Overwrite the existing file if it already exists");

    public Option<int> MaxRetries { get; } =
        new(new[] { "--max-retries" }, () => 3, "Maximum number of retry attempts if the download fails");

    public Option<int> RetryDelay { get; } =
        new(new[] { "--retry-delay" }, () => 5, "Delay in seconds between retry attempts");

    public Option<string> Proxy { get; } =
        new(new[] { "--proxy" }, "Proxy server to use for the download");

    public Option<int> Timeout { get; } =
        new(new[] { "--timeout" }, () => 30, "Timeout in seconds for the download operation");

    public Option<string> UserAgent { get; } =
        new(new[] { "--user-agent" }, "User agent string to use in the HTTP request");

    public DownloadCommand() : base("download", "Download a file from the internet")
    {
        AddArgument(DownloadUri);
        AddOption(OutputFile);
        AddOption(Overwrite);
        AddOption(MaxRetries);
        AddOption(RetryDelay);
        AddOption(Proxy);
        AddOption(Timeout);
        AddOption(UserAgent);

        this.SetHandler(context =>
        {
            Result = context.ParseResult;
            try
            {
                context.ExitCode = new DownloadCommandHandler(this).Run();
            }
            catch (Exception e)
            {
                Console.Error.WriteLine(e.Message);
                Console.Error.WriteLine(e.StackTrace);
                context.ExitCode = 1;
            }
        });
    }
}
