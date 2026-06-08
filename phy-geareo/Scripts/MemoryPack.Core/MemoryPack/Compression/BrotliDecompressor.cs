using System;
using System.Buffers;
using System.IO.Compression;
using MemoryPack.Internal;

namespace MemoryPack.Compression
{
	public struct BrotliDecompressor : IDisposable
	{
		private ReusableReadOnlySequenceBuilder? sequenceBuilder;

		public ReadOnlySequence<byte> Decompress(ReadOnlySpan<byte> compressedSpan)
		{
			return default(ReadOnlySequence<byte>);
		}

		public ReadOnlySequence<byte> Decompress(ReadOnlySpan<byte> compressedSpan, out int consumed)
		{
			consumed = default(int);
			return default(ReadOnlySequence<byte>);
		}

		public ReadOnlySequence<byte> Decompress(ReadOnlySequence<byte> compressedSequence)
		{
			return default(ReadOnlySequence<byte>);
		}

		public ReadOnlySequence<byte> Decompress(ReadOnlySequence<byte> compressedSequence, out int consumed)
		{
			consumed = default(int);
			return default(ReadOnlySequence<byte>);
		}

		private void DecompressCore(ref OperationStatus status, ref BrotliDecoder decoder, ReadOnlySpan<byte> source, out int consumed)
		{
			consumed = default(int);
		}

		public void Dispose()
		{
		}

		private int GetDoubleCapacity(int length)
		{
			return 0;
		}
	}
}
