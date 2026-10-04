using Microsoft.VisualBasic.FileIO;

namespace DiskCleaner.Core
{
    public class DuplicateRemover
    {
        public bool RemoveDuplicate(FileInfo fileInfo)
        {
            try
            {
                FileSystem.DeleteFile(fileInfo.FullName, UIOption.OnlyErrorDialogs, RecycleOption.SendToRecycleBin);
                Console.WriteLine("Deleted file: " + fileInfo.FullName);
                return true;
            }
            catch
            {
                Console.WriteLine("Failed to delete file: " + fileInfo.FullName);
                return false;
            }
        }
    }
}