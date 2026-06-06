using System.IO;
using System.Text;
using Pathfinding.Ionic.Crc;

namespace Pathfinding.Ionic.Zip
{
	public class ZipInputStream : Stream
	{
		private Stream _inputStream;

		private Encoding _provisionalAlternateEncoding;

		private ZipEntry _currentEntry;

		private bool _firstEntry;

		private bool _needSetup;

		private ZipContainer _container;

		private CrcCalculatorStream _crcStream;

		private long _LeftToRead;

		internal string _Password;

		private long _endOfEntry;

		private string _name;

		private bool _leaveUnderlyingStreamOpen;

		private bool _closed;

		private bool _findRequired;

		private bool _exceptionPending;

		public Encoding ProvisionalAlternateEncoding
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public int CodecBufferSize { get; set; }

		public string Password
		{
			set
			{
			}
		}

		internal Stream ReadStream => null;

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

		public ZipInputStream(Stream stream)
		{
		}

		public ZipInputStream(string fileName)
		{
		}

		public ZipInputStream(Stream stream, bool leaveOpen)
		{
		}

		private void _Init(Stream stream, bool leaveOpen, string name)
		{
		}

		public override string ToString()
		{
			return null;
		}

		private void SetupStream()
		{
		}

		public override int Read(byte[] buffer, int offset, int count)
		{
			return 0;
		}

		public ZipEntry GetNextEntry()
		{
			return null;
		}

		protected override void Dispose(bool disposing)
		{
		}

		public override void Flush()
		{
		}

		public override void Write(byte[] buffer, int offset, int count)
		{
		}

		public override long Seek(long offset, SeekOrigin origin)
		{
			return 0L;
		}

		public override void SetLength(long value)
		{
		}
	}
}
