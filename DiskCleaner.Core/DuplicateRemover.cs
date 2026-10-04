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
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool IsRemovableDrive(string path)
        {
            try
            {
                var driveIsim = Path.GetPathRoot(path);
                if (driveIsim == null)
                {
                    return false;
                }

                var drive = new DriveInfo(driveIsim);
                return drive.DriveType == DriveType.Removable;
            }
            catch(ArgumentException)
            {
                return false;
            }
        }
    }
}