using System.IO;

namespace ThreeDISevenZeroR.UnityGifDecoder.Utils
{
	public static class BitUtils
	{
		public static bool CheckString(byte[] array, string s)
		{
			return false;
		}

		public static int ReadInt16LittleEndian(this Stream reader)
		{
			return 0;
		}

		public static int ReadInt32LittleEndian(this Stream reader)
		{
			return 0;
		}

		public static byte ReadByte8(this Stream reader)
		{
			return 0;
		}

		public static void AssertByte(this Stream reader, int expectedValue)
		{
		}

		public static int GetColorTableSize(int data)
		{
			return 0;
		}

		public static int GetBitsFromByte(this byte b, int offset, int count)
		{
			return 0;
		}

		public static bool GetBitFromByte(this byte b, int offset)
		{
			return false;
		}

		public static byte[] ReadGifBlocks(Stream reader)
		{
			return null;
		}

		public static void SkipGifBlocks(Stream reader)
		{
		}
	}
}
