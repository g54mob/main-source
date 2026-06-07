namespace ICSharpCode.SharpZipLib.Checksums
{
	public sealed class Adler32 : IChecksum
	{
		private const uint BASE = 65521u;

		private uint checksum;

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
