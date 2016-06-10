﻿using System;
using System.Globalization;
using System.IO;

namespace Kudu.Core
{
    public static class StringExtensions
    {
        public static string FormatInvariant(this string format, params object[] args)
        {
            return String.Format(CultureInfo.InvariantCulture, format, args);
        }

        public static string FormatCurrentCulture(this string format, params object[] args)
        {
            return String.Format(CultureInfo.CurrentCulture, format, args);
        }

        /// <summary>
        /// Make string PII safe.
        /// Use this method for sensitive personal information to hides its content.
        /// </summary>
        public static string Fuzz(this string str)
        {
            return String.IsNullOrEmpty(str) ? str : str.GetHashCode().ToString();
        }

        public static string EscapeHashCharacter(this string str)
        {
            return str.Replace("#", Uri.EscapeDataString("#"));
        }

        // Returns a string you can safely use as valid Windows or Linux file name.
        // Does not check for reserved words.
        public static string ToSafeFileName(this string str)
        {
            foreach (char c in Path.GetInvalidFileNameChars())
            {
                str = str.Trim()
                         .Replace(c, '-')
                         .Replace(' ', '-');
            }
            return str;
        }
        
        public static string Truncate(this string str, int maxLength)
        {
            if (string.IsNullOrEmpty(str))
            {
                return str;
            }
            return str.Length <= maxLength ? str : str.Substring(0, maxLength);
        }
    }
}