using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace homework4._2
{
    public delegate void Alarm(int h, int m, int s);
    public delegate void Tick(int h, int m, int s);
    public class Clock
    {
        public event Alarm Alarm;
        public event Tick Tick;
        private int hour;
        private int minute;
        private int second;
        private int alarm_hour;
        private int alarm_minute;
        private int alarm_second;
        public void Start()
        {
            this.hour   = DateTime.Now.Hour;
            this.minute = DateTime.Now.Minute;
            this.second = DateTime.Now.Second;
        }
        public void ClockTick()
        {
            this.hour   = DateTime.Now.Hour;
            this.minute = DateTime.Now.Minute;
            this.second = DateTime.Now.Second;
            if (this.hour == this.alarm_hour && this.minute == this.alarm_minute && this.second == this.alarm_second)
            {
                return;
            }
            else
            {
                Tick(this.hour, this.minute, this.second);
            }
        }
        public void ClockAlarm()
        {
            if (this.hour == this.alarm_hour && this.minute == this.alarm_minute && this.second == this.alarm_second) {
                Alarm(this.hour, this.minute, this.second);
            }
        }
        public void SetAlarm(int h, int m, int s)
        {
            this.alarm_hour = h;
            this.alarm_minute = m;
            this.alarm_second = s;
        }
    }
    public class Form
    {
        public Clock clock = new Clock();
        public Form()
        {
            clock.Alarm += new Alarm(Clock_Alarm);
            clock.Tick += new Tick(Clock_Tick);
        }
        void Clock_Alarm(int h, int m, int s)
        {
            Console.WriteLine("Time up！！！");
        }
        void Clock_Tick(int h, int m, int s)
        {
            Console.WriteLine(h + ":H " + m + ":M " + s + ":S");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Form f = new Form();
            f.clock.Start();
            f.clock.SetAlarm(16, 0, 0);
            for (int i = 0; ; i++)
            {
                f.clock.ClockTick();
                Thread.Sleep(1000);
                f.clock.ClockAlarm();
            }
        }
    }
}