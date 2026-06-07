using System.IO;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.IO
{
	public class CipherStream : Stream
	{
		internal Stream stream;

		internal IBufferedCipher inCipher;

		internal IBufferedCipher outCipher;

		private byte[] mInBuf;

		private int mInPos;

		private bool inStreamEnded;

		public IBufferedCipher ReadCipher => null;

		public IBufferedCipher WriteCipher => null;

		public override bool CanRead => false;

		public override bool CanWrite => false;

		public override bool CanSeek => false;

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

		public CipherStream(Stream stream, IBufferedCipher readCipher, IBufferedCipher writeCipher)
		{
		}

		public override int ReadByte()
		{
			return 0;
		}

		public override int Read(byte[] buffer, int offset, int count)
		{
			return 0;
		}

		private bool FillInBuf()
		{
			return false;
		}

		private byte[] ReadAndProcessBlock()
		{
			return null;
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

		public sealed override long Seek(long offset, SeekOrigin origin)
		{
			return 0L;
		}

		public sealed override void SetLength(long length)
		{
		}
	}
}
