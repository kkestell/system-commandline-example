using System.CommandLine;

namespace CommandLineExample.Commands.Archive;

internal class ArchiveCommand : BaseCommand
{
    public Argument<DirectoryInfo> SourceDirectory { get; } = new("source", "Source directory to create archive from");

    public Option<FileInfo> ArchiveFile { get; } =
        new(new[] { "--out", "-o" }, "Destination archive file");

    public Option<bool> IncludeSubdirectories { get; } =
        new(new[] { "--recursive", "-r" }, () => false, "Include subdirectories in the archive");

    public Option<string> Format { get; } =
        new(new[] { "--format", "-f" }, "Archive format (zip, tar, etc.)");

    public Option<int> CompressionLevel { get; } =
        new(new[] { "--compression", "-c" }, () => 5, "Compression level (0-9)");

    public Option<string> Password { get; } =
        new(new[] { "--password", "-p" }, "Password to encrypt the archive");

    public Option<bool> IncludeHiddenFiles { get; } =
        new(new[] { "--hidden", "-h" }, () => false, "Include hidden files");

    public Option<bool> Update { get; } =
        new(new[] { "--update", "-u" }, () => false, "Update an existing archive");

    public ArchiveCommand() : base("archive", "Create an archive of a directory")
    {
        AddArgument(SourceDirectory);
        AddOption(ArchiveFile);
        AddOption(IncludeSubdirectories);
        AddOption(Format);
        AddOption(CompressionLevel);
        AddOption(Password);
        AddOption(IncludeHiddenFiles);
        AddOption(Update);

        this.SetHandler(context =>
        {
            Result = context.ParseResult;
            try
            {
                context.ExitCode = new ArchiveCommandHandler(this).Run();
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