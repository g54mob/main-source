using System.IO.Compression;
using MemoryPack.Compression;

namespace MemoryPack
{
	public sealed class BrotliFormatterAttribute : MemoryPackCustomFormatterAttribute<BrotliFormatter, byte[]>
	{
		public CompressionLevel CompressionLevel { get; }

		public int Window { get; }

		public int DecompressionSizeLimit { get; }

		public BrotliFormatterAttribute(CompressionLevel compressionLevel = CompressionLevel.Fastest, int window = 22, int decompressionSizeLimit = 134217728)
		{
		}

		public override BrotliFormatter GetFormatter()
		{
			return null;
		}
	}
	public sealed class BrotliFormatterAttribute<T> : MemoryPackCustomFormatterAttribute<BrotliFormatter<T>, T> where T : notnull
	{
		public CompressionLevel CompressionLevel { get; }

		public int Window { get; }

		public BrotliFormatterAttribute(CompressionLevel compressionLevel = CompressionLevel.Fastest, int window = 22)
		{
		}

		public override BrotliFormatter<T> GetFormatter()
		{
			return null;
		}
	}
}
