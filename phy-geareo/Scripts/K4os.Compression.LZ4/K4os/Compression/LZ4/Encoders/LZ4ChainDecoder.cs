using System;
using K4os.Compression.LZ4.Engine;
using K4os.Compression.LZ4.Internal;

namespace K4os.Compression.LZ4.Encoders
{
	public class LZ4ChainDecoder : UnmanagedResources, ILZ4Decoder, IDisposable
	{
		private PinnedMemory _outputBufferPin;

		private PinnedMemory _contextPin;

		private readonly int _blockSize;

		private readonly int _outputLength;

		private int _outputIndex;

		private unsafe byte* OutputBuffer => null;

		private unsafe LL.LZ4_streamDecode_t* Context => null;

		public int BlockSize => 0;

		public int BytesReady => 0;

		public LZ4ChainDecoder(int blockSize, int extraBlocks)
		{
		}

		public unsafe int Decode(byte* source, int length, int blockSize)
		{
			return 0;
		}

		public unsafe int Inject(byte* source, int length)
		{
			return 0;
		}

		public unsafe void Drain(byte* target, int offset, int length)
		{
		}

		public unsafe byte* Peek(int offset)
		{
			return null;
		}

		private void Prepare(int blockSize)
		{
		}

		private int CopyDict(int index)
		{
			return 0;
		}

		private int ApplyDict(int index)
		{
			return 0;
		}

		private unsafe int DecodeBlock(byte* source, int sourceLength, byte* target, int targetLength)
		{
			return 0;
		}

		protected override void ReleaseUnmanaged()
		{
		}
	}
}
