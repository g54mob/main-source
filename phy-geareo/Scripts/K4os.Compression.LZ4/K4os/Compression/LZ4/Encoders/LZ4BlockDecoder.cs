using System;
using K4os.Compression.LZ4.Internal;

namespace K4os.Compression.LZ4.Encoders
{
	public class LZ4BlockDecoder : UnmanagedResources, ILZ4Decoder, IDisposable
	{
		private PinnedMemory _outputBufferPin;

		private readonly int _outputLength;

		private int _outputIndex;

		private readonly int _blockSize;

		private unsafe byte* OutputBuffer => null;

		public int BlockSize => 0;

		public int BytesReady => 0;

		public LZ4BlockDecoder(int blockSize)
		{
		}

		public unsafe int Decode(byte* source, int length, int blockSize = 0)
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

		protected override void ReleaseUnmanaged()
		{
		}
	}
}
