using DiskCleaner.Core;

var scanner = new FileScanner();

foreach (var file in scanner.ScanFiles("/Users/hakan/Desktop/Dersler"))
{
    Console.WriteLine($"Scanning Files: {file.Name}, {file.Length}");
}