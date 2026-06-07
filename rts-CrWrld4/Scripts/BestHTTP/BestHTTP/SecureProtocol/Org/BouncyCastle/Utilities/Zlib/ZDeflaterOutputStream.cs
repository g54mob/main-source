using System.IO;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Utilities.Zlib
{
	public class ZDeflaterOutputStream : Stream
	{
		protected ZStream z;

		protected int flushLevel;

		private const int BUFSIZE = 4192;

		protected byte[] buf;

		private byte[] buf1;

		protected Stream outp;

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

		public ZDeflaterOutputStream(Stream outp)
		{
		}

		public ZDeflaterOutputStream(Stream outp, int level)
		{
		}

		public ZDeflaterOutputStream(Stream outp, int level, bool nowrap)
		{
		}

		public override void Write(byte[] b, int off, int len)
		{
		}

		public override long Seek(long offset, SeekOrigin origin)
		{
			return 0L;
		}

		public override void SetLength(long value)
		{
		}

		public override int Read(byte[] buffer, int offset, int count)
		{
			return 0;
		}

		public override void Flush()
		{
		}

		public override void WriteByte(byte b)
		{
		}

		public void Finish()
		{
		}

		public void End()
		{
		}

		public override void Close()
		{
		}
	}
}
