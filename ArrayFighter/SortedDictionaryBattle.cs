using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace ConsoleApplication1
{
    sealed class SortedDictionaryBattle : IBattle
    {
        private SortedDictionary<string, int> AlphabetCollection;

        public SortedDictionaryBattle()
        {
            this.AlphabetCollection = new SortedDictionary<string, int>();
            foreach (var item in Program.AlphabetBase)
            {
                AlphabetCollection.Add(item.Key, item.Value);
            }
        }

        public bool KnownSizeInsertSpeed()
        {
            return false;
        }

        public bool UnknownSizeInsertSpeed()
        {
            return false;
        }

        public bool ReadEveryItemForward()
        {
            return false;
        }

        public bool GetItemXMinusOne()
        {
            return false;
        }

        public bool GetItemXMinusOneThenGetItemXMinusTwo()
        {
            return false;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public bool FindItemWithKey()
        {
            var item = AlphabetCollection["R"];
            if (item != Program.RPosition)
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
