using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Amazon.Runtime.Internal.Util
{
	internal class EventStream : WrapperStream
	{
		internal delegate void ReadProgress(int bytesRead);

		private bool disableClose;

		public override bool CanRead => base.BaseStream.CanRead;

		public override bool CanSeek => base.BaseStream.CanSeek;

		public override bool CanTimeout => base.BaseStream.CanTimeout;

		public override bool CanWrite => base.BaseStream.CanWrite;

		public override long Length => base.BaseStream.Length;

		public override long Position
		{
			get
			{
				return base.BaseStream.Position;
			}
			set
			{
				base.BaseStream.Position = value;
			}
		}

		public override int ReadTimeout
		{
			get
			{
				return base.BaseStream.ReadTimeout;
			}
			set
			{
				base.BaseStream.ReadTimeout = value;
			}
		}

		public override int WriteTimeout
		{
			get
			{
				return base.BaseStream.WriteTimeout;
			}
			set
			{
				base.BaseStream.WriteTimeout = value;
			}
		}

		internal event ReadProgress OnRead;

		internal EventStream(Stream stream, bool disableClose)
			: base(stream)
		{
			this.disableClose = disableClose;
		}

		protected override void Dispose(bool disposing)
		{
		}

		public override void Flush()
		{
			base.BaseStream.Flush();
		}

		public override int Read(byte[] buffer, int offset, int count)
		{
			int num = base.BaseStream.Read(buffer, offset, count);
			if (this.OnRead != null)
			{
				this.OnRead(num);
			}
			return num;
		}

		public override long Seek(long offset, SeekOrigin origin)
		{
			return base.BaseStream.Seek(offset, origin);
		}

		public override void SetLength(long value)
		{
			base.BaseStream.SetLength(value);
		}

		public override void Write(byte[] buffer, int offset, int count)
		{
			throw new NotImplementedException();
		}

		public override void WriteByte(byte value)
		{
			throw new NotImplementedException();
		}

		public override Task FlushAsync(CancellationToken cancellationToken)
		{
			return base.BaseStream.FlushAsync(cancellationToken);
		}

		public override async Task<int> ReadAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
		{
			int num = await base.BaseStream.ReadAsync(buffer, offset, count, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
			if (this.OnRead != null)
			{
				this.OnRead(num);
			}
			return num;
		}

		public override Task WriteAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
		{
			throw new NotImplementedException();
		}
	}
}
