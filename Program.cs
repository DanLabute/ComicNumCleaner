using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComicNumCleaner
{
    class Program
    {
        static void Main()
        {
            string sourcePath = @".";

            string[] fileList = Directory.GetFiles(sourcePath, "*", SearchOption.AllDirectories);
            string fileName;
            string fileExtension;
            string destFileName;
            string containingFolder;
            string[] currentDir;

            foreach (string s in fileList)
            {
                currentDir = s.Split('\\');
                if (currentDir[currentDir.Length-2] == "temp")
                {
                    continue;
                }
                containingFolder = Path.GetDirectoryName(s);
                fileName = Path.GetFileNameWithoutExtension(s);
                fileExtension = Path.GetExtension(s);

                switch (fileName.Length) {
                    case 1:
                        destFileName = containingFolder + @"\00" + fileName + fileExtension;
                        RenameFile(s, destFileName);
                        continue;
                    case 2:
                        destFileName = containingFolder + @"\0" + fileName + fileExtension;
                        RenameFile(s, destFileName);
                        continue;
                    default:
                        destFileName = fileName + fileExtension;
                        continue;
                }
            }
        }

        private static void RenameFile(string sourcePath, string destPath)
        {
            if (!File.Exists(destPath))
            {
                System.IO.File.Move(sourcePath, destPath);
                Console.WriteLine("Renamed: " + sourcePath + " -> " + destPath);
            }
            else
            {
                Console.WriteLine("Skipped: " + destPath + " (File already exists)");
            }
        }

    }
}
