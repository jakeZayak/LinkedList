using System;

namespace YTCLinkedList2018SP
{
    class OrderedList : SinglyLinkedList
    {
        public OrderedList() : base()
        {
        }

        //Overrided Insert Method to place insert nodes in ascending order
        public bool Insert(int Item)
        {
            try
            {
                Node prev = null;
                Node curr = Head;

                if (curr != null)
                {
                    while (curr.Next != null && Item > curr.Item)
                    {
                        prev = curr;
                        curr = curr.Next;
                    }

                    if (Item > curr.Item)
                    {
                        return base.Insert(Item, curr);
                    }
                    else
                    {
                        return base.Insert(Item, prev);
                    }
                }
                else
                {
                    return base.Insert(Item, null);
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("Too many things have been ruined in Insert...");
                Console.WriteLine(e.Message);
                return false;
            }
        }

    }
}
