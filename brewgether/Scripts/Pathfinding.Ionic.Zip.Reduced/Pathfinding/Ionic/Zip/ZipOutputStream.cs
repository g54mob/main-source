using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Pathfinding.Ionic.Crc;
using Pathfinding.Ionic.Zlib;

namespace Pathfinding.Ionic.Zip
{
	public class ZipOutputStream : Stream
	{
		private EncryptionAlgorithm _encryption;

		private ZipEntryTimestamp _timestamp;

		internal string _password;

		private string _comment;

		private Stream _outputStream;

		private ZipEntry _currentEntry;

		internal Zip64Option _zip64;

		private Dictionary<string, ZipEntry> _entriesWritten;

		private int _entryCount;

		private ZipOption _alternateEncodingUsage;

		private Encoding _alternateEncoding;

		private bool _leaveUnderlyingStreamOpen;

		private bool _disposed;

		private bool _exceptionPending;

		private bool _anyEntriesUsedZip64;

		private bool _directoryNeededZip64;

		private CountingStream _outputCounter;

		private Stream _encryptor;

		private Stream _deflater;

		private CrcCalculatorStream _entryOutputStream;

		private bool _needToWriteEntryHeader;

		private string _name;

		private bool _DontIgnoreCase;

		internal ParallelDeflateOutputStream ParallelDeflater;

		private long _ParallelDeflateThreshold;

		private int _maxBufferPairs;

		public string Password
		{
			set
			{
			}
		}

		public EncryptionAlgorithm Encryption
		{
			get
			{
				return default(EncryptionAlgorithm);
			}
			set
			{
			}
		}

		public int CodecBufferSize { get; set; }

		public CompressionStrategy Strategy { get; set; }

		public ZipEntryTimestamp Timestamp
		{
			get
			{
				return default(ZipEntryTimestamp);
			}
			set
			{
			}
		}

		public CompressionLevel CompressionLevel { get; set; }

		public CompressionMethod CompressionMethod { get; set; }

		public string Comment
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public Zip64Option EnableZip64
		{
			get
			{
				return default(Zip64Option);
			}
			set
			{
			}
		}

		public bool OutputUsedZip64 => false;

		public bool IgnoreCase
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		[Obsolete("Beginning with v1.9.1.6 of DotNetZip, this property is obsolete. It will be removed in a future version of the library. Use AlternateEncoding and AlternateEncodingUsage instead.")]
		public bool UseUnicodeAsNecessary
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		[Obsolete("use AlternateEncoding and AlternateEncodingUsage instead.")]
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

		public Encoding AlternateEncoding
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public ZipOption AlternateEncodingUsage
		{
			get
			{
				return default(ZipOption);
			}
			set
			{
			}
		}

		public static Encoding DefaultEncoding => null;

		public long ParallelDeflateThreshold
		{
			get
			{
				return 0L;
			}
			set
			{
			}
		}

		public int ParallelDeflateMaxBufferPairs
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		internal Stream OutputStream => null;

		internal string Name => null;

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

		public ZipOutputStream(Stream stream)
		{
		}

		public ZipOutputStream(string fileName)
		{
		}

		public ZipOutputStream(Stream stream, bool leaveOpen)
		{
		}

		private void _Init(Stream stream, bool leaveOpen, string name)
		{
		}

		public override string ToString()
		{
			return null;
		}

		private void InsureUniqueEntry(ZipEntry ze1)
		{
		}

		public bool ContainsEntry(string name)
		{
			return false;
		}

		public override void Write(byte[] buffer, int offset, int count)
		{
		}

		public ZipEntry PutNextEntry(string entryName)
		{
			return null;
		}

		private void _InitiateCurrentEntry(bool finishing)
		{
		}

		private void _FinishCurrentEntry()
		{
		}

		protected override void Dispose(bool disposing)
		{
		}

		public override void Flush()
		{
		}

		public override int Read(byte[] buffer, int offset, int count)
		{
			return 0;
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
