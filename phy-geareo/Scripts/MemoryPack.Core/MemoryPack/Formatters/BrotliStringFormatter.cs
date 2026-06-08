using System;
using System.IO.Compression;
using System.Runtime.CompilerServices;
using MemoryPack.Internal;

namespace MemoryPack.Formatters
{
	[Preserve]
	public sealed class BrotliStringFormatter : MemoryPackFormatter<string>
	{
		[ThreadStatic]
		private static StrongBox<int>? threadStaticConsumedBox;

		internal const int DefaultDecompssionSizeLimit = 134217728;

		public static readonly BrotliStringFormatter Default;

		private readonly CompressionLevel compressionLevel;

		private readonly int window;

		private readonly int decompressionSizeLimit;

		public BrotliStringFormatter()
		{
		}

		public BrotliStringFormatter(CompressionLevel compressionLevel)
		{
		}

		public BrotliStringFormatter(CompressionLevel compressionLevel, int window)
		{
		}

		public BrotliStringFormatter(CompressionLevel compressionLevel, int window, int decompressionSizeLimit)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[Preserve]
		public override void Serialize<TBufferWriter>(ref MemoryPackWriter<TBufferWriter> writer, [ScopedRef] ref string? value)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[Preserve]
		public override void Deserialize(ref MemoryPackReader reader, [ScopedRef] ref string? value)
		{
		}
	}
}
