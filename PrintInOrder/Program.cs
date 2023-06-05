using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace PrintInOrder
{
    
    class Program
    {
          
         static void Main(string[] args)
        {
            
        }

    }
    //using autorestevent
    #region using autorestevent
    //public class Foo
    //{
    //    private ManualResetEvent second = new ManualResetEvent(false);
    //    private ManualResetEvent third  = new ManualResetEvent(false);
    //    public Foo()
    //    {

    //    }

    //    public void First(Action printFirst)
    //    {

    //        // printFirst() outputs "first". Do not change or remove this line.
    //        printFirst();
    //        second.Set();
    //    }

    //    public void Second(Action printSecond)
    //    {
    //        second.WaitOne();
    //        // printSecond() outputs "second". Do not change or remove this line.
    //        printSecond();
    //        third.Set();
    //    }

    //    public void Third(Action printThird)
    //    {
    //        third.WaitOne();
    //        // printThird() outputs "third". Do not change or remove this line.
    //        printThird();
    //    }
    //}
    #endregion

    #region 自旋锁

    //public class Foo
    //{
    //    private SpinWait _wait = new SpinWait();
    //    private int value = 1;

    //    public Foo()
    //    {

    //    }

    //    public void First(Action printFirst)
    //    {

    //        // printFirst() outputs "first". Do not change or remove this line.
    //        printFirst();
    //        Thread.VolatileWrite(ref value, 2);
    //    }

    //    public void Second(Action printSecond)
    //    {
    //        while (Thread.VolatileRead(ref value) != 2)
    //        {
    //            _wait.SpinOnce();
    //        }
    //        // printSecond() outputs "second". Do not change or remove this line.
    //        printSecond();
    //        Thread.VolatileWrite(ref value, 3);
    //    }

    //    public void Third(Action printThird)
    //    {
    //        while (Thread.VolatileRead(ref value) != 3)
    //        {
    //            _wait.SpinOnce();
    //        }
    //        // printThird() outputs "third". Do not change or remove this line.
    //        printThird();
    //        Thread.VolatileWrite(ref value, 1);
    //    }
    //}

    #endregion

    public class Foo
    {
        Mutex mutex = new Mutex(false, "foo");
        public int value = 1;
        public Foo()
        {

        }

        public void First(Action printFirst)
        {

            using (Mutex m = Mutex.OpenExisting("foo"))
            {
                m.WaitOne();
                try
                {
                    if (value == 1)
                    {

                    }
                    else
                    {
                        m.ReleaseMutex();
                    }
                }
                finally
                {
                    printFirst();
                    value = 2;
                    m.ReleaseMutex();
                }
            }
            // printFirst() outputs "first". Do not change or remove this line.
            
        }

        public void Second(Action printSecond)
        {
            using (Mutex m1 = Mutex.OpenExisting("foo"))
            {
                m1.WaitOne();
                try
                {
                    if (value == 2)
                    {

                    }
                        
                    else
                    {
                        m1.ReleaseMutex();
                    }
                }
                finally
                {
                    printSecond();
                    value = 3;
                    m1.ReleaseMutex();
                }
            }
            
            // printSecond() outputs "second". Do not change or remove this line.
            
        }

        public void Third(Action printThird)
        {
            using (Mutex m2 = Mutex.OpenExisting("foo"))
            {
                m2.WaitOne();
                try
                {
                    if (value == 3)
                    {

                    }
                    else
                    {
                        m2.ReleaseMutex();
                    }
                }
                finally
                {
                    printThird();

                    value = 1;
                    m2.ReleaseMutex();
                }
            }
            
            // printThird() outputs "third". Do not change or remove this line.
            
        }
    }
}
