namespace DiskCleaner.Core
{
    public class DuplicatePair
    {
        public FileInfo keptFileInfo;
        public FileInfo duplicateFileInfo;

        public DuplicatePair(FileInfo kptInfo, FileInfo dupInfo)
        {
            keptFileInfo = kptInfo;
            duplicateFileInfo = dupInfo;
        }
    }
}