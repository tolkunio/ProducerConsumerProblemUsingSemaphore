using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lab1002
{
    public class Consumer
    {
        CircleBufferHandler buffer;
        string consumerName;
        public Consumer(ref CircleBufferHandler buffer,string consumerName)
        {
            this.buffer = buffer;
            this.consumerName = consumerName;
        }

        public void Run()
        {
            Task.Run(() =>
            {
                Thread.CurrentThread.Name = consumerName;
                while (true)
                {
                    char symbol;
                    if (buffer.Get(out symbol))
                    {
                        Console.WriteLine($"Thread#{consumerName}:{symbol}");
                    }
                }
            });
        }
    }
}
