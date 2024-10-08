using System;
using Internal;

namespace lab2_2
{
    class MyTime
    {
        private int hour, minute, second;

        public MyTime(int h, int m, int s)
        {
            this.hour = h;
            this.minute = m;
            this.second = s;
        }

        public override string ToString()
        {
            return $"{hour:D2}:{minute:D2}:{second:D2}";
        }

        public int TimeSinceMidnight()
        {
            return hour * 3600 + minute * 60 + second;
        }

    }

    class Program
    {
        public static void Main()
        {
            Console.WriteLine(new MyTime(2, 2, 2));
            Console.ReadKey();
        }
    }
}