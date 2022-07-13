using System;
using System.Collections.Generic;

namespace TestJson
{
    class Program
    {
        public static void Main()
        {
//             LitJson.JsonMapper.RegisterExporter<HelloWorld>((v, w) =>
//             {
//                 w.WriteObjectStart();
//                 w.WritePropertyName("FNum");
//                 w.Write(v.FNum);
//                 w.WriteObjectEnd();
//             });

            TestObj();
            PrintLine();

            TestIntArray();
            PrintLine();

            TestArray();
            PrintLine();

            TestList();
            PrintLine();

            TestDictionary();
            PrintLine();
        }

        static void PrintLine()
        {
            Console.WriteLine("\n---------------------------------\n");
        }

        static void TestObj()
        {
            // Serialize object to JSON
            var toObject = new HelloWorld { Message = "Hello world!", FNum = 1.1f };
            var toJson = LitJson.JsonMapper.ToJson(toObject);
            Console.WriteLine("To JSON: {0}", toJson);

            // Serialize JSON to object
            var fromJson = "{\"Message\":\"Hello world!\", \"FNum\":1.2 }";
            var fromObject = LitJson.JsonMapper.ToObject<HelloWorld>(fromJson);
            Console.WriteLine("From json: {0}, {1}", fromObject.Message, fromObject.FNum);
        }

        static void TestIntArray()
        {
            var intArray = new int[4] { 1, 20, 33, 31 };
            var intStr = LitJson.JsonMapper.ToJson(intArray);
            Console.WriteLine("Int Array to json: {0}", intStr);

            int[] intObjArray = LitJson.JsonMapper.ToObject<int[]>(intStr);
            for (int i = 0; i < intObjArray.Length; i++)
            {
                Console.WriteLine("intObjArray, {0}, {1}", i, intObjArray[i]);
            }
        }

        static void TestArray()
        {
            var arr = new HelloWorld[3];
            for (int i = 0; i < arr.Length; i++)
            {
                int v = i + 1;
                arr[i] = new HelloWorld();
                arr[i].Message = (v*v).ToString();
                arr[i].FNum = v / 10.0f;
            }

            var str = LitJson.JsonMapper.ToJson(arr);
            Console.WriteLine("Array to json: {0}", str);

            HelloWorld[] objArray = LitJson.JsonMapper.ToObject<HelloWorld[]>(str);
            for (int i = 0; i < objArray.Length; i++)
            {
                Console.WriteLine("object Array, {0}, {1}, {2}", i, objArray[i].Message, objArray[i].FNum);
            }
        }

        static void TestList()
        {
            List<int> list = new List<int>();
            list.Add(1);
            list.Add(10);
            list.Add(111);

            var str = LitJson.JsonMapper.ToJson(list);
            Console.WriteLine("List json : {0}", str);

            var objList = LitJson.JsonMapper.ToObject<List<int>>(str);
            for (int i = 0; i < objList.Count; i++)
            {
                Console.WriteLine("List int : {0}", objList[i]);
            }
        }

        static void TestDictionary()
        {
            Dictionary<int, string> dic = new Dictionary<int, string>();
            dic[0] = "zero";
            dic[11] = "eleven";
            dic[2] = "two";
            dic[10] = "Ten";

            string str = LitJson.JsonMapper.ToJson(dic);
            Console.WriteLine("Dictionary Json: {0}", str);

            var obj = LitJson.JsonMapper.ToObject<Dictionary<string, string>>(str);
            foreach (var item in obj)
            {
                Console.WriteLine("Dictionnary Obj: {0}, {1}", item.Key, item.Value);
            }
        }

        public class HelloWorld
        {
            [LitJson.JsonIgnore]
            public string Message { get; set; }            
            public float FNum { get; set; }
        }

        
    }
}
