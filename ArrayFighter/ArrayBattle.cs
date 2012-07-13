using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace ConsoleApplication1
{
    sealed class ArrayBattle : IBattle
    {
        private int[] ArrayOfItems;
        private KeyValuePair<string, int>[] AlphabetArray;

        public ArrayBattle()
        {
            var x = new int[Program.TestCollectionSize];
            for (int i = 0; i < Program.TestCollectionSize; i++)
            {
                x[i] = i;
            }

            this.ArrayOfItems = x;

            this.AlphabetArray = Program.AlphabetBase.ToArray();
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public bool KnownSizeInsertSpeed()
        {
            var x = new int[Program.TestCollectionSize];
            for (int i = 0; i < Program.TestCollectionSize; i++)
            {
                x[i] = i;
            }

            return true;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public bool UnknownSizeInsertSpeed()
        {
            return false;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public bool ReadEveryItemForward()
        {
            for (int i = 0; i < Program.TestCollectionSize; i++)
            {
                if (ArrayOfItems[i] != i)
                {
                    throw new Exception();
                }
            }

            return true;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public bool GetItemXMinusOne()
        {
            if (ArrayOfItems[Program.TestCollectionSize - 1] != Program.TestCollectionSize - 1)
            {
                throw new Exception();
            }

            return true;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public bool GetItemXMinusOneThenGetItemXMinusTwo()
        {
            if (ArrayOfItems[Program.TestCollectionSize - 1] != Program.TestCollectionSize - 1)
            {
                throw new Exception();
            }

            if (ArrayOfItems[Program.TestCollectionSize - 2] != Program.TestCollectionSize - 2)
            {
                throw new Exception();
            }

            return true;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public bool FindItemWithKey()
        {
            KeyValuePair<string, int> item = default(KeyValuePair<string, int>);
            for (int i = 0; i < AlphabetArray.Length; i++)
            {
                if (AlphabetArray[i].Key == "R")
                {
                    item = AlphabetArray[i];
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
            return false;
        }
    }
}
