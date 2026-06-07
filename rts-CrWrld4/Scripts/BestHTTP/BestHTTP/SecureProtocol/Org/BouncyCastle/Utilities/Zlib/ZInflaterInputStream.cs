using System.IO;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Utilities.Zlib
{
	public class ZInflaterInputStream : Stream
	{
		protected ZStream z;

		protected int flushLevel;

		private const int BUFSIZE = 4192;

		protected byte[] buf;

		private byte[] buf1;

		protected Stream inp;

		private bool nomoreinput;

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

		public ZInflaterInputStream(Stream inp)
		{
		}

		public ZInflaterInputStream(Stream inp, bool nowrap)
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

		public override int Read(byte[] b, int off, int len)
		{
			return 0;
		}

		public override void Flush()
		{
		}

		public override void WriteByte(byte b)
		{
		}

		public override void Close()
		{
		}

		public override int ReadByte()
		{
			return 0;
		}
	}
}
