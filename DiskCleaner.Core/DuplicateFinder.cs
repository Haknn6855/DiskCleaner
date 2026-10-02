namespace DiskCleaner.Core
{
    using System.Security.Cryptography;
    public class DuplicateFinder
    {
        public Dictionary<long, List<FileInfo>> GroupBySize(IEnumerable<FileInfo> files)
        {
            var fileInfos = new Dictionary<long, List<FileInfo>>();
            foreach (var file in files)
            {
                var fileSize = file.Length;

                if (fileInfos.ContainsKey(fileSize))
                {
                    fileInfos[fileSize].Add(file);
                }
                else
                {
                    fileInfos[fileSize] = new List<FileInfo> { file };
                }
            }
            return fileInfos;
        }
        public string FindFileHash(FileInfo file)
        {
            using var stream = file.OpenRead();
            byte [] hash = SHA256.HashData(stream);
            var hashYazi = Convert.ToHexString(hash);
            return hashYazi;
        }
    }
}