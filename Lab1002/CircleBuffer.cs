using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1002
{
    public class CircleBuffer
    {
        char[] symbols;
        int begin = -1, end = -1,current = 0;
        public CircleBuffer(int bufferSize)
        {
            symbols = new char[bufferSize];
        }
        public void Add(char character)
        {
            if (++end >= symbols.Length)
            {
                end = 0;
            }
            current = end;
            symbols[current] = character;
        }

        public char Top()
        {
            return symbols[current];
        }


        public char Get()
        {
            if (++begin >= symbols.Length)
            {
                begin = 0;
            }
            current = begin;
            return symbols[current];
        }
    }
}
