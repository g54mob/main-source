using System.IO.Compression;
using MemoryPack.Formatters;

namespace MemoryPack
{
	public sealed class BrotliStringFormatterAttribute : MemoryPackCustomFormatterAttribute<BrotliStringFormatter, string>
	{
		public CompressionLevel CompressionLevel { get; }

		public int Window { get; }

		public int DecompressionSizeLimit { get; }

		public BrotliStringFormatterAttribute(CompressionLevel compressionLevel = CompressionLevel.Fastest, int window = 22, int decompressionSizeLimit = 134217728)
		{
		}

		public override BrotliStringFormatter GetFormatter()
		{
			return null;
		}
	}
}
