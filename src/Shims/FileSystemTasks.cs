// Copyright 2021 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.IO;
using System.Linq;
using JetBrains.Annotations;
using Nuke.Common.Utilities.Collections;

namespace Nuke.Common.IO
{
    public static partial class FileSystemTasks
    {
        public static void EnsureExistingDirectory(string directory)
        {
            if (Directory.Exists(directory))
                return;

            Logger.Info($"Creating directory '{directory}'...");
            Directory.CreateDirectory(directory);
        }
        
        [CanBeNull]
        public static string FindParentDirectory(string start, Func<DirectoryInfo, bool> predicate)
        {
            return FindParentDirectory(new DirectoryInfo(start), predicate)?.FullName;
        }

        [CanBeNull]
        public static DirectoryInfo FindParentDirectory(DirectoryInfo start, Func<DirectoryInfo, bool> predicate)
        {
            return start
                .DescendantsAndSelf(x => x.Parent)
                .Where(x => x != null)
                .FirstOrDefault(predicate);
        }
    }
}
