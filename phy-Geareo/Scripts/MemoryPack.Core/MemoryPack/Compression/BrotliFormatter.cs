using System.IO.Compression;
using System.Runtime.CompilerServices;
using MemoryPack.Internal;

namespace MemoryPack.Compression
{
	[Preserve]
	public sealed class BrotliFormatter : MemoryPackFormatter<byte[]>
	{
		internal const int DefaultDecompssionSizeLimit = 134217728;

		public static readonly BrotliFormatter Default;

		private readonly CompressionLevel compressionLevel;

		private readonly int window;

		private readonly int decompressionSizeLimit;

		public BrotliFormatter()
		{
		}

		public BrotliFormatter(CompressionLevel compressionLevel)
		{
		}

		public BrotliFormatter(CompressionLevel compressionLevel, int window)
		{
		}

		public BrotliFormatter(CompressionLevel compressionLevel, int window, int decompressionSizeLimit)
		{
		}

		[Preserve]
		public override void Serialize<TBufferWriter>(ref MemoryPackWriter<TBufferWriter> writer, [ScopedRef] ref byte[]? value)
		{
		}

		[Preserve]
		public override void Deserialize(ref MemoryPackReader reader, [ScopedRef] ref byte[]? value)
		{
		}
	}
	[Preserve]
	public sealed class BrotliFormatter<T> : MemoryPackFormatter<T> where T : notnull
	{
		internal const int DefaultDecompssionSizeLimit = 134217728;

		public static readonly BrotliFormatter Default;

		private readonly CompressionLevel compressionLevel;

		private readonly int window;

		public BrotliFormatter()
		{
		}

		public BrotliFormatter(CompressionLevel compressionLevel)
		{
		}

		public BrotliFormatter(CompressionLevel compressionLevel, int window)
		{
		}

		[Preserve]
		public override void Serialize<TBufferWriter>(ref MemoryPackWriter<TBufferWriter> writer, [ScopedRef] ref T? value)
		{
		}

		[Preserve]
		public override void Deserialize(ref MemoryPackReader reader, [ScopedRef] ref T? value)
		{
		}
	}
}
