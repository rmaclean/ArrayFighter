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
    internal sealed class LinkedListBattle : IBattle
    {
        private LinkedList<int> _collectionOfItems;
        private LinkedList<int> _insertZeroCollection;
        private LinkedList<KeyValuePair<string, int>> _alphabetCollection;

        public LinkedListBattle()
        {
            var x = new LinkedList<int>();
            for (int i = 0; i < Program.TestCollectionSize; i++)
            {
                x.AddLast(i);
            }

            _collectionOfItems = x;

            _alphabetCollection = new LinkedList<KeyValuePair<string, int>>();
            foreach (var item in Program.AlphabetBase)
            {
                _alphabetCollection.AddLast(item);
            }
            _insertZeroCollection = new LinkedList<int>(_collectionOfItems);
        }

        public bool KnownSizeInsertSpeed()
        {
            return false;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public bool UnknownSizeInsertSpeed()
        {
            var x = new LinkedList<int>();
            for (int i = 0; i < Program.TestCollectionSize; i++)
            {
                x.AddLast(i);
            }

            return true;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public bool ReadEveryItemForward()
        {
            var x = new LinkedList<int>();
            for (int i = 0; i < Program.TestCollectionSize; i++)
            {
                x.AddLast(i);
            }

            return true;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public bool GetItemXMinusOne()
        {
            var item = _collectionOfItems.First;
            for (int i = 0; i < Program.TestCollectionSize - 1; i++)
            {
                item = item.Next;
            }

            if (item.Value != Program.TestCollectionSize - 1)
            {
                throw new Exception();
            }

            return true;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public bool GetItemXMinusOneThenGetItemXMinusTwo()
        {
            var item = _collectionOfItems.First;
            for (int i = 0; i < Program.TestCollectionSize - 1; i++)
            {
                item = item.Next;
            }

            if (item.Value != Program.TestCollectionSize - 1)
            {
                throw new Exception();
            }

            if (item.Previous.Value != Program.TestCollectionSize - 2)
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
            _insertZeroCollection.AddFirst(Int16.MaxValue);
            return true;
        }
    }
}
