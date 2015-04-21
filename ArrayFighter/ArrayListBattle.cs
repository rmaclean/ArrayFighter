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
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace ConsoleApplication1
{
    internal sealed class ArrayListBattle : IBattle
    {
        private ArrayList _collectionOfItems;
        private ArrayList _alphabetCollection;
        private ArrayList _insertZeroCollection;

        public ArrayListBattle()
        {
            var x = new ArrayList(Program.TestCollectionSize);
            for (int i = 0; i < Program.TestCollectionSize; i++)
            {
                x.Add(i);
            }

            _collectionOfItems = x;

            _alphabetCollection = new ArrayList();
            foreach (var item in Program.AlphabetBase)
            {
                _alphabetCollection.Add(item);
            }

            _insertZeroCollection = _collectionOfItems.Clone() as ArrayList;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public bool KnownSizeInsertSpeed()
        {
            var x = new ArrayList(Program.TestCollectionSize);
            for (int i = 0; i < Program.TestCollectionSize; i++)
            {
                x.Add(i);
            }

            return true;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public bool UnknownSizeInsertSpeed()
        {
            var x = new ArrayList(4);
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
                if ((int)_collectionOfItems[i] != i)
                {
                    throw new Exception();
                }
            }

            return true;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public bool GetItemXMinusOne()
        {
            if ((int)_collectionOfItems[Program.TestCollectionSize - 1] != Program.TestCollectionSize - 1)
            {
                throw new Exception();
            }

            return true;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public bool GetItemXMinusOneThenGetItemXMinusTwo()
        {
            if ((int)_collectionOfItems[Program.TestCollectionSize - 1] != Program.TestCollectionSize - 1)
            {
                throw new Exception();
            }

            if ((int)_collectionOfItems[Program.TestCollectionSize - 2] != Program.TestCollectionSize - 2)
            {
                throw new Exception();
            }

            return true;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public bool FindItemWithKey()
        {
            KeyValuePair<string, int> item = default(KeyValuePair<string, int>);
            foreach (var i in _alphabetCollection)
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
            _insertZeroCollection.Insert(0, Int16.MaxValue);
            return true;
        }
    }
}
