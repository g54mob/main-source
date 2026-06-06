using System.IO;

namespace Pathfinding.Ionic.Zip
{
	internal class ZipSegmentedStream : Stream
	{
		private enum RwMode
		{
			None = 0,
			ReadOnly = 1,
			Write = 2
		}

		private RwMode rwMode;

		private bool _exceptionPending;

		private string _baseName;

		private string _baseDir;

		private string _currentName;

		private string _currentTempName;

		private uint _currentDiskNumber;

		private uint _maxDiskNumber;

		private int _maxSegmentSize;

		private Stream _innerStream;

		public bool ContiguousWrite { get; set; }

		public uint CurrentSegment
		{
			get
			{
				return 0u;
			}
			private set
			{
			}
		}

		public string CurrentName => null;

		public string CurrentTempName => null;

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

		private ZipSegmentedStream()
		{
		}

		public static ZipSegmentedStream ForReading(string name, uint initialDiskNumber, uint maxDiskNumber)
		{
			return null;
		}

		public static ZipSegmentedStream ForWriting(string name, int maxSegmentSize)
		{
			return null;
		}

		public static Stream ForUpdate(string name, uint diskNumber)
		{
			return null;
		}

		private string _NameForSegment(uint diskNumber)
		{
			return null;
		}

		public uint ComputeSegment(int length)
		{
			return 0u;
		}

		public override string ToString()
		{
			return null;
		}

		private void _SetReadStream()
		{
		}

		public override int Read(byte[] buffer, int offset, int count)
		{
			return 0;
		}

		private void _SetWriteStream(uint increment)
		{
		}

		public override void Write(byte[] buffer, int offset, int count)
		{
		}

		public long TruncateBackward(uint diskNumber, long offset)
		{
			return 0L;
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

		protected override void Dispose(bool disposing)
		{
		}
	}
}
