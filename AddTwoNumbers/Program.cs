using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace AddTwoNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            ListNode l1 = new ListNode(3, new ListNode(4,new ListNode(2)));
            ListNode l2 = new ListNode(5, new ListNode(6, new ListNode(4)));

            ListNode l3 = new ListNode(9, new ListNode(9, new ListNode(9,
                new ListNode(9,new ListNode(9,new ListNode(9, new ListNode(9)))))));
            ListNode l4 = new ListNode(9, new ListNode(9, new ListNode(9,
                new ListNode(9))));

            ListNode testNode =  AddTwoNumbers(l3, l4);
        }

        private static ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            
            ListNode headNode = new ListNode(0);
            ListNode tailNode = headNode;
            int carry = 0;
           // int sum = 0;
           while (l1!=null||l2!=null||carry!=0)
           {
               int sum = (l1 == null ? 0 : l1.val) + (l2 == null ? 0 : l2.val) + carry;

                //改变tailnode.next是改变对象本身，所以两个都会改变
                tailNode.next = new ListNode(sum%10);
                //但是改变lastnode只是改变了引用，所以真正的tailnode还是没有改变
                tailNode = tailNode.next;
               carry = sum / 10;
                //  l1 = l1.next == null ? null : l1.next;
                //l2 = l2.next == null ? null : l2.next;
                if (l1 != null)
                {
                    l1 = l1.next;
                }
                if (l2 != null)
               {
                   l2 = l2.next;
               }
            }

            //if (carry == 1)
            //{
            //    tailNode.next = new ListNode(carry);
            //}

            //Console.WriteLine("headNode: {0}", GetMemory(headNode));
            //Console.WriteLine("tailNode: {0}", GetMemory(tailNode));
            //Console.WriteLine(ReferenceEquals(headNode,tailNode));

            return headNode.next;
        }

        public static string GetMemory(object o)
        {
            GCHandle h = GCHandle.Alloc(0, GCHandleType.Pinned);
            IntPtr addr = h.AddrOfPinnedObject();
            return addr.ToString("X");
        }

        private static ListNode AddTwoNumbers1(ListNode l1, ListNode l2)
        {
            ListNode headNode = null, tailNode = null;
            int carry = 0;
            while (l1!=null||l2!=null)
            {
                int sum = (l1 == null ? 0 : l1.val) + (l2 == null ? 0 : l2.val) + carry;

                if (headNode==null)
                {
                    headNode = tailNode = new ListNode(sum % 10);
                }
                else
                {
                    tailNode.next = new ListNode(sum%10);
                    tailNode = tailNode.next;
                }

                carry = sum / 10;

                l1 = l1.next == null ? null : l1.next;
                if (l2 != null)
                {
                    l2 = l2.next;
                }
            }

            if (carry>0)
            {
                tailNode.next = new ListNode(carry);
            }

             return headNode;
        }

        public static ListNode AddTwoNumbers3(ListNode l1, ListNode l2)
        {
            ListNode headNode = null, tailNode = null;
            int carry = 0;
            // int sum = 0;
            while (l1 != null || l2 != null)
            {
                int n1 = l1 == null ? 0 : l1.val;
                int n2 = l2 == null ? 0 : l2.val;

                int sum = n1 + n2 + carry;

                if (headNode == null)
                {
                    headNode = tailNode = new ListNode(sum % 10);
                }
                else
                {
                    tailNode.next = new ListNode(sum % 10);
                    tailNode = tailNode.next;
                }

                if (sum >= 10)
                {
                    carry = 1;

                }
                else
                {
                    carry = 0;
                }
                //carry = sum / 10;


                //移动数据
                if (l1 != null)
                {
                    l1 = l1.next;
                }

                if (l2 != null)
                {
                    l2 = l2.next;
                }

                if (carry > 0)
                {
                    tailNode.next = new ListNode(carry);
                }
            }



             return headNode;
        }
    }

    public class ListNode
    {
        public int val;
        public ListNode next;

        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }
}
