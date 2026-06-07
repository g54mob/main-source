using System;
using System.IO;

namespace ICSharpCode.SharpZipLib.Tar
{
	public class TarInputStream : Stream
	{
		public interface IEntryFactory
		{
			TarEntry CreateEntry(string name);

			TarEntry CreateEntryFromFile(string fileName);

			TarEntry CreateEntry(byte[] headerBuffer);
		}

		public class EntryFactoryAdapter : IEntryFactory
		{
			public TarEntry CreateEntry(string name)
			{
				return null;
			}

			public TarEntry CreateEntryFromFile(string fileName)
			{
				return null;
			}

			public TarEntry CreateEntry(byte[] headerBuffer)
			{
				return null;
			}
		}

		protected bool hasHitEOF;

		protected long entrySize;

		protected long entryOffset;

		protected byte[] readBuffer;

		protected TarBuffer tarBuffer;

		private TarEntry currentEntry;

		protected IEntryFactory entryFactory;

		private readonly Stream inputStream;

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

		public long Available => 0L;

		public bool IsMarkSupported => false;

		public TarInputStream(Stream inputStream)
		{
		}

		public TarInputStream(Stream inputStream, int blockFactor)
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

		public override int ReadByte()
		{
			return 0;
		}

		public override int Read(byte[] buffer, int offset, int count)
		{
			return 0;
		}

		public override void Close()
		{
		}

		public void SetEntryFactory(IEntryFactory factory)
		{
		}

		[Obsolete("Use RecordSize property instead")]
		public int GetRecordSize()
		{
			return 0;
		}

		public void Skip(long skipCount)
		{
		}

		public void Mark(int markLimit)
		{
		}

		public void Reset()
		{
		}

		public TarEntry GetNextEntry()
		{
			return null;
		}

		public void CopyEntryContents(Stream outputStream)
		{
		}

		private void SkipToNextEntry()
		{
		}
	}
}
