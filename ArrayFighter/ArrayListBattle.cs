using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace ConsoleApplication1
{
    sealed class ArrayListBattle : IBattle
    {
        private ArrayList CollectionOfItems;
        private ArrayList AlphabetCollection;
        private ArrayList InsertZeroCollection;

        public ArrayListBattle()
        {
            var x = new ArrayList(Program.TestSize);
            for (int i = 0; i < Program.TestSize; i++)
            {
                x.Add(i);
            }

            this.CollectionOfItems = x;

            this.AlphabetCollection = new ArrayList();
            foreach (var item in Program.AlphabetBase)
            {
                AlphabetCollection.Add(item);
            }

            this.InsertZeroCollection = this.CollectionOfItems.Clone() as ArrayList;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public bool KnownSizeInsertSpeed()
        {
            var x = new ArrayList(Program.TestSize);
            for (int i = 0; i < Program.TestSize; i++)
            {
                x.Add(i);
            }

            return true;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public bool UnknownSizeInsertSpeed()
        {
            var x = new ArrayList(4);
            for (int i = 0; i < Program.TestSize; i++)
            {
                x.Add(i);
            }

            return true;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public bool ReadEveryItemForward()
        {
            for (int i = 0; i < Program.TestSize; i++)
            {
                if ((int)CollectionOfItems[i] != i)
                {
                    throw new Exception();
                }
            }

            return true;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public bool GetItemXMinusOne()
        {
            if ((int)CollectionOfItems[Program.TestSize - 1] != Program.TestSize - 1)
            {
                throw new Exception();
            }

            return true;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public bool GetItemXMinusOneThenGetItemXMinusTwo()
        {
            if ((int)CollectionOfItems[Program.TestSize - 1] != Program.TestSize - 1)
            {
                throw new Exception();
            }

            if ((int)CollectionOfItems[Program.TestSize - 2] != Program.TestSize - 2)
            {
                throw new Exception();
            }

            return true;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public bool FindItemWithKey()
        {
            KeyValuePair<string, int> item = default(KeyValuePair<string, int>);
            foreach (var i in AlphabetCollection)
            {
                var ii = (KeyValuePair<string, int>)i;
                if (ii.Key == "R")
                {
                    item = ii;
                    break;
                }
            }

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
