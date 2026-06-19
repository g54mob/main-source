using System;
using System.IO;
using System.IO.Compression;

namespace Pug.UnityExtensions
{
	public static class FileCompressionUtility
	{
		public static bool TryGetBrotliCompressedSize(byte[] compressedData, out uint size, byte[] optionalReadBuffer = null)
		{
			if (optionalReadBuffer == null)
			{
				optionalReadBuffer = new byte[1024];
			}
			using MemoryStream stream = new MemoryStream(compressedData);
			using BrotliStream brotliStream = new BrotliStream(stream, CompressionMode.Decompress);
			size = 0u;
			try
			{
				while (true)
				{
					int num = brotliStream.Read(optionalReadBuffer);
					if (num != 0)
					{
						size += (uint)num;
						continue;
					}
					break;
				}
			}
			catch
			{
				return false;
			}
			return true;
		}

		public static bool TryGetGzipCompressedSize(byte[] compressedData, out uint size)
		{
			if (!IsGzipCompressed(compressedData))
			{
				size = 0u;
				return false;
			}
			size = GetGzipCompressedSize(compressedData);
			return true;
		}

		public static bool IsGzipCompressed(ReadOnlySpan<byte> fileData)
		{
			if (fileData.Length < 18)
			{
				return false;
			}
			if (fileData[0] != 31 || fileData[1] != 139)
			{
				return false;
			}
			if (fileData[2] != 8)
			{
				return false;
			}
			return true;
		}

		private static uint GetGzipCompressedSize(ReadOnlySpan<byte> compressedData)
		{
			ReadOnlySpan<byte> readOnlySpan = compressedData;
			int length = readOnlySpan.Length;
			int num = length - 4;
			return BitConverter.ToUInt32(readOnlySpan.Slice(num, length - num));
		}
	}
}
