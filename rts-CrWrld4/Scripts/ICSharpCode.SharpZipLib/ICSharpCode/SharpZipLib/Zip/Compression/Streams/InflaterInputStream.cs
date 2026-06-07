using System;
using System.IO;

namespace ICSharpCode.SharpZipLib.Zip.Compression.Streams
{
	public class InflaterInputStream : Stream
	{
		protected Inflater inf;

		protected InflaterInputBuffer inputBuffer;

		private Stream baseInputStream;

		private bool isClosed;

		private bool isStreamOwner;

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

		public InflaterInputStream(Stream baseInputStream, Inflater inflater, int bufferSize)
		{
		}

		protected void Fill()
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

		public override void Write(byte[] buffer, int offset, int count)
		{
		}

		public override void WriteByte(byte value)
		{
		}

		public override IAsyncResult BeginWrite(byte[] buffer, int offset, int count, AsyncCallback callback, object state)
		{
			return null;
		}

		public override void Close()
		{
		}

		public override int Read(byte[] buffer, int offset, int count)
		{
			return 0;
		}
	}
}
