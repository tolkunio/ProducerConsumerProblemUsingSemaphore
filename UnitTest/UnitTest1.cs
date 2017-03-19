using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Lab1002;


namespace UnitTest
{
    [TestClass]
    public class CircleBufferTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            CircleBuffer buffer = new CircleBuffer(2);
            buffer.Add('x');
            buffer.Add('y');
            char x = buffer.Get();
            Assert.AreEqual('x', x);
        }

        [TestMethod]
        public void TestMethod2()
        {
            CircleBuffer buffer = new CircleBuffer(2);
            buffer.Add('x');
            buffer.Add('y');
            buffer.Get();
            char y = buffer.Get();
            Assert.AreEqual('y', y);
        }


        [TestMethod]
        public void TestMethod3()
        {
            CircleBuffer buffer = new CircleBuffer(1);
            buffer.Add('x');
            buffer.Add('y');
            buffer.Get();
            char y = buffer.Get();
            Assert.AreEqual('y', y);
        }

        [TestMethod]
        public void TestMethod4()
        {
            CircleBuffer buffer = new CircleBuffer(3);
            buffer.Add('x');
            buffer.Add('y');
            buffer.Add('z');
            buffer.Add('a');
            buffer.Add('b');
            char tmp = buffer.Get();
            Assert.AreEqual('a', tmp);
        }
    }
}
