using System.IO;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.Utilities
{
	public class FilterStream : Stream
	{
		protected readonly Stream s;

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

		public FilterStream(Stream s)
		{
		}

		public override void Close()
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

		public override int Read(byte[] buffer, int offset, int count)
		{
			return 0;
		}

		public override int ReadByte()
		{
			return 0;
		}

		public override void Write(byte[] buffer, int offset, int count)
		{
		}

		public override void WriteByte(byte value)
		{
		}
	}
}
