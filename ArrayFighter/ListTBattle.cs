using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace ConsoleApplication1
{
    sealed class ListTBattle : IBattle
    {
        private List<int> CollectionOfItems;
        private List<KeyValuePair<string, int>> AlphabetCollection;
        private List<int> InsertZeroCollection;

        public ListTBattle()
        {
            var x = new List<int>(Program.TestCollectionSize);
            for (int i = 0; i < Program.TestCollectionSize; i++)
            {
                x.Add(i);
            }

            this.CollectionOfItems = x;

            this.AlphabetCollection = new List<KeyValuePair<string, int>>(Program.AlphabetBase);
            this.InsertZeroCollection = new List<int>(CollectionOfItems);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public bool KnownSizeInsertSpeed()
        {
            var x = new List<int>(Program.TestCollectionSize);
            for (int i = 0; i < Program.TestCollectionSize; i++)
            {
                x.Add(i);
            }

            return true;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public bool UnknownSizeInsertSpeed()
        {
            var x = new List<int>(4);
            for (int i = 0; i < Program.TestCollectionSize; i++)
            {
                x.Add(i);
            }

            return true;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public bool ReadEveryItemForward()
        {            
            for (int i = 0; i < Program.TestCollectionSize; i++)
            {
                if (CollectionOfItems[i] != i)
                {
                    throw new Exception();
                }
            }

            return true;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public bool GetItemXMinusOne()
        {
            if (CollectionOfItems[Program.TestCollectionSize - 1] != Program.TestCollectionSize - 1)
            {
                throw new Exception();
            }

            return true;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public bool GetItemXMinusOneThenGetItemXMinusTwo()
        {
            if (CollectionOfItems[Program.TestCollectionSize - 1] != Program.TestCollectionSize - 1)
            {
                throw new Exception();
            }

            if (CollectionOfItems[Program.TestCollectionSize - 2] != Program.TestCollectionSize - 2)
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
            InsertZeroCollection.Insert(0, Int16.MaxValue);
            return true;
        }
    }
}
