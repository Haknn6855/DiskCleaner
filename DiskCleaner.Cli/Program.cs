using DiskCleaner.Core;

var scanner = new FileScanner();
var duplicateFinder = new DuplicateFinder();

List<string> directories = new List<string>();

Console.WriteLine("Enter directories to scan (type 'done' when finished):");

while (true)
{
    string? input = Console.ReadLine();

    if(input == null)
    {
        break;
    }
    input = input.Trim(' ', '"');

    if (input?.ToLower() == "done")
    {
        break;
    }

    else if(string.IsNullOrWhiteSpace(input))
    {
        Console.WriteLine("Please enter a valid directory path.");
        continue;
    }

    if(Directory.Exists(input))
    {
        directories.Add(input);
    }

    else
    {
        Console.WriteLine("Directory does not exist: " + input);
    }
}
    
if(directories.Count == 0)
{
    Console.WriteLine("No directories provided. Exiting.");
    return;
}

List<FileInfo> allFiles = new List<FileInfo>();

foreach (var d in directories)
{
   var files = scanner.ScanFiles(d);
   var fileCount = files.Count();
   allFiles.AddRange(files);
   Console.WriteLine($"Scanned {fileCount} files in directory: {d}");
}

var sizeGroups = duplicateFinder.GroupBySize(allFiles);

foreach (var i in sizeGroups)
{
    if(i.Value.Count < 2)
    {
        continue;
    }
    else
    {
        var hashGroups = duplicateFinder.GroupByHash(i.Value);
        foreach (var j in hashGroups)
        {
            if(j.Value.Count < 2)
            {
                continue;
            }
            else
            {
                Console.WriteLine($"Duplicate files found: {j.Key}");
                foreach (var file in j.Value)
                {
                    Console.WriteLine($" - {file.FullName}");
                }
            }
        }
    }
}