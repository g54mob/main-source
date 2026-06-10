using System;
using System.IO;
using System.Text;

namespace ICSharpCode.SharpZipLib.Tar
{
	public class TarOutputStream : Stream
	{
		private long currBytes;

		private int assemblyBufferLength;

		private bool isClosed;

		protected long currSize;

		protected byte[] blockBuffer;

		protected byte[] assemblyBuffer;

		protected TarBuffer buffer;

		protected Stream outputStream;

		protected Encoding nameEncoding;

		public bool IsStreamOwner
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

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

		public int RecordSize => 0;

		private bool IsEntryOpen => false;

		[Obsolete("No Encoding for Name field is specified, any non-ASCII bytes will be discarded")]
		public TarOutputStream(Stream outputStream)
		{
		}

		public TarOutputStream(Stream outputStream, Encoding nameEncoding)
		{
		}

		[Obsolete("No Encoding for Name field is specified, any non-ASCII bytes will be discarded")]
		public TarOutputStream(Stream outputStream, int blockFactor)
		{
		}

		public TarOutputStream(Stream outputStream, int blockFactor, Encoding nameEncoding)
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

		public void Finish()
		{
		}

		protected override void Dispose(bool disposing)
		{
		}

		[Obsolete("Use RecordSize property instead")]
		public int GetRecordSize()
		{
			return 0;
		}

		public void PutNextEntry(TarEntry entry)
		{
		}

		public void CloseEntry()
		{
		}

		public override void WriteByte(byte value)
		{
		}

		public override void Write(byte[] buffer, int offset, int count)
		{
		}

		private void WriteEofBlock()
		{
		}
	}
}
