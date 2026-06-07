namespace SevenZip
{
	public class CRC
	{
		public static readonly uint[] Table;

		private uint _value;

		static CRC()
		{
		}

		public void Init()
		{
		}

		public void UpdateByte(byte b)
		{
		}

		public void Update(byte[] data, uint offset, uint size)
		{
		}

		public uint GetDigest()
		{
			return 0u;
		}

		private static uint CalculateDigest(byte[] data, uint offset, uint size)
		{
			return 0u;
		}

		private static bool VerifyDigest(uint digest, byte[] data, uint offset, uint size)
		{
			return false;
		}
	}
}
