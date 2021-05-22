// Copyright 2021 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using JetBrains.Annotations;

namespace Nuke.Common
{
    public static class Logger
    {
        [StringFormatMethod("format")]
        public static void Info(string format, params object[] args) 
            => Info(string.Format(format, args));
        
        public static void Info(object value) 
            => Info(value?.ToString());
        
        public static void Info(string text = null)
        {
            // if (LogLevel <= LogLevel.Normal)
            //     OutputSink.WriteInformation(text ?? string.Empty);
        }
        
        [StringFormatMethod("format")]
        public static void Warn(string format, params object[] args) 
            => Warn(string.Format(format, args));

        public static void Warn(object value)
            => Warn(value?.ToString());

        public static void Warn(string text = null)
        {
            // if (LogLevel <= LogLevel.Warning)
            //     OutputSink.WriteAndReportWarning(text ?? string.Empty);
        }

        public static void Warn(Exception exception)
        {
            // if (LogLevel <= LogLevel.Warning)
            //     HandleException(exception, OutputSink.WriteAndReportWarning);
        }
    }
}
