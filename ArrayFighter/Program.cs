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
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;

namespace ConsoleApplication1
{
    internal class Program
    {
        public const int TestCollectionSize = 1000000;
        public const int TestIerationSize = 1000;
        public static IEnumerable<KeyValuePair<string, int>> AlphabetBase { get; set; }
        public static int RPosition { get; set; }

        private static void GenerateData()
        {
            var items = new List<KeyValuePair<string, int>>();
            var rand = new Random();
            for (int i = 0; i < 26; i++)
            {
                var key = string.Empty;
                var success = false;
                while (!success)
                {
                    key = Convert.ToChar(rand.Next(0, 26) + 65).ToString();
                    success = !items.Any(_ => _.Key == key);
                }

                if (key == "R")
                {
                    RPosition = i;
                }

                items.Add(new KeyValuePair<string, int>(key, i));
            }

            AlphabetBase = items.AsEnumerable();
        }

        private enum Fighter
        {
            Array,
            ArrayList,
            ListT,
            LinkedListT,
            DictionaryTK,
            SortedSetT,
            SortedDictionary,
            Quit
        }

        private static Fighter SelectFighter()
        {
            Console.Clear();
            Console.WriteLine("Array versus the world");
            Console.WriteLine("Pick a fighter:");
            Console.WriteLine("A) Array");
            Console.WriteLine("B) ArrayList");
            Console.WriteLine("C) List<T>");
            Console.WriteLine("D) LinkedList<T>");
            Console.WriteLine("E) Dictionary<T,K>");
            Console.WriteLine("F) SortedSet<T>");
            Console.WriteLine("G) SortedDictionary<T,K>");
            Console.WriteLine("");
            Console.WriteLine("Any other key to quit");
            var key = Console.ReadKey(true);
            switch (key.KeyChar)
            {
                case 'a':
                case 'A':
                    {
                        return Fighter.Array;
                    }
                case 'b':
                case 'B':
                    {
                        return Fighter.ArrayList;
                    }
                case 'c':
                case 'C':
                    {
                        return Fighter.ListT;
                    }
                case 'd':
                case 'D':
                    {
                        return Fighter.LinkedListT;
                    }
                case 'e':
                case 'E':
                    {
                        return Fighter.DictionaryTK;
                    }
                case 'f':
                case 'F':
                    {
                        return Fighter.SortedSetT;
                    }
                case 'g':
                case 'G':
                    {
                        return Fighter.SortedDictionary;
                    }
            }

            return Fighter.Quit;
        }

        private static TimeSpan? Test(Func<bool> test)
        {
            GC.Collect(2, GCCollectionMode.Forced, true);
            var sw = Stopwatch.StartNew();
            var result = test();
            sw.Stop();

            if (result)
            {
                return sw.Elapsed;
            }

            return null;
        }

