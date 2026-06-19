namespace Pug.UnityExtensions
{
	public class CRC32
	{
		private static readonly uint[] table;

		public uint sum { get; private set; }

		public void Feed(byte[] data)
		{
			sum = ~sum;
			foreach (byte b in data)
			{
				sum = (sum >> 8) ^ table[(sum ^ b) & 0xFF];
			}
			sum = ~sum;
		}

		static CRC32()
		{
			table = new uint[256];
			for (uint num = 0u; num < 256; num++)
			{
				uint num2 = num;
				for (int num3 = 8; num3 > 0; num3--)
				{
					num2 = (((num2 & 1) != 1) ? (num2 >> 1) : ((num2 >> 1) ^ 0xEDB88320u));
				}
				table[num] = num2;
			}
		}

		public static uint ComputeChecksum(params byte[][] bytes)
		{
			CRC32 cRC = new CRC32();
			foreach (byte[] data in bytes)
			{
				cRC.Feed(data);
			}
			return cRC.sum;
		}
	}
}
