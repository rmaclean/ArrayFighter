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
using System.Runtime.CompilerServices;

namespace ConsoleApplication1
{
    internal sealed class SortedDictionaryBattle : IBattle
    {
        private SortedDictionary<string, int> _alphabetCollection;

        public SortedDictionaryBattle()
        {
            _alphabetCollection = new SortedDictionary<string, int>();
            foreach (var item in Program.AlphabetBase)
            {
                _alphabetCollection.Add(item.Key, item.Value);
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
            var item = _alphabetCollection["R"];
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