        [STAThread]
        private static void Main(string[] args)
        {
            if (Debugger.IsAttached)
            {
                Console.WriteLine("Debugger is attached - stopping execution.");
                return;
            }

            GenerateData();
            Fighter fighter;
            while ((fighter = SelectFighter()) != Fighter.Quit)
            {
                IBattle battle = null;
                switch (fighter)
                {
                    case Fighter.Array:
                        {
                            battle = new ArrayBattle();
                            break;
                        }
                    case Fighter.ArrayList:
                        {
                            battle = new ArrayListBattle();
                            break;
                        }
                    case Fighter.ListT:
                        {
                            battle = new ListTBattle();
                            break;
                        }
                    case Fighter.LinkedListT:
                        {
                            battle = new LinkedListBattle();
                            break;
                        }
                    case Fighter.DictionaryTK:
                        {
                            battle = new DictionaryBattle();
                            break;
                        }
                    case Fighter.SortedSetT:
                        {
                            battle = new SortedSetBattle();
                            break;
                        }
                    case Fighter.SortedDictionary:
                        {
                            battle = new SortedDictionaryBattle();
                            break;
                        }
                }

                Console.WriteLine("Testing with: {0}", battle.GetType().Name);

                var knownSizeInsertSpeed = new List<TimeSpan?>(Program.TestCollectionSize);
                var unknownSizeInsertSpeed = new List<TimeSpan?>(Program.TestCollectionSize);
                var readEveryItemForward = new List<TimeSpan?>(Program.TestCollectionSize);
                var getItem100 = new List<TimeSpan?>(Program.TestCollectionSize);
                var getItem100ThenGetItem99 = new List<TimeSpan?>(Program.TestCollectionSize);
                var findItemWithKey = new List<TimeSpan?>(Program.TestCollectionSize);
                var insertAtZero = new List<TimeSpan?>(Program.TestCollectionSize);

                for (int i = 0; i < Program.TestIerationSize; i++)
                {
                    knownSizeInsertSpeed.Add(Test(battle.KnownSizeInsertSpeed));
                    unknownSizeInsertSpeed.Add(Test(battle.UnknownSizeInsertSpeed));
                    readEveryItemForward.Add(Test(battle.ReadEveryItemForward));
                    getItem100.Add(Test(battle.GetItemXMinusOne));
                    getItem100ThenGetItem99.Add(Test(battle.GetItemXMinusOneThenGetItemXMinusTwo));
                    findItemWithKey.Add(Test(battle.FindItemWithKey));
                    insertAtZero.Add(Test(battle.InsertAtZero));
                }

                var knownSizeResult = CalcResult(knownSizeInsertSpeed);
                var unknownSizeResult = CalcResult(unknownSizeInsertSpeed);
                var readForwardResult = CalcResult(readEveryItemForward);
                var getItem100Result = CalcResult(getItem100);
                var get100Then99Result = CalcResult(getItem100ThenGetItem99);
                var findWithKeyResult = CalcResult(findItemWithKey);
                var insertAtZeroResult = CalcResult(insertAtZero);

                var forClipboard = string.Format(@"{0}
{1}
{2}
{3}
{4}
{5}
{6}", knownSizeResult, unknownSizeResult, readForwardResult, getItem100Result, get100Then99Result, findWithKeyResult, insertAtZeroResult);

                Clipboard.SetText(forClipboard);

                Console.WriteLine("Results");
                Console.WriteLine("Known Size Insert Speed: {0}", knownSizeResult);
                Console.WriteLine("Unknown Size Insert Speed: {0}", unknownSizeResult);
                Console.WriteLine("Read Every Item Forward: {0}", readForwardResult);
                Console.WriteLine("Get Item 100: {0}", getItem100Result);
                Console.WriteLine("Get Item 100 Then Get Item99: {0}", get100Then99Result);
                Console.WriteLine("Find Item With Key: {0}", findWithKeyResult);
                Console.WriteLine("Insert At Zero: {0}", insertAtZeroResult);
                Console.WriteLine("");
                Console.WriteLine("Press enter to get a new fighter");
                Console.ReadLine();
            }
        }

        private static string CalcResult(List<TimeSpan?> values)
        {
            if (!values[0].HasValue)
            {
                return "Failed";
            }
            else
            {
                return string.Format("{0}ms", values.Average(_ => Convert.ToDecimal(_.Value.TotalMilliseconds)));
            }
        }
    }

    internal interface IBattle
    {
        /// <summary>
        /// Create a collection of size Program.TestSize and insert Program.TestSize ints into it
        /// </summary>
        /// <returns></returns>
        bool KnownSizeInsertSpeed();
        /// <summary>
        /// Create a collection of size 4 and insert Program.TestSize ints into it - grow or fails as needed
        /// </summary>
        /// <returns></returns>
        bool UnknownSizeInsertSpeed();
        /// <summary>
        /// Create a collection of size Program.TestSize and insert Program.TestSize ints into it. Read and validate each item.
        /// </summary>
        /// <returns></returns>
        bool ReadEveryItemForward();
        /// <summary>
        /// Create a collection of size Program.TestSize and insert Program.TestSize ints into it. Read and validate item 100
        /// </summary>
        /// <returns></returns>
        bool GetItemXMinusOne();
        /// <summary>
        /// Create a collection of size Program.TestSize and insert Program.TestSize ints into it. Read and validate item 100, then read and validate item 99
        /// </summary>
        /// <returns></returns>
        bool GetItemXMinusOneThenGetItemXMinusTwo();
        /// <summary>
        /// Create a collection of size 26 and insert 26 ints into it. Each int needs a key which corresponds to a letter of the alphabet as a string. Find item with key R
        /// </summary>
        /// <returns></returns>
        bool FindItemWithKey();
        /// <summary>
        /// Insert an item at position zero
        /// </summary>
        /// <returns></returns>
        bool InsertAtZero();
    }
}
