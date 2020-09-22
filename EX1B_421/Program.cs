using System;
using System.Collections.Generic;
using System.Text;



namespace EX1B_421
{
    public struct KeyValue<T>
    {
        public readonly string Key;
        public readonly T Value;
        public KeyValue(string key, T value)
        {
            this.Key = key;
            this.Value = value;
        }
    }

public class MyDictionary
    {
        public KeyValue<int>[] keys = new KeyValue<int>[5];
        public int nextIndex = 0;

        public object this[string index]
        {
            get
            {

                for (int i = 0; i < keys.Length; i++)
                {
                    if (index == keys[i].Key)
                    {
                        return keys[i].Value;
                    }
                }
                throw new KeyNotFoundException("No Key Found!");

            }
            set

            {
                bool isfound = true;
                for (int i = 0; i <= nextIndex; i++)
                {
                    if (this.keys[i].Key == index)
                    {
                        this.keys[i] = new KeyValue<int>(index, (int)value);
                    }
                    isfound = false;

                }
                if (isfound == false)
                {
                    keys[nextIndex] = new KeyValue<int>(index, (int)value);

                }
                nextIndex++;


            }


        }


    }
    public class Program
    {
        static void Main()
        {
            var d = new MyDictionary();
            try
            {
                Console.WriteLine(d["Cats"]);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            d["Cats"] = 42;
            d["Dogs"] = 17;
            Console.WriteLine($"{(int)d["Cats"]}, {(int)d["Dogs"]}");
            Console.ReadLine();
        }
    }
}