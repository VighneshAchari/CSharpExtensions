//Copyright (c) 2019
//Author: Vighneshwar Achari
//Notes: Contains usesful Contains/HasItem extension methods around string

using System;
using System.Collections.Generic;
using System.Text;

namespace System
{
    /// <summary>
    /// Contains common useful short-hand extension methods around string.
    /// </summary>
    public static class CommonStringExtensions
    {
        /// <summary>
        /// Performs a check for the given string in the source string by ignoring the case.
        /// </summary>
        /// <param name="source">Source string</param>
        /// <param name="value">Value to check</param>
        /// <returns>Boolean value indicating if the souce string contains the given string.</returns>
        public static bool ContainsIgnoreCase(this string source, string value)
        {
            if(source == null)
            {
                throw new ArgumentNullException("source");
            }

            if (value == null)
            {
                return false;
            }

            return source.IndexOf(value, StringComparison.InvariantCultureIgnoreCase) > -1;
        }

        /// <summary>
        /// Compares the source string with another by ignoring the case.
        /// </summary>
        /// <param name="source">Source string</param>
        /// <param name="value">String to compare</param>
        /// <returns>Boolean value indicating if the two strings are same</returns>
        public static bool EqualTo(this string source, string value)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }

            if (value == null)
            {
                return false;
            }

            return source.Equals(value, StringComparison.InvariantCultureIgnoreCase);
        }

        /// <summary>
        /// Converts source string to a StringBuilder instance.
        /// </summary>
        /// <param name="source">Source string</param>
        /// <returns>StringBuilder instance initialized with source string.</returns>
        public static StringBuilder ToStringBuilder(this string source)
        {
            if(source == null)
            {
                throw new ArgumentNullException("source");
            }

            return new StringBuilder(source);
        }
    }
}
