using System.IO;

namespace Pathfinding.Ionic.Zip
{
	public class CountingStream : Stream
	{
		private Stream _s;

		private long _bytesWritten;

		private long _bytesRead;

		private long _initialOffset;

		public Stream WrappedStream => null;

		public long BytesWritten => 0L;

		public long BytesRead => 0L;

		public override bool CanRead => false;

		public override bool CanSeek => false;

		public override bool CanWrite => false;

		public override long Length => 0L;

		public long ComputedPosition => 0L;

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

		public CountingStream(Stream stream)
		{
		}

		public void Adjust(long delta)
		{
		}

		public override int Read(byte[] buffer, int offset, int count)
		{
			return 0;
		}

		public override void Write(byte[] buffer, int offset, int count)
		{
		}

		public override void Flush()
		{
		}

		public override long Seek(long offset, SeekOrigin origin)
		{
			return 0L;
		}

		public override void SetLength(long value)
		{
		}
	}
}
