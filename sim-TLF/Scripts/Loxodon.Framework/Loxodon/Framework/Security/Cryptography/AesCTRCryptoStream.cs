using System;
using System.IO;
using System.Security.Cryptography;

namespace Loxodon.Framework.Security.Cryptography
{
	public class AesCTRCryptoStream : Stream
	{
		private readonly object _lock = new object();

		private Stream stream;

		private bool leaveOpen;

		private bool canRead;

		private bool canSeek;

		private bool canWrite;

		private byte[] writeBuffer;

		private byte[] readBuffer;

		private AesCTRCryptoTransform transform;

		public override bool CanRead => canRead;

		public override bool CanSeek => canSeek;

		public override bool CanWrite => canWrite;

		public override long Length => stream.Length;

		public override long Position
		{
			get
			{
				return stream.Position;
			}
			set
			{
				if (stream.Position != value)
				{
					Seek(value, SeekOrigin.Begin);
				}
			}
		}

		public AesCTRCryptoStream(Stream stream, AesCTRCryptoTransform transform, CryptoStreamMode streamMode)
			: this(stream, transform, streamMode, leaveOpen: false)
		{
		}

		public AesCTRCryptoStream(Stream stream, AesCTRCryptoTransform transform, CryptoStreamMode streamMode, bool leaveOpen)
		{
			this.stream = stream;
			this.transform = transform;
			this.leaveOpen = leaveOpen;
			canRead = stream.CanRead;
			canSeek = stream.CanSeek;
			canWrite = stream.CanWrite;
			if (streamMode == CryptoStreamMode.Read && !canRead)
			{
				throw new ArgumentException("The stream is not readable", "stream");
			}
			if (streamMode == CryptoStreamMode.Write && !canWrite)
			{
				throw new ArgumentException("The stream is not writable", "stream");
			}
			this.transform.Position = stream.Position;
			if (streamMode == CryptoStreamMode.Read)
			{
				readBuffer = new byte[8192];
			}
			else
			{
				writeBuffer = new byte[8192];
			}
		}

		public override void Flush()
		{
			stream.Flush();
		}

		public override int Read(byte[] buffer, int offset, int count)
		{
			lock (_lock)
			{
				int num = count;
				while (num > 0)
				{
					int num2 = stream.Read(readBuffer, 0, Math.Min(readBuffer.Length, num));
					if (num2 <= 0)
					{
						return count - num;
					}
					transform.TransformBlock(readBuffer, 0, num2, buffer, offset);
					offset += num2;
					num -= num2;
				}
				return count;
			}
		}

		public override long Seek(long offset, SeekOrigin origin)
		{
			lock (_lock)
			{
				long num = stream.Seek(offset, origin);
				transform.Position = num;
				return num;
			}
		}

		public override void SetLength(long value)
		{
			stream.SetLength(value);
		}

		public override void Write(byte[] buffer, int offset, int count)
		{
			lock (_lock)
			{
				int num = count;
				while (num > 0)
				{
					int num2 = transform.TransformBlock(buffer, offset, Math.Min(writeBuffer.Length, num), writeBuffer, 0);
					if (num2 <= 0)
					{
						break;
					}
					stream.Write(writeBuffer, 0, num2);
					offset += num2;
					num -= num2;
				}
			}
		}

		protected override void Dispose(bool disposing)
		{
			try
			{
				if (disposing && !leaveOpen && stream != null)
				{
					stream.Close();
					stream = null;
				}
			}
			finally
			{
				try
				{
					if (readBuffer != null)
					{
						Array.Clear(readBuffer, 0, readBuffer.Length);
					}
					if (writeBuffer != null)
					{
						Array.Clear(writeBuffer, 0, writeBuffer.Length);
					}
					readBuffer = null;
					writeBuffer = null;
					canRead = false;
					canWrite = false;
				}
				finally
				{
					base.Dispose(disposing);
				}
			}
		}
	}
}
