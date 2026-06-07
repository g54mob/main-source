using System;
using System.IO;
using System.Security.Cryptography;

namespace ICSharpCode.SharpZipLib.Zip.Compression.Streams
{
	public class DeflaterOutputStream : Stream
	{
		private ICryptoTransform cryptoTransform_;

		protected byte[] AESAuthCode;

		private byte[] buffer_;

		protected Deflater deflater_;

		protected Stream baseOutputStream_;

		private bool isClosed_;

		private bool isStreamOwner_;

		public bool IsStreamOwner => false;

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

		public override IAsyncResult BeginRead(byte[] buffer, int offset, int count, AsyncCallback callback, object state)
		{
			return null;
		}

		public override IAsyncResult BeginWrite(byte[] buffer, int offset, int count, AsyncCallback callback, object state)
		{
			return null;
		}

		public override void Flush()
		{
		}

		public override void Close()
		{
		}

		private void GetAuthCodeIfAES()
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
