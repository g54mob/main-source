using System;
using System.IO;

namespace ICSharpCode.SharpZipLib.Core
{
	public sealed class StreamUtils
	{
		public static void ReadFully(Stream stream, byte[] buffer)
		{
		}

		public static void ReadFully(Stream stream, byte[] buffer, int offset, int count)
		{
		}

		public static int ReadRequestedBytes(Stream stream, byte[] buffer, int offset, int count)
		{
			return 0;
		}

		public static void Copy(Stream source, Stream destination, byte[] buffer)
		{
		}

		public static void Copy(Stream source, Stream destination, byte[] buffer, ProgressHandler progressHandler, TimeSpan updateInterval, object sender, string name)
		{
		}

		public static void Copy(Stream source, Stream destination, byte[] buffer, ProgressHandler progressHandler, TimeSpan updateInterval, object sender, string name, long fixedTarget)
		{
		}

		private StreamUtils()
		{
		}
	}
}
