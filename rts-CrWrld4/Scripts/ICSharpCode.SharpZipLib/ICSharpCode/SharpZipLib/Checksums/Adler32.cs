namespace ICSharpCode.SharpZipLib.Checksums
{
	public sealed class Adler32
	{
		private uint checksum;

		public long Value => 0L;

		public void Reset()
		{
		}

		public void Update(byte[] buffer, int offset, int count)
		{
		}
	}
}
