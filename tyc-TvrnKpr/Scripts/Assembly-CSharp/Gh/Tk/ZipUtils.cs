using System;
using System.IO;

namespace Gh.Tk
{
	public static class ZipUtils
	{
		public static Stream CreateZipWithContent(params (string entryName, Func<Stream> getStream)[] contents)
		{
			return null;
		}

		public static Stream CreateZipWithContent(string entryName, Stream stream)
		{
			return null;
		}

		public static Stream ExtractEntryFully(Stream source, string entryName)
		{
			return null;
		}
	}
}
