namespace ICSharpCode.SharpZipLib.Checksums
{
	public class StrangeCRC : IChecksum
	{
		private static readonly uint[] crc32Table;

		private int globalCrc;

		public long Value => 0L;

		public void Reset()
		{
		}

		public void Update(int value)
		{
		}

		public void Update(byte[] buffer)
		{
		}

		public void Update(byte[] buffer, int offset, int count)
		{
		}
	}
}
