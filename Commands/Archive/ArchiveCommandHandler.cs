namespace CommandLineExample.Commands.Archive;

internal class ArchiveCommandHandler
{
    private readonly ArchiveOptions _options;

    public ArchiveCommandHandler(ArchiveCommand command)
    {
        _options = new ArchiveOptions(command);
    }

    public int Run()
    {
        Console.WriteLine($"Source Directory: {_options.SourceDirectory.FullName}");
        Console.WriteLine($"Archive File: {_options.ArchiveFile.FullName}");
        Console.WriteLine($"Include Subdirectories: {_options.IncludeSubdirectories}");
        Console.WriteLine($"Format: {_options.Format}");
        Console.WriteLine($"Compression Level: {_options.CompressionLevel}");
        Console.WriteLine($"Password: {_options.Password}");
        Console.WriteLine($"Include Hidden Files: {_options.IncludeHiddenFiles}");
        Console.WriteLine($"Update Existing Archive: {_options.Update}");
        
        return 0;
    }
}