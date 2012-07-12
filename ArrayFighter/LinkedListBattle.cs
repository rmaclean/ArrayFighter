using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace ConsoleApplication1
{
    sealed class LinkedListBattle : IBattle
    {
        private LinkedList<int> CollectionOfItems;
        private LinkedList<int> InsertZeroCollection;
        private LinkedList<KeyValuePair<string, int>> AlphabetCollection;

        public LinkedListBattle()
        {
            var x = new LinkedList<int>();
            for (int i = 0; i < Program.TestSize; i++)
            {
                x.AddLast(i);
            }

            this.CollectionOfItems = x;

            this.AlphabetCollection = new LinkedList<KeyValuePair<string, int>>();
            foreach (var item in Program.AlphabetBase)
            {
                AlphabetCollection.AddLast(item);
            }
            this.InsertZeroCollection = new LinkedList<int>(this.CollectionOfItems);
        }

        public bool KnownSizeInsertSpeed()
        {
            return false;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public bool UnknownSizeInsertSpeed()
        {
            var x = new LinkedList<int>();
            for (int i = 0; i < Program.TestSize; i++)
            {
                x.AddLast(i);
            }

            return true;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public bool ReadEveryItemForward()
        {
            var x = new LinkedList<int>();
            for (int i = 0; i < Program.TestSize; i++)
            {
                x.AddLast(i);
            }

            return true;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public bool GetItemXMinusOne()
        {
            var item = CollectionOfItems.First;
            for (int i = 0; i < Program.TestSize - 1; i++)
            {
                item = item.Next;
            }

            if (item.Value != Program.TestSize - 1)
            {
                throw new Exception();
            }

            return true;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public bool GetItemXMinusOneThenGetItemXMinusTwo()
        {
            var item = CollectionOfItems.First;
            for (int i = 0; i < Program.TestSize - 1; i++)
            {
                item = item.Next;
            }

            if (item.Value != Program.TestSize - 1)
            {
                throw new Exception();
            }

            if (item.Previous.Value != Program.TestSize - 2)
            {
                throw new Exception();
            }

            return true;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public bool FindItemWithKey()
        {
            var item = AlphabetCollection.First(_ => _.Key == "R");
            if (item.Value != Program.RPosition)
            {
                throw new Exception();
            }

            return true;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public bool InsertAtZero()
        {
            InsertZeroCollection.AddFirst(Int16.MaxValue);
            return true;
        }
    }
}
