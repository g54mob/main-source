using System.IO.Compression;

namespace MemoryPack.Compression
{
	internal static class BrotliUtils
	{
		public const int WindowBits_Min = 10;

		public const int WindowBits_Default = 22;

		public const int WindowBits_Max = 24;

		public const int Quality_Min = 0;

		public const int Quality_Default = 4;

		public const int Quality_Max = 11;

		public const int MaxInputSize = 2147483132;

		internal static int GetQualityFromCompressionLevel(CompressionLevel compressionLevel)
		{
			return 0;
		}

		internal static int BrotliEncoderMaxCompressedSize(int input_size)
		{
			return 0;
		}
	}
}
