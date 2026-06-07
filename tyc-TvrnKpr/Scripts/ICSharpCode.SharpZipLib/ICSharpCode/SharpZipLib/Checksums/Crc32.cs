namespace ICSharpCode.SharpZipLib.Checksums
{
	public sealed class Crc32 : IChecksum
	{
		private const uint CrcSeed = 4294967295u;

		private static readonly uint[] CrcTable;

		private uint crc;

		public long Value
		{
			get
			{
				return 0L;
			}
			set
			{
			}
		}

		internal static uint ComputeCrc32(uint oldCrc, byte value)
		{
			return 0u;
		}

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
