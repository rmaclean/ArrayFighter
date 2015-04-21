// Array Fighter 
// 
// 	Authors:	Robert MacLean <robert@sadev.co.za>
// 
// 	This program is free software; you can redistribute it and/or
// 	modify it under the terms of the Microsoft Public License 
//     (MS-PL).
// 
// 10:21 AM 2015-04-20 SAST Robert MacLean
//                          Playing around with Code Formatter
//  

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace ConsoleApplication1
{
    internal sealed class ListTBattle : IBattle
    {
        private List<int> _collectionOfItems;
        private List<KeyValuePair<string, int>> _alphabetCollection;
        private List<int> _insertZeroCollection;

        public ListTBattle()
        {
            var x = new List<int>(Program.TestCollectionSize);
            for (int i = 0; i < Program.TestCollectionSize; i++)
            {
                x.Add(i);
            }

            _collectionOfItems = x;

            _alphabetCollection = new List<KeyValuePair<string, int>>(Program.AlphabetBase);
            _insertZeroCollection = new List<int>(_collectionOfItems);
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
                if (_collectionOfItems[i] != i)
                {
                    throw new Exception();
                }
            }

            return true;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public bool GetItemXMinusOne()
        {
            if (_collectionOfItems[Program.TestCollectionSize - 1] != Program.TestCollectionSize - 1)
            {
                throw new Exception();
            }

            return true;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public bool GetItemXMinusOneThenGetItemXMinusTwo()
        {
            if (_collectionOfItems[Program.TestCollectionSize - 1] != Program.TestCollectionSize - 1)
            {
                throw new Exception();
            }

            if (_collectionOfItems[Program.TestCollectionSize - 2] != Program.TestCollectionSize - 2)
            {
                throw new Exception();
            }

            return true;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public bool FindItemWithKey()
        {
            var item = _alphabetCollection.First(_ => _.Key == "R");
            if (item.Value != Program.RPosition)
            {
                throw new Exception();
            }

            return true;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public bool InsertAtZero()
        {
            _insertZeroCollection.Insert(0, Int16.MaxValue);
            return true;
        }
    }
}
