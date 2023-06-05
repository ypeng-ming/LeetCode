using System;
using System.Threading;

namespace PrintZeroOddEven
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

    #region description
    //public class ZeroEvenOdd
    //{
    //    private int n;

    //    public ZeroEvenOdd(int n)
    //    {
    //        this.n = n;
    //    }

    //    // printNumber(x) outputs "x", where x is an integer.
    //    public void Zero(Action<int> printNumber)
    //    {

    //    }

    //    public void Even(Action<int> printNumber)
    //    {

    //    }

    //    public void Odd(Action<int> printNumber)
    //    {

    //    }
    //}
    #endregion

    public class ZeroEvenOdd
    {
        private int n;
        ManualResetEvent zero = new ManualResetEvent(true);
        private ManualResetEvent odd = new ManualResetEvent(false);
        ManualResetEvent even = new ManualResetEvent(false);
        public ZeroEvenOdd(int n)
        {
            this.n = n;
        }

        // printNumber(x) outputs "x", where x is an integer.
        public void Zero(Action<int> printNumber)
        {
            for (int i = 0; i < n; i++)
            {
                zero.WaitOne();
                printNumber(0);
                if (i%2==1)
                {
                    odd.Set();
                }
                else
                {
                    even.Set();
                }
            }
        }

        public void Even(Action<int> printNumber)
        {
            for (int i = 2; i < n; i+=2)
            {
                even.WaitOne();
                printNumber(i);
                zero.Set();
                even.Reset();
            }

        }

        public void Odd(Action<int> printNumber)
        {
            for (int i = 1; i < n; i+=2)
            {
                odd.WaitOne();
                printNumber(i);
                zero.Set();
                odd.Reset();
            }
        }
    }
}
