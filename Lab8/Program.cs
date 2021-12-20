using System;
using System.IO;

namespace Lab8
{
    class Program
    {
        static void Main(string[] args)
        {
            string d = "D:\\Lab08";
            Create(d);
            Copy(d + "\\Texts", d + "\\Kolesnyk");
            Copy(d + "\\Sources", d + "\\Kolesnyk");
            Copy(d + "\\Reports", d + "\\Kolesnyk");
            Console.WriteLine("Каталоги  скопiйованo");
            Move(d + "\\Kolesnyk",d + "\\Kn1-b20" + "\\Kolesnyk");

            string dirName = d + "\\Texts";
            DirectoryInfo dInfo = new DirectoryInfo(dirName);
            string text = $"Назва каталогу: {dInfo.Name}\n" +
                          $"Повна назва каталогу: {dInfo.FullName}\n" +
                          $"Час створення : {dInfo.CreationTime}\n" +
                          $"Кореневий каталог: {dInfo.Root}";
            Console.WriteLine("Текстовий файл створено, та помiщено iнформацiю: \n" + text);
            using (FileStream fstream = new FileStream(d + "\\Texts\\dirinfo.txt", FileMode.OpenOrCreate))
            {
                byte[] array = System.Text.Encoding.Default.GetBytes(text);
                fstream.Write(array, 0, array.Length);
            }

            void Create(string path)
            {
                Directory.CreateDirectory(path);
                Directory.CreateDirectory(path + "\\Kn1-b20" + "\\Kolesnyk");
                Directory.CreateDirectory(path + "\\Kolesnyk");
                Directory.CreateDirectory(path + "\\Sources");
                Directory.CreateDirectory(path + "\\Reports");
                Directory.CreateDirectory(path + "\\Texts");
            }
            void Copy(string path1, string path2)
            {
                DirectoryInfo dirinf1 = new DirectoryInfo(path1);
                DirectoryInfo dirinf2 = new DirectoryInfo(path2);
                string name = dirinf1.Name;
                Directory.CreateDirectory(path2 + $@"\{name}");
            }
            void Move(string path1, string path2)
            {
                DirectoryInfo dirinf = new DirectoryInfo(path2);
                if (dirinf.Exists)
                {
                    dirinf.Delete(true);
                }
                new DirectoryInfo(path1).MoveTo(path2);
                Console.WriteLine("Каталог перемiщено");
            }
        }
    }
}
