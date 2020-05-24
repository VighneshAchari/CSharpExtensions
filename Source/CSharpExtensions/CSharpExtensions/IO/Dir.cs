//Copyright (c) 2020
//Author: Vighneshwar Achari
//Notes: Contains simplified utility methods for directory operations

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace System.IO
{
    /// <summary>
    /// Contains simplified utility methods for directory operations
    /// </summary>
    public class Dir
    {
        /// <summary>
        /// Creates the directry specified by path if not found.
        /// </summary>
        /// <param name="path">Path of the directory to create</param>
        public static void Create(string path)
        {
            if(!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }

        /// <summary>
        /// Creates the directory specified by path if condition satisfies
        /// </summary>
        /// <param name="path">Path of the directory to create</param>
        /// <param name="condition">Condition to check</param>
        public static void CreateIf(string path, Func<bool> condition)
        {
            if(condition == null)
            {
                throw new ArgumentNullException("condition");
            }

            if(condition.Invoke())
            {
                Create(path);
            }
        }

        /// <summary>
        /// Renames a directory
        /// </summary>
        /// <param name="path">Path of the directory</param>
        /// <param name="newName">New name of the directory</param>
        public static void Rename(string path, string newName)
        {
            if(string.IsNullOrWhiteSpace(newName))
            {
                throw new ArgumentException("Parameter cannot be null or empty.", "newName");
            }

            var dir = new DirectoryInfo(path);

            if (dir != null)
            {
                Directory.Move(dir.FullName, Path.Combine(dir.Parent.FullName, newName));
            }
        }

        /// <summary>
        /// Deletes the directory if the condition specified satisfies.
        /// </summary>
        /// <param name="path">Path of the directory</param>
        /// <param name="condition">Condition to check</param>
        public static void DeleteIf(string path, Func<bool> condition)
        {
            if(condition == null)
            {
                throw new ArgumentNullException("condition");
            }

            var isSatisfied = condition.Invoke();

            if(isSatisfied)
            {
                Directory.Delete(path, true);
            }
        }
    }
}
