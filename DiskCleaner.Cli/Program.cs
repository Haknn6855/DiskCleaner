using DiskCleaner.Core;

var scanner = new FileScanner();

foreach (var file in scanner.ScanFiles("C:\\Users\\Hakan\\Documents"))
{
    Console.WriteLine($"Scanning Files: {file.Name}, {file.Length}");
}