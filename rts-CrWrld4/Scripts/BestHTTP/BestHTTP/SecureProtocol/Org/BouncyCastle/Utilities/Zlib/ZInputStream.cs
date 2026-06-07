using System.IO;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Utilities.Zlib
{
	public class ZInputStream : Stream
	{
		private const int BufferSize = 4096;

		protected ZStream z;

		protected int flushLevel;

		protected byte[] buf;

		protected byte[] buf1;

		protected bool compress;

		protected Stream input;

		protected bool closed;

		private bool nomoreinput;

		public sealed override bool CanRead => false;

		public sealed override bool CanSeek => false;

		public sealed override bool CanWrite => false;

		public virtual int FlushMode
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public sealed override long Length => 0L;

		public sealed override long Position
		{
			get
			{
				return 0L;
			}
			set
			{
			}
		}

		public virtual long TotalIn => 0L;

		public virtual long TotalOut => 0L;

		private static ZStream GetDefaultZStream(bool nowrap)
		{
			return null;
		}

		public ZInputStream(Stream input)
		{
		}

		public ZInputStream(Stream input, bool nowrap)
		{
		}

		public ZInputStream(Stream input, ZStream z)
		{
		}

		public ZInputStream(Stream input, int level)
		{
		}

		public ZInputStream(Stream input, int level, bool nowrap)
		{
		}

		public override void Close()
		{
		}

		public sealed override void Flush()
		{
		}

		public override int Read(byte[] b, int off, int len)
		{
			return 0;
		}

		public override int ReadByte()
		{
			return 0;
		}

		public sealed override long Seek(long offset, SeekOrigin origin)
		{
			return 0L;
		}

		public sealed override void SetLength(long value)
		{
		}

		public sealed override void Write(byte[] buffer, int offset, int count)
		{
		}
	}
}
