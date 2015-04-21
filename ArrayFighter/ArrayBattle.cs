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
    internal sealed class ArrayBattle : IBattle
    {
        private int[] _arrayOfItems;
        private KeyValuePair<string, int>[] _alphabetArray;

        public ArrayBattle()
        {
            var x = new int[Program.TestCollectionSize];
            for (int i = 0; i < Program.TestCollectionSize; i++)
            {
                x[i] = i;
            }

            _arrayOfItems = x;

            _alphabetArray = Program.AlphabetBase.ToArray();
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
                if (_arrayOfItems[i] != i)
                {
                    throw new Exception();
                }
            }

            return true;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public bool GetItemXMinusOne()
        {
            if (_arrayOfItems[Program.TestCollectionSize - 1] != Program.TestCollectionSize - 1)
            {
                throw new Exception();
            }

            return true;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public bool GetItemXMinusOneThenGetItemXMinusTwo()
        {
            if (_arrayOfItems[Program.TestCollectionSize - 1] != Program.TestCollectionSize - 1)
            {
                throw new Exception();
            }

            if (_arrayOfItems[Program.TestCollectionSize - 2] != Program.TestCollectionSize - 2)
            {
                throw new Exception();
            }

            return true;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public bool FindItemWithKey()
        {
            KeyValuePair<string, int> item = default(KeyValuePair<string, int>);
            for (int i = 0; i < _alphabetArray.Length; i++)
            {
                if (_alphabetArray[i].Key == "R")
                {
                    item = _alphabetArray[i];
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
