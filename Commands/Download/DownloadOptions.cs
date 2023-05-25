namespace CommandLineExample.Commands.Download;

internal class DownloadOptions : BaseOptions
{
    public DownloadOptions(DownloadCommand command) : base(command)
    {
        DownloadUri = Argument(command.DownloadUri);
        OutputFile = Option(command.OutputFile) ?? new FileInfo(Path.Combine(Directory.GetCurrentDirectory(), DownloadUri.Segments.Last()));
        Overwrite = Option(command.Overwrite);
        MaxRetries = Option(command.MaxRetries);
        RetryDelay = Option(command.RetryDelay);
        Proxy = Option(command.Proxy) ?? string.Empty;
        Timeout = Option(command.Timeout);
        UserAgent = Option(command.UserAgent) ?? string.Empty;
    }

    public Uri DownloadUri { get; }
    public FileInfo OutputFile { get; }
    public bool Overwrite { get; }
    public int MaxRetries { get; }
    public int RetryDelay { get; }
    public string Proxy { get; }
    public int Timeout { get; }
    public string UserAgent { get; }
}