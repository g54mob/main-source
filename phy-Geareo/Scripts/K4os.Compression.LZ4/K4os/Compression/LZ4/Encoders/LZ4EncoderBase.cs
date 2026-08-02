using System;
using K4os.Compression.LZ4.Internal;

namespace K4os.Compression.LZ4.Encoders
{
	public abstract class LZ4EncoderBase : UnmanagedResources, ILZ4Encoder, IDisposable
	{
		private PinnedMemory _inputBufferPin;

		private readonly int _inputLength;

		private readonly int _blockSize;

		private int _inputIndex;

		private int _inputPointer;

		private unsafe byte* InputBuffer => null;

		public int BlockSize => 0;

		public int BytesReady => 0;

		protected LZ4EncoderBase(bool chaining, int blockSize, int extraBlocks)
		{
		}

		public unsafe int Topup(byte* source, int length)
		{
			return 0;
		}

		public unsafe int Encode(byte* target, int length, bool allowCopy)
		{
			return 0;
		}

		private void Commit()
		{
		}

		protected unsafe abstract int EncodeBlock(byte* source, int sourceLength, byte* target, int targetLength);

		protected unsafe abstract int CopyDict(byte* target, int dictionaryLength);

		protected override void ReleaseUnmanaged()
		{
		}
	}
}
