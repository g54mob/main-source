using System.IO;

namespace Mirror.SimpleWeb
{
	public static class ReadHelper
	{
		public static int Read(Stream stream, byte[] outBuffer, int outOffset, int length)
		{
			return 0;
		}

		public static bool TryRead(Stream stream, byte[] outBuffer, int outOffset, int length)
		{
			return false;
		}

		public static int? SafeReadTillMatch(Stream stream, byte[] outBuffer, int outOffset, int maxLength, byte[] endOfHeader)
		{
			return null;
		}
	}
}
