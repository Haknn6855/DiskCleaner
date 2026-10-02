using DiskCleaner.Core;

var scanner = new FileScanner();

List<string> directories = new List<string>();

Console.WriteLine("Enter directories to scan (type 'done' when finished):");

while (true)
{
    string input = Console.ReadLine();
    if (input.ToLower() == "done")
    {
        break;
    }
    directories.Add(input);
}

foreach (var d in directories)
{
    var fileCount = scanner.ScanFiles(d).Count();
    Console.WriteLine("Files found: " + fileCount);

}