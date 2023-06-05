using System;
using System.Threading;

namespace PrintFooBar
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

    #region manuelresetevent
    //public class FooBar
    //{
    //    private int n;
    //    private ManualResetEvent manualResetEvent = new ManualResetEvent(true);
    //    private ManualResetEvent manualResetEvent1 = new ManualResetEvent(false);
    //    public FooBar(int n)
    //    {
    //        this.n = n;
    //    }

    //    public void Foo(Action printFoo)
    //    {

    //        for (int i = 0; i < n; i++)
    //        {

    //            // printFoo() outputs "foo". Do not change or remove this line.if (n%2==0)
    //            manualResetEvent.WaitOne();
    //            printFoo();
    //            manualResetEvent.Reset();
    //            manualResetEvent1.Set();



    //        }
    //    }

    //    public void Bar(Action printBar)
    //    {

    //        for (int i = 0; i < n; i++)
    //        {

    //            // printBar() outputs "bar". Do not change or remove this line.
    //            //if (n % 2 == 1)
    //            {
    //                manualResetEvent1.WaitOne();
    //                printBar();
    //                manualResetEvent1.Reset();
    //                manualResetEvent.Set();
    //            }
    //        }
    //    }
    //}

    //public class FooBar
    //{
    //    private int n;

    //    public FooBar(int n)
    //    {
    //        this.n = n;
    //    }

    //    public void Foo(Action printFoo)
    //    {

    //        for (int i = 0; i < n; i++)
    //        {

    //            // printFoo() outputs "foo". Do not change or remove this line.
    //            printFoo();
    //        }
    //    }

    //    public void Bar(Action printBar)
    //    {

    //        for (int i = 0; i < n; i++)
    //        {

    //            // printBar() outputs "bar". Do not change or remove this line.
    //            printBar();
    //        }
    //    }
    //}
    #endregion

    #region semaphore

    //public class FooBar
    //{
    //    private int n;
    //    Semaphore foo = new Semaphore(1, 2);
    //    Semaphore bar = new Semaphore(1, 2);
    //    public FooBar(int n)
    //    {
    //        this.n = n;
    //    }

    //    public void Foo(Action printFoo)
    //    {

    //        for (int i = 0; i < n; i++)
    //        {

    //            printFoo() outputs "foo".Do not change or remove this line.
    //          foo.WaitOne();
    //            printFoo();
    //            bar.Release();
    //        }
    //    }

    //    public void Bar(Action printBar)
    //    {

    //        for (int i = 0; i < n; i++)
    //        {

    //            printBar() outputs "bar".Do not change or remove this line.
    //          bar.WaitOne();
    //            printBar();
    //            foo.Release();
    //        }
    //    }
    //}

    #endregion


    public class FooBar
    {
        private int n;
         

        public FooBar(int n)
        {
            this.n = n;
        }

        public void Foo(Action printFoo)
        {

            for (int i = 0; i < n; i++)
            {

                // printFoo() outputs "foo". Do not change or remove this line.
                printFoo();
            }
        }

        public void Bar(Action printBar)
        {

            for (int i = 0; i < n; i++)
            {

                // printBar() outputs "bar". Do not change or remove this line.
                printBar();
            }
        }
    }
}
