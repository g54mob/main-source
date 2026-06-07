using System.IO;

namespace BestHTTP.Extensions
{
	public sealed class ReadOnlyBufferedStream : Stream
	{
		private Stream stream;

		public const int READBUFFER = 8192;

		private byte[] buf;

		private int available;

		private int pos;

		public override bool CanRead => false;

		public override bool CanSeek => false;

		public override bool CanWrite => false;

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

		public ReadOnlyBufferedStream(Stream nstream)
		{
		}

		public ReadOnlyBufferedStream(Stream nstream, int bufferSize)
		{
		}

		public override int Read(byte[] buffer, int offset, int size)
		{
			return 0;
		}

		public override int ReadByte()
		{
			return 0;
		}

		protected override void Dispose(bool disposing)
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

		public override void Write(byte[] buffer, int offset, int count)
		{
		}
	}
}
