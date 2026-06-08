using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Amazon.Runtime.Internal.Util
{
	public class WrapperStream : Stream
	{
		protected Stream BaseStream { get; private set; }

		public override bool CanRead => BaseStream.CanRead;

		public override bool CanSeek => BaseStream.CanSeek;

		public override bool CanWrite => BaseStream.CanWrite;

		public override long Length => BaseStream.Length;

		public override long Position
		{
			get
			{
				return BaseStream.Position;
			}
			set
			{
				BaseStream.Position = value;
			}
		}

		public override int ReadTimeout
		{
			get
			{
				return BaseStream.ReadTimeout;
			}
			set
			{
				BaseStream.ReadTimeout = value;
			}
		}

		public override int WriteTimeout
		{
			get
			{
				return BaseStream.WriteTimeout;
			}
			set
			{
				BaseStream.WriteTimeout = value;
			}
		}

		internal virtual bool HasLength => true;

		public WrapperStream(Stream baseStream)
		{
			if (baseStream == null)
			{
				throw new ArgumentNullException("baseStream");
			}
			BaseStream = baseStream;
		}

		public Stream GetNonWrapperBaseStream()
		{
			Stream stream = this;
			do
			{
				if (stream is PartialWrapperStream result)
				{
					return result;
				}
				stream = (stream as WrapperStream).BaseStream;
			}
			while (stream is WrapperStream);
			return stream;
		}

		public Stream GetSeekableBaseStream()
		{
			Stream stream = this;
			do
			{
				if (stream.CanSeek)
				{
					return stream;
				}
				stream = (stream as WrapperStream).BaseStream;
			}
			while (stream is WrapperStream);
			if (!stream.CanSeek)
			{
				throw new InvalidOperationException("Unable to find seekable stream");
			}
			return stream;
		}

		public static Stream GetNonWrapperBaseStream(Stream stream)
		{
			if (!(stream is WrapperStream wrapperStream))
			{
				return stream;
			}
			return wrapperStream.GetNonWrapperBaseStream();
		}

		public Stream SearchWrappedStream(Func<Stream, bool> condition)
		{
			Stream stream = this;
			do
			{
				if (condition(stream))
				{
					return stream;
				}
				if (!(stream is WrapperStream))
				{
					return null;
				}
				stream = (stream as WrapperStream).BaseStream;
			}
			while (stream != null);
			return stream;
		}

		public static Stream SearchWrappedStream(Stream stream, Func<Stream, bool> condition)
		{
			if (!(stream is WrapperStream wrapperStream))
			{
				if (!condition(stream))
				{
					return null;
				}
				return stream;
			}
			return wrapperStream.SearchWrappedStream(condition);
		}

		protected override void Dispose(bool disposing)
		{
			base.Dispose(disposing);
			BaseStream.Dispose();
		}

		public override void Flush()
		{
			BaseStream.Flush();
		}

		public override int Read(byte[] buffer, int offset, int count)
		{
			return BaseStream.Read(buffer, offset, count);
		}

		public override long Seek(long offset, SeekOrigin origin)
		{
			return BaseStream.Seek(offset, origin);
		}

		public override void SetLength(long value)
		{
			BaseStream.SetLength(value);
		}

		public override void Write(byte[] buffer, int offset, int count)
		{
			BaseStream.Write(buffer, offset, count);
		}

		public override Task FlushAsync(CancellationToken cancellationToken)
		{
			return BaseStream.FlushAsync(cancellationToken);
		}

		public override Task<int> ReadAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
		{
			return BaseStream.ReadAsync(buffer, offset, count, cancellationToken);
		}

		public override Task WriteAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
		{
			return BaseStream.WriteAsync(buffer, offset, count, cancellationToken);
		}
	}
}
