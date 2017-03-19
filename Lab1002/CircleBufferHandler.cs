using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace Lab1002
{
    public class CircleBufferHandler
    {
        public readonly CircleBuffer buffer;
        private readonly SemaphoreSlim binSemaphore = new SemaphoreSlim(1);
        private readonly SemaphoreSlim fullCount, emptyCount;

        public CircleBufferHandler(int bufferSize)
        {
            buffer = new CircleBuffer(bufferSize);
            fullCount = new SemaphoreSlim(0);
            emptyCount = new SemaphoreSlim(bufferSize);
        }

        public void Add(char character)
        {
            emptyCount.Wait();
            binSemaphore.Wait();
            buffer.Add(character);
            binSemaphore.Release();
            fullCount.Release();
        }
        public bool Get(out char item)
        {
            fullCount.Wait();
            binSemaphore.Wait();

            char top = buffer.Top();
            bool result = false;
            
            if (Thread.CurrentThread.Name.Equals("2") && char.IsDigit(top))
            {
                result = true;
                item = buffer.Get();
                binSemaphore.Release();
                emptyCount.Release();//---
            }
            else if (Thread.CurrentThread.Name.Equals("1") && Regex.IsMatch(top.ToString(), "[a-zA-Z]"))
            {
                result = true;
                item = buffer.Get();
                binSemaphore.Release();
                emptyCount.Release();
            }
            else if (Thread.CurrentThread.Name.Equals("3") && !char.IsDigit(top) && !Regex.IsMatch(top.ToString(), "[a-zA-Z]"))
            {
                result = true;
                item = buffer.Get();
                binSemaphore.Release();
                emptyCount.Release();
            }
            else
            {
                result = false;
                item = default(char);
                binSemaphore.Release();
                fullCount.Release();
            }
            return result;
        }

    }
}
