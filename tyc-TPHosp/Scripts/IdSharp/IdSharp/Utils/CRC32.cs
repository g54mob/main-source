using System.IO;

namespace IdSharp.Utils
{
	public static class CRC32
	{
		private const int BUFFER_SIZE = 1024;

		private static readonly uint[] crc32Table;

		static CRC32()
		{
			crc32Table = new uint[256];
			uint num = 3988292384u;
			for (uint num2 = 0u; num2 < 256; num2++)
			{
				uint num3 = num2;
				for (uint num4 = 8u; num4 != 0; num4--)
				{
					num3 = (((num3 & 1) != 1) ? (num3 >> 1) : ((num3 >> 1) ^ num));
				}
				crc32Table[num2] = num3;
			}
		}

		public static string Calculate(string path)
		{
			return $"{(uint)CalculateInt32(path):X8}";
		}

		public static string Calculate(Stream stream)
		{
			return $"{(uint)CalculateInt32(stream):X8}";
		}

		public static string Calculate(byte[] data)
		{
			return $"{(uint)CalculateInt32(data):X8}";
		}

		public static int CalculateInt32(string path)
		{
			using FileStream stream = File.Open(path, FileMode.Open, FileAccess.Read, FileShare.Read);
			return CalculateInt32(stream);
		}

		public static int CalculateInt32(Stream stream)
		{
			stream.Position = 0L;
			uint num = uint.MaxValue;
			byte[] array = new byte[1024];
			for (int num2 = stream.Read(array, 0, 1024); num2 > 0; num2 = stream.Read(array, 0, 1024))
			{
				for (int i = 0; i < num2; i++)
				{
					num = (num >> 8) ^ crc32Table[array[i] ^ (num & 0xFF)];
				}
			}
			return (int)(~num);
		}

		public static int CalculateInt32(byte[] data)
		{
			using MemoryStream stream = new MemoryStream(data);
			return CalculateInt32(stream);
		}
	}
}
