using System;
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

        public static MyTime TimeSinceMidnight(int t)
        {
            int secPerDay = 60 * 60 * 24;
            t %= secPerDay;
            if (t < 0)
                t += secPerDay;
            int h = t / 3600;
            int m = (t / 60) % 60;
            int s = t % 60;
            return new MyTime(h, m, s);
        }

        public MyTime AddOneSecond()
        {
            second++;
            if (second >= 60)
            {
                second %= 60;
                minute++;
                if (minute >= 60)
                {
                    minute %= 60;
                    hour++;
                    if (hour >= 24)
                        hour %= 24;
                }
            }
            return new MyTime(hour, minute, second);
        }

        public MyTime AddOneMinute()
        {
            minute++;
            if (minute >= 60)
            {
                minute %= 60;
                hour++;
                if (hour >= 24)
                    hour %= 24;
            }
            return new MyTime(hour, minute, second);
        }

        public MyTime AddOneHour()
        {
            hour++;
            if (hour >= 24)
                hour %= 24;
            return new MyTime(hour, minute, second);
        }

        public MyTime AddSeconds(int s)
        {
            second += s;
            if (second >= 60)
            {
                second %= 60;
                minute += s / 60;
                if (minute >= 60)
                {
                    minute %= 60;
                    hour += s / 3600;
                    if (hour >= 24)
                        hour %= 24;
                }
            }
            return new MyTime(hour, minute, second);
        }

        public static int Difference(MyTime mt1, MyTime mt2)
        {
            return mt1.TimeSinceMidnight() - mt2.TimeSinceMidnight();
        }

        public static string WhatLesson(MyTime time)
        {
            string[] lessons = { "1-ша", "2-га", "3-я", "4-а", "5-а", "6-а" };
            int tp = 8 * 3600;
            int tk = tp + 3600 + 20 * 60;
            int tCur = time.TimeSinceMidnight();
            if (tCur < tp)
                return "Пари ще не почалися";
            for (int i = 0; i < lessons.Length; i++)
            {
                if (tp <= tCur && tk > tCur) 
                    return $"{lessons[i]} пара";
                tp += 3600 + 60 * 40;
                if (i == 4)
                    tp-=10*60;
                if (tk <= tCur && tp > tCur)
                    return $"Перерва між {i+1}-ю і {i+2}-ю парами";
                tk = tp + 3600 + 20 * 60;
            }
            return "Пари вже скінчилися";
        }
    }
    class Program
    {
        public static void Main()
        {

            MyTime t = new MyTime(16, 10, 0);
            Console.WriteLine(MyTime.WhatLesson(t));
            /*            MyTime t = new MyTime(23, 59, 59);
                        Console.WriteLine(t);
                        Console.WriteLine(t.AddOneSecond());
                        Console.WriteLine(t.AddOneMinute());
                        Console.WriteLine(t.AddOneHour());
            Console.WriteLine(MyTime.TimeSinceMidnight(221));
            MyTime t1 = new MyTime(13, 23, 12);
            Console.WriteLine(t1.AddSeconds(181));
            MyTime t2 = new MyTime(14, 23, 12);
            Console.WriteLine(MyTime.Difference(t1, t2));*/
            Console.ReadKey();
        }
    }
}