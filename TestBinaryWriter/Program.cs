using System;
using System.IO;

namespace TestBinaryWriter
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            FileStream fileStream = new FileStream(@"D:\\test.txt", FileMode.OpenOrCreate, FileAccess.Write);
            //创建二进制写入流的实例
            BinaryWriter binaryWriter = new BinaryWriter(fileStream);
            binaryWriter.Write(false);
            //向文件中写入图书名称
            binaryWriter.Write("4C#123基础教程"); // 第一个byte是string的长度
            //向文件中写入图书价格
            binaryWriter.Write(49.5);
            //清除缓冲区的内容，将缓冲区中的内容写入到文件中
            binaryWriter.Flush();
            //关闭二进制流
            binaryWriter.Close();
            //关闭文件流
            fileStream.Close();
        }

        static void AnotherWay()
        {            
            using (FileStream fileStream = new FileStream(@"D:\\test.txt", FileMode.OpenOrCreate, FileAccess.Write))
            {
                int size = 1;
                byte[] bytes = BitConverter.GetBytes(size);
                int ix = BitConverter.ToInt32(bytes, 0); // for check
                fileStream.Write(bytes, 0, bytes.Length);

                byte[] content = { 0x1a, 0xcc };
                fileStream.Write(content, 0, content.Length);

                string str = "AC测试";
                System.Text.Encoding en = new System.Text.UTF8Encoding(false);
                byte[] byteStr = en.GetBytes(str);
                fileStream.Write(byteStr, 0, byteStr.Length);
            }
        }
    }
}
