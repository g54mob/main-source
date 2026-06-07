using System.IO;
using System.IO.Compression;

namespace UltimateReplay.Storage
{
	public static class Compression
	{
		private static readonly int decompressBufferSize = 4096;

		private static byte[] decompressBuffer = null;

		public static byte[] CompressData(byte[] data, CompressionLevel level = CompressionLevel.Optimal)
		{
			if (level == CompressionLevel.None)
			{
				return data;
			}
			using (MemoryStream memoryStream = new MemoryStream())
			{
				using (GZipStream gZipStream = new GZipStream(memoryStream, CompressionMode.Compress))
				{
					gZipStream.Write(data, 0, data.Length);
				}
				return memoryStream.ToArray();
			}
		}

		public static byte[] DecompressData(byte[] data, CompressionLevel level = CompressionLevel.Optimal)
		{
			if (level == CompressionLevel.None)
			{
				return data;
			}
			if (decompressBuffer == null)
			{
				decompressBuffer = new byte[decompressBufferSize];
			}
			using (MemoryStream stream = new MemoryStream(data))
			{
				using (MemoryStream memoryStream = new MemoryStream())
				{
					using (GZipStream gZipStream = new GZipStream(stream, CompressionMode.Decompress))
					{
						int num = 0;
						while ((num = gZipStream.Read(decompressBuffer, 0, decompressBufferSize)) > 0)
						{
							memoryStream.Write(decompressBuffer, 0, num);
						}
					}
					return memoryStream.ToArray();
				}
			}
		}
	}
}
