﻿using System;

namespace Evodia.Core.ExtensionMethods
{
    public static class IntExtentions
    {
        private static readonly string[] SizeSuffixes = {"bytes", "KB", "MB", "GB", "TB", "PB", "EB", "ZB", "YB"};

        public static string ToFileSize(this int value)
        {
            if (value < 0)
            {
                return "-" + ToFileSize(-value);
            }
            if (value == 0)
            {
                return "0.0 bytes";
            }

            var mag = (int) Math.Log(value, 1024);
            var adjustedSize = (decimal) value/(1L << (mag*10));

            return string.Format("{0:n1} {1}", adjustedSize, SizeSuffixes[mag]);
        }
    }
}
