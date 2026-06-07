using System.IO;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.IO
{
	public class SignerStream : Stream
	{
		protected readonly Stream stream;

		protected readonly ISigner inSigner;

		protected readonly ISigner outSigner;

		public override bool CanRead => false;

		public override bool CanWrite => false;

		public override bool CanSeek => false;

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

		public SignerStream(Stream stream, ISigner readSigner, ISigner writeSigner)
		{
		}

		public virtual ISigner ReadSigner()
		{
			return null;
		}

		public virtual ISigner WriteSigner()
		{
			return null;
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

		public override void WriteByte(byte b)
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

		public override void SetLength(long length)
		{
		}
	}
}
