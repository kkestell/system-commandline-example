# `System.CommandLine` Example

Example C# console application using the `System.CommandLine` library. Implements `archive` and `download` subcommands with various options.

See: [https://github.com/dotnet/command-line-api](https://github.com/dotnet/command-line-api)

## Examples

### Root Command

```console
$ dotnet run -- --help
Description:
  Example

Usage:
  Example [command] [options]

Options:
  -v, --version   Show version information
  -?, -h, --help  Show help and usage information

Commands:
  archive <source>  Create an archive of a directory
  download <uri>    Download a file from the internet
```

### Archive Command

```console
$ dotnet run -- archive --help
Description:
  Create an archive of a directory

Usage:
  Example archive <source> [options]

Arguments:
  <source>  Source directory to create archive from

Options:
  -v, --verbosity <Normal|Quiet>   Verbosity level [default: Normal]
  -o, --out <out>                  Destination archive file
  -r, --recursive                  Include subdirectories in the archive [default: False]
  -f, --format <format>            Archive format (zip, tar, etc.)
  -c, --compression <compression>  Compression level (0-9) [default: 5]
  -p, --password <password>        Password to encrypt the archive
  -h, --hidden                     Include hidden files [default: False]
  -u, --update                     Update an existing archive [default: False]
  -?, -h, --help                   Show help and usage information
```

```console
dotnet run -- archive .
Source Directory: /home/kyle/src/system-commandline-example
Archive File: /home/kyle/src/system-commandline-example/archive.zip
Include Subdirectories: False
Format: zip
Compression Level: 5
Password: 
Include Hidden Files: False
Update Existing Archive: False
```

### Download Command

```console
$ dotnet run -- download --help
Description:
  Download a file from the internet

Usage:
  Example download <uri> [options]

Arguments:
  <uri>  URI of the file to be downloaded

Options:
  -v, --verbosity <Normal|Quiet>  Verbosity level [default: Normal]
  -o, --out <out>                 Destination file to write downloaded content to
  -w, --overwrite                 Overwrite the existing file if it already exists [default: False]
  --max-retries <max-retries>     Maximum number of retry attempts if the download fails [default: 3]
  --retry-delay <retry-delay>     Delay in seconds between retry attempts [default: 5]
  --proxy <proxy>                 Proxy server to use for the download
  --timeout <timeout>             Timeout in seconds for the download operation [default: 30]
  --user-agent <user-agent>       User agent string to use in the HTTP request
  -?, -h, --help                  Show help and usage information
```

```console
$ dotnet run -- download https://example.com/index.html
Download URL: https://example.com/index.html
Output File: /home/kyle/src/system-commandline-example/index.html
Overwrite: False
Max Retries: 3
Retry Delay: 5
Proxy: 
Timeout: 30
User Agent: 
```
