using DiskCleaner.Core;

var scanner = new FileScanner();
var duplicateFinder = new DuplicateFinder();
var duplicateRemover = new DuplicateRemover();

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
   Console.WriteLine($"Scanned {fileCount} files in directory: {d}");
   allFiles.AddRange(files);
}

foreach (var f in allFiles)
{
    if(f.Length == 0)
    {
        if(duplicateRemover.RemoveDuplicate(f))
        {
            Console.WriteLine($"Deleted empty file: {f.FullName}");
        }
        else
        {
            Console.WriteLine($"Failed to delete empty file: {f.FullName}");
        }
    }
}

var sizeGroups = duplicateFinder.GroupBySize(allFiles);
Console.WriteLine($"Found {sizeGroups.Count} unique file sizes.");

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
                var smallestFile = j.Value[0];

                foreach (var f in j.Value)
                {
                    if(f.CreationTime < smallestFile.CreationTime)
                    {
                        smallestFile = f;
                    }
                }

                foreach (var f in j.Value)
                {
                    if(f.FullName != smallestFile.FullName)
                    {
                        if(duplicateRemover.RemoveDuplicate(f))
                        {
                            Console.WriteLine($"Deleted duplicate file: {f.FullName}, kept: {smallestFile.FullName}");
                        }
                        else
                        {
                            Console.WriteLine($"Failed to delete duplicate file: {f.FullName}");
                        }
                    }
                }
            }
        }
    }
}