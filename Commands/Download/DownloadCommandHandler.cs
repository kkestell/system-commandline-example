namespace CommandLineExample.Commands.Download;

internal class DownloadCommandHandler
{
    private readonly DownloadOptions _options;

    public DownloadCommandHandler(DownloadCommand command)
    {
        _options = new DownloadOptions(command);
    }

    public int Run()
    {
        Console.WriteLine($"Download URL: {_options.DownloadUri}");
        Console.WriteLine($"Output File: {_options.OutputFile.FullName}");
        Console.WriteLine($"Overwrite: {_options.Overwrite}");
        Console.WriteLine($"Max Retries: {_options.MaxRetries}");
        Console.WriteLine($"Retry Delay: {_options.RetryDelay}");
        Console.WriteLine($"Proxy: {_options.Proxy}");
        Console.WriteLine($"Timeout: {_options.Timeout}");
        Console.WriteLine($"User Agent: {_options.UserAgent}");
        
        return 0;
    }
}