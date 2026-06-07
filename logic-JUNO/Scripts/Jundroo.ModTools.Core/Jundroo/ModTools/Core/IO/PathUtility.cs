using System;
using System.IO;

namespace Jundroo.ModTools.Core.IO
{
	public static class PathUtility
	{
		public static string NormalizePath(string path, bool preserveCasing)
		{
			string text = Path.GetFullPath(new Uri(path).LocalPath).TrimEnd(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar);
			if (!preserveCasing)
			{
				return text.ToLowerInvariant();
			}
			return text;
		}
	}
}
