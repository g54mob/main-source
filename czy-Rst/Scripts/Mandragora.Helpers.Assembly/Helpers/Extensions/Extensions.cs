using System.IO;
using System.Linq;

namespace Helpers.Extensions
{
	public static class Extensions
	{
		public static long DirectorySize(this DirectoryInfo dInfo, bool includeSubDir)
		{
			long num = dInfo.EnumerateFiles().Sum((FileInfo file) => file.Length);
			if (includeSubDir)
			{
				num += dInfo.EnumerateDirectories().Sum((DirectoryInfo dir) => dir.DirectorySize(includeSubDir: true));
			}
			return num;
		}
	}
}
