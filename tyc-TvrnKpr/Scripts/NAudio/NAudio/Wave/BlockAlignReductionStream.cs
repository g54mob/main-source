using NAudio.Utils;

namespace NAudio.Wave
{
	public class BlockAlignReductionStream : WaveStream
	{
		private WaveStream sourceStream;

		private long position;

		private readonly CircularBuffer circularBuffer;

		private long bufferStartPosition;

		private byte[] sourceBuffer;

		private readonly object lockObject;

		public override int BlockAlign => 0;

		public override WaveFormat WaveFormat => null;

		public override long Length => 0L;

		public override long Position
		{
			get
			{
				return 0L;
			}
			set
			{
			}
		}

		private long BufferEndPosition => 0L;

		public BlockAlignReductionStream(WaveStream sourceStream)
		{
		}

		private byte[] GetSourceBuffer(int size)
		{
			return null;
		}

		protected override void Dispose(bool disposing)
		{
		}

		public override int Read(byte[] buffer, int offset, int count)
		{
			return 0;
		}
	}
}
