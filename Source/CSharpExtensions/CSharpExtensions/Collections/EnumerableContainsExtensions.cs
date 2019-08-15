//Copyright (c) 2019
//Author: Vighneshwar Achari
//Notes: Contains usesful Contains/HasItem extension methods around IEnumerable<string>

using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Text;

/// <summary>
/// Using the original system namespace so that extension methods appear without referencing new namespace 
/// </summary>
namespace System.Collections.Generic
{
    public static class EnumerableContainsExtensions
    {
        /// <summary>
        /// Performs a case insensitive check for the given text in the collection.
        /// </summary>
        /// <param name="collection">Source collection (any IEnumrable<![CDATA[<string>]]>)</param>
        /// <param name="value">String to check</param>
        /// <returns>Boolean indicating the given string was present in the collection or not</returns>
        public static bool ContainsIgnoreCase(this IEnumerable<string> collection, string value)
        {
            if(collection == null)
            {
                throw new ArgumentNullException("collection");
            }

            return collection.Contains(value, StringComparer.InvariantCultureIgnoreCase);
        }
    }
}
