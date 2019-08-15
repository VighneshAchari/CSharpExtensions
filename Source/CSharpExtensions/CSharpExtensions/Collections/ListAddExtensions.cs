//Copyright (c) 2019
//Author: Vighneshwar Achari
//Notes: Contains usesful insertion extension methods around List<T>

using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Using the original system namespace so that extension methods appear without referencing new namespace 
/// </summary>
namespace System.Collections.Generic
{
    /// <summary>
    /// Contains useful extension insertion methods around <![CDATA[List<T>]]>
    /// </summary>
    public static class ListAddExtensions
    {
        /// <summary>
        /// Adds item to the list if the condition specified by checker is satisfied.
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="list">Source List</param>
        /// <param name="item">Item to add</param>
        /// <param name="condition">Function to check condition</param>
        public static void AddIf<T>(this List<T> list, T item, Predicate<T> condition)
        {
            EnsureAddArgumentsNotNull(list, condition);

            if (item == null)
            {
                throw new ArgumentNullException("item");
            }

            if (condition.Invoke(item))
            {
                list.Add(item);
            }
        }

        /// <summary>
        /// Adds a range of items to the list filtered by condition specified by checker is satisfied.
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="list">Source List</param>
        /// <param name="items">Items to add</param>
        /// <param name="condition">Function to check condition</param>
        public static void AddRangeIf<T>(this List<T> list, IEnumerable<T> items, Predicate<T> condition)
        {
            EnsureAddArgumentsNotNull(list, condition);

            if (items == null)
            {
                throw new ArgumentNullException("items");
            }

            foreach(var item in items)
            {
                list.AddIf(item, condition);
            }
        }

        /// <summary>
        /// Ensures the common arguments for list add methods are not null
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="list">List on which null check should be performed</param>
        /// <param name="condition">Function on which null check should be performed</param>
        private static void EnsureAddArgumentsNotNull<T>(List<T> list, Predicate<T> condition)
        {
            if (list == null)
            {
                throw new ArgumentNullException("source list");
            }

            if (condition == null)
            {
                throw new ArgumentNullException("condition function");
            }
        }
    }
}
