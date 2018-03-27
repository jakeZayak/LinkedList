using System;

namespace YTCLinkedList2018SP
{
    class SinglyLinkedList
    {
        //creating custom data type "Node"
        #region Node Data Type

        public class Node
        {
            public int Item { get; set; }
            public Node Next { get; set; }


            //Overloading Node to allow different parameters.
            public Node()
            {
                Item = 0;
                Next = null;
            }

            public Node(int item)
            {
                Item = item;
                Next = null;
            }

            public Node(int item, Node next)
            {
                Item = item;
                Next = next;
            }
            //Overriding system "ToString()" function
            public override string ToString()
            {
                return "item = " + Item.ToString() + " next = " + Next.ToString();
            }
        }
        #endregion

        //Creation of head and tail pointers
        #region Head and Tail Pointers

        private Node head;
        private Node tail;

        protected Node Head
        {
            get
            {
                return head;
            }
        }

        protected Node Tail
        {
            get
            {
                return tail;
            }
        }
        #endregion

        //creation of SinglyLinkedList constructor
        public SinglyLinkedList()
        {
            head = null;
            tail = head;
        }

        #region Methods
        /* Private methods */


        //Inserts at head only
        private bool InsertAtHead(int item)
        {
            try
            {
                Node insert = new Node(item, head);

                if (head == null && tail == null)
                {
                    tail = insert;
                }

                head = insert;
                insert = null;
            }
            catch (Exception e)
            {
                Console.WriteLine("Too many things have been ruined in InsertAtHead...");
                Console.WriteLine(e.Message);
                return false;
            }

            return true;
        }

        //Inserts elsewhere and changes pointers
        private bool InsertAfterHead(int item, Node prev)
        {
            try
            {
                Node insert = new Node(item, prev.Next);

                if (prev.Next == null)
                {
                    tail = insert;
                }

                prev.Next = insert;
                insert = null;
            }
            catch (Exception e)
            {
                Console.WriteLine("Too many things have been ruined in InsertAfterHead...");
                Console.WriteLine(e.Message);
                return false;
            }

            return true;
        }

        //Locate nodes based on provided int
        public Node Find(int item)
        {
            Node curr = head;
            Node prev = null;

            try
            {
                if (head.Item == item)
                {
                    return head;
                }
                else
                {
                    while (curr.Item != item && curr.Next != null)
                    {
                        prev = curr;
                        curr = curr.Next;
                    }

                    if (curr.Item == item)
                    {
                        return prev;
                    }
                    else
                    {
                        return tail;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Too many things have been ruined in Find...");
                Console.WriteLine(e.Message);
                return null;
            }
            finally
            {
                prev = null;
                curr = null;
            }
        }

        //Removes first node (@ head)
        private bool RemoveAtHead()
        {
            try
            {
                if (head == null)
                {
                    return true;
                }
                else
                {
                    Node deleteItem = head;
                    head = deleteItem.Next;

                    if (head == null && tail != null)
                    {
                        tail = head;
                    }

                    deleteItem = null;
                    return true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Too many things have been ruined in RemoveAtHead...");
                Console.WriteLine(e.Message);
                return false;
            }
        }

        //Removes anywhere else
        private bool RemoveAfterHead(Node prev)
        {
            try
            {
                if (prev == null || prev == tail)
                {
                    return true;
                }
                else
                {
                    Node deleteItem = prev.Next;
                    prev.Next = deleteItem.Next;
                    deleteItem.Next = null;

                    if (tail == deleteItem)
                    {
                        tail = prev;
                    }

                    deleteItem = null;
                    prev = null;
                    return true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Too many things have been ruined in RemoveAfterHead...");
                Console.WriteLine(e.Message);
                return false;
            }
        }

        //Determines which method should be executed to Insert
        public virtual bool Insert(int item, Node prev)
        {
            try
            {
                if (prev == null)
                {
                    return InsertAtHead(item);
                }
                else
                {
                    return InsertAfterHead(item, prev);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Too many things have been ruined in Insert...");
                Console.WriteLine(e.Message);
                return false;
            }
        }

        //Determines which method should be executed to Remove
        public virtual bool Remove(int item)
        {
            try
            {
                Node prev = Find(item);

                if (prev == head)
                {
                    if (head.Item == item)
                    {
                        return RemoveAtHead();
                    }
                    else
                    {
                        if (prev != tail)
                        {
                            return RemoveAfterHead(prev);
                        }
                        else
                        {
                            return true;
                        }
                    }
                }
                else if (prev != null)
                {
                    return RemoveAfterHead(prev);
                }
                else
                {
                    return true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Too many things have been ruined in Remove...");
                Console.WriteLine(e.Message);
                return false;
            }
        }

        //Overrided to string method
        public override string ToString()
        {
            Node curr = head;
            string list = "";

            try
            {
                if (head == null)
                {
                    return "";
                }
                else
                {
                    while (curr.Next != null)
                    {
                        list = list + curr.Item.ToString() + "->";
                        curr = curr.Next;
                    }

                    return list + curr.Item.ToString();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Too many things have been ruined in ToString...");
                Console.WriteLine(e.Message);
                return "";
            }
        }
        #endregion
    }
}
