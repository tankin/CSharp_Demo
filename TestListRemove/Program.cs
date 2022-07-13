using System;
using System.Collections.Generic;

namespace TestRemove
{
    class Program
    {
        public class UnitData
        {
            public int id = 0;
            public bool destroyed = false;
        }

        static List<UnitData> list = new List<UnitData>();
        
        static void Main(string[] args)
        {
            InitUnitDataList();
            list[1].destroyed = true;
            list[3].destroyed = true;
            ApplyDelayCommands();
            PrintInfo();

            Console.WriteLine("Hello World!");
        }

        static void InitUnitDataList()
        {
            for (int i = 0; i < 10; i++)
            {
                var d = new UnitData();
                d.id = i;
                d.destroyed = false;
                list.Add(d);
            }
        }

        static void ApplyDelayCommands()
        {
            int i = 0, j = 0;
            int count = list.Count;
            while (i < count)
            {
                if (list[i].destroyed)
                {
                    j = i + 1;
                    while (j < count)
                    {
                        if (!list[j].destroyed)
                        {
                            list[i] = list[j];
                            i++;
                        }
                        j++;
                    }
                    list.RemoveRange(i, count - i);
                    break;
                }
                i++;
            }
        }

        static void PrintInfo()
        {
            for (int i = 0; i < list.Count; i++)
            {
                string str = string.Format("{0}, {1}", list[i].id, list[i].destroyed.ToString());
                Console.WriteLine(str);
            }
        }
    }
}
