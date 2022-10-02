

using System.Runtime.CompilerServices;

namespace Intoduction{ 

public class Program
{
    private static void Main(string[] args)
    {
            string path = @"C:\Users\user";
            showLargFilesWithoutLinq(path);
            Console.WriteLine("********8********");
            showLargFilesWithLinq(path);
        }

        private static void showLargFilesWithLinq(string path)
        {

            //var query = from file in new DirectoryInfo(path).GetFiles()
            //            orderby file.Length descending
            //            select file;
            var query = from file in new DirectoryInfo(path).GetFiles()
                        .OrderByDescending(f => f.Length).Take(5)
                        select file;
            foreach (FileInfo file in query)
            {
                Console.WriteLine($"{file.Name , -20} :  {file.Length,10:N0}");
            }
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