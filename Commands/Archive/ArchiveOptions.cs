namespace CommandLineExample.Commands.Archive;

internal class ArchiveOptions : BaseOptions
{
    public ArchiveOptions(ArchiveCommand command) : base(command)
    {
        SourceDirectory = Argument(command.SourceDirectory);
        Format = Option(command.Format) ?? "zip";
        ArchiveFile = Option(command.ArchiveFile) ?? new FileInfo(Path.Combine(Directory.GetCurrentDirectory(), $"archive.{Format}"));
        IncludeSubdirectories = Option(command.IncludeSubdirectories);
        CompressionLevel = Option(command.CompressionLevel);
        Password = Option(command.Password) ?? string.Empty;
        IncludeHiddenFiles = Option(command.IncludeHiddenFiles);
        Update = Option(command.Update);
    }

    public DirectoryInfo SourceDirectory { get; }
    public string Format { get; }
    public FileInfo ArchiveFile { get; }
    public bool IncludeSubdirectories { get; }
    public int CompressionLevel { get; }
    public string Password { get; }
    public bool IncludeHiddenFiles { get; }
    public bool Update { get; }
}