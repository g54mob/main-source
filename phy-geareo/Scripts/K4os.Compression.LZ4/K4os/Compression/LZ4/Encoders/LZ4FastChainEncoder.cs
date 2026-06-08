using K4os.Compression.LZ4.Engine;
using K4os.Compression.LZ4.Internal;

namespace K4os.Compression.LZ4.Encoders
{
	public class LZ4FastChainEncoder : LZ4EncoderBase
	{
		private PinnedMemory _contextPin;

		private unsafe LL.LZ4_stream_t* Context => null;

		public LZ4FastChainEncoder(int blockSize, int extraBlocks = 0)
			: base(chaining: false, 0, 0)
		{
		}

		protected override void ReleaseUnmanaged()
		{
		}

		protected unsafe override int EncodeBlock(byte* source, int sourceLength, byte* target, int targetLength)
		{
			return 0;
		}

		protected unsafe override int CopyDict(byte* target, int length)
		{
			return 0;
		}
	}
}
