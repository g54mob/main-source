namespace ICSharpCode.SharpZipLib.Checksums
{
	public sealed class Crc32
	{
		private static readonly uint[] CrcTable;

		private uint crc;

		public long Value => 0L;

		public void Update(int value)
		{
		}

		public void Update(byte[] buffer, int offset, int count)
		{
		}
	}
}
