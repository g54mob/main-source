namespace LiteNetLib.Utils
{
	public static class CRC32C
	{
		public const int ChecksumSize = 4;

		private const uint Poly = 2197175160u;

		private static readonly uint[] Table;

		static CRC32C()
		{
		}

		public static uint Compute(byte[] input, int offset, int length)
		{
			return 0u;
		}
	}
}
