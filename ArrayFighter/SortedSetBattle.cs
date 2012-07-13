using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    sealed class SortedSetBattle : IBattle
    {
        private SortedSet<int> CollectionOfItems;
        private SortedSet<KeyValuePair<string, int>> AlphabetCollection;
        private SortedSet<int> InsertZeroCollection;

        private class KeyValueComparer : IComparer<KeyValuePair<string, int>>
        {
            public int Compare(KeyValuePair<string, int> x, KeyValuePair<string, int> y)
            {
                return x.Key.CompareTo(y.Key);
            }
        }


        public SortedSetBattle()
        {
            var x = new SortedSet<int>();
            for (int i = 0; i < Program.TestCollectionSize; i++)
            {
                x.Add(i);
            }

            this.CollectionOfItems = x;

            this.AlphabetCollection = new SortedSet<KeyValuePair<string, int>>(new KeyValueComparer());
            foreach (var item in Program.AlphabetBase)
            {
                AlphabetCollection.Add(item);
            }

            this.InsertZeroCollection = new SortedSet<int>(CollectionOfItems);
        }


        public bool KnownSizeInsertSpeed()
        {
            return false;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public bool UnknownSizeInsertSpeed()
        {
            var x = new SortedSet<int>();
            for (int i = 0; i < Program.TestCollectionSize; i++)
            {
                x.Add(i);
            }

            return true;
        }

        public bool ReadEveryItemForward()
        {
            return false;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public bool GetItemXMinusOne()
        {
            int counter = 0;
            int result = 0;
            foreach (var item in CollectionOfItems)
            {
                if (counter == Program.TestCollectionSize - 1)
                {
                    result = item;
                    break;
                }

                counter++;
            }

            if (result != Program.TestCollectionSize - 1)
            {
                throw new Exception();
            }

            return true;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public bool GetItemXMinusOneThenGetItemXMinusTwo()
        {
            int counter = 0;
            int result = 0;
            foreach (var item in CollectionOfItems)
            {
                if (counter == Program.TestCollectionSize - 1)
                {
                    result = item;
                    break;
                }

                counter++;
            }

            if (result != Program.TestCollectionSize - 1)
            {
                throw new Exception();
            }

            counter = 0;
            result = 0;
            foreach (var item in CollectionOfItems)
            {
                if (counter == Program.TestCollectionSize - 2)
                {
                    result = item;
                    break;
                }

                counter++;
            }

            if (result != Program.TestCollectionSize - 2)
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

        public bool InsertAtZero()
        {
            return false;
        }
    }
}
