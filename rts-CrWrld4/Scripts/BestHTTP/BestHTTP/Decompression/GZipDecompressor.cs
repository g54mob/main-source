using System;
using BestHTTP.Decompression.Zlib;
using BestHTTP.Extensions;

namespace BestHTTP.Decompression
{
	public sealed class GZipDecompressor : IDisposable
	{
		private BufferPoolMemoryStream decompressorInputStream;

		private BufferPoolMemoryStream decompressorOutputStream;

		private GZipStream decompressorGZipStream;

		private int MinLengthToDecompress;

		public GZipDecompressor(int minLengthToDecompress)
		{
		}

		private void CloseDecompressors()
		{
		}

		public DecompressedData Decompress(byte[] data, int offset, int count, bool forceDecompress = false, bool dataCanBeLarger = false)
		{
			return default(DecompressedData);
		}

		~GZipDecompressor()
		{
		}

		public void Dispose()
		{
		}
	}
}
