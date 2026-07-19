using System;
using System.IO;

namespace UniJSON
{
	public static class ByteExtensions
	{
		public static byte GetHexDigit(this ushort n, int index)
		{
			return (byte)((n >> 8 * index) & 0xFF);
		}

		public static byte GetHexDigit(this uint n, int index)
		{
			return (byte)((n >> 8 * index) & 0xFF);
		}

		public static byte GetHexDigit(this ulong n, int index)
		{
			return (byte)((n >> 8 * index) & 0xFF);
		}

		public static byte GetHexDigit(this short n, int index)
		{
			return (byte)((n >> 8 * index) & 0xFF);
		}

		public static byte GetHexDigit(this int n, int index)
		{
			return (byte)((n >> 8 * index) & 0xFF);
		}

		public static byte GetHexDigit(this long n, int index)
		{
			return (byte)((n >> 8 * index) & 0xFF);
		}

		public static uint ToUint32(this float n, byte[] buffer)
		{
			if (buffer.Length < 4)
			{
				throw new ArgumentException();
			}
			using (MemoryStream output = new MemoryStream(buffer))
			{
				using BinaryWriter binaryWriter = new BinaryWriter(output);
				binaryWriter.Write(n);
			}
			return BitConverter.ToUInt32(buffer, 0);
		}

		public static ulong ToUint64(this double n, byte[] buffer)
		{
			if (buffer.Length < 8)
			{
				throw new ArgumentException();
			}
			using (MemoryStream output = new MemoryStream(buffer))
			{
				using BinaryWriter binaryWriter = new BinaryWriter(output);
				binaryWriter.Write(n);
			}
			return BitConverter.ToUInt64(buffer, 0);
		}
	}
}
