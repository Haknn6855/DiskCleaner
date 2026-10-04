namespace DiskCleaner.Core
{
    public class FileScanner
    {
        public IEnumerable<FileInfo> ScanFiles(string directoryPath)
        {
            List<FileInfo> fileInfo = new List<FileInfo>();

            var enumOptions = new EnumerationOptions {RecurseSubdirectories = true};

            var files = Directory.GetFiles(directoryPath, "*", enumOptions);
            
            foreach (var file in files)
            {
                fileInfo.Add(new FileInfo(file));
            }
            return fileInfo;
        }
    }
}
