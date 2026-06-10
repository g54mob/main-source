using System.IO;
using System.Security.Cryptography;

namespace ICSharpCode.SharpZipLib.Zip.Compression.Streams
{
	public class DeflaterOutputStream : Stream
	{
		protected ICryptoTransform cryptoTransform_;

		protected byte[] AESAuthCode;

		private byte[] buffer_;

		protected Deflater deflater_;

		protected Stream baseOutputStream_;

		private bool isClosed_;

		public bool IsStreamOwner { get; set; }

		public bool CanPatchEntries => false;

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

		public DeflaterOutputStream(Stream baseOutputStream)
		{
		}

		public DeflaterOutputStream(Stream baseOutputStream, Deflater deflater)
		{
		}

		public DeflaterOutputStream(Stream baseOutputStream, Deflater deflater, int bufferSize)
		{
		}

		public virtual void Finish()
		{
		}

		protected void EncryptBlock(byte[] buffer, int offset, int length)
		{
		}

		protected void Deflate()
		{
		}

		private void Deflate(bool flushing)
		{
		}

		public override long Seek(long offset, SeekOrigin origin)
		{
			return 0L;
		}

		public override void SetLength(long value)
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

		public override void Flush()
		{
		}

		protected override void Dispose(bool disposing)
		{
		}

		protected void GetAuthCodeIfAES()
		{
		}

		public override void WriteByte(byte value)
		{
		}

		public override void Write(byte[] buffer, int offset, int count)
		{
		}
	}
}
