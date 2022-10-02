

using System.Runtime.CompilerServices;

namespace Intoduction{ 

public class Program
{
    private static void Main(string[] args)
    {
            string path = @"C:\Users\user";
            showLargFilesWithoutLinq(path);
    }

    private static void showLargFilesWithoutLinq(string path)
        {
            DirectoryInfo getFile = new DirectoryInfo(path);
            FileInfo[] file =  getFile.GetFiles();
            Array.Sort(file,new FileInfoCompare());
            for (int i=0;i<5;i++)
            {
                FileInfo item = file[i];   
                Console.WriteLine($"{item.Name ,-20} : {item.Length,10:N0}");
            }
    }
}

    public class FileInfoCompare : IComparer<FileInfo>
    {
        public  int Compare(FileInfo? x, FileInfo? y)
        {
            return y.Length.CompareTo(x.Length);
        }
    }

}