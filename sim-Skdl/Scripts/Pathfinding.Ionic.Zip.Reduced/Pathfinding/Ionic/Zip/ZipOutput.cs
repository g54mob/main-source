using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Pathfinding.Ionic.Zip
{
	internal static class ZipOutput
	{
		public static bool WriteCentralDirectoryStructure(Stream s, ICollection<ZipEntry> entries, uint numSegments, Zip64Option zip64, string comment, ZipContainer container)
		{
			return false;
		}

		private static Encoding GetEncoding(ZipContainer container, string t)
		{
			return null;
		}

		private static byte[] GenCentralDirectoryFooter(long StartOfCentralDirectory, long EndOfCentralDirectory, Zip64Option zip64, int entryCount, string comment, ZipContainer container)
		{
			return null;
		}

		private static byte[] GenZip64EndOfCentralDirectory(long StartOfCentralDirectory, long EndOfCentralDirectory, int entryCount, uint numSegments)
		{
			return null;
		}

		private static int CountEntries(ICollection<ZipEntry> _entries)
		{
			return 0;
		}
	}
}
