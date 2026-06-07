using System;
using System.Collections;
using System.IO;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using ICSharpCode.SharpZipLib.Core;

namespace ICSharpCode.SharpZipLib.Zip
{
	public class ZipFile : IEnumerable, IDisposable
	{
		public delegate void KeysRequiredEventHandler(object sender, KeysRequiredEventArgs e);

		[Flags]
		private enum HeaderTest
		{
			Extract = 1,
			Header = 2
		}

		private enum UpdateCommand
		{
			Copy = 0,
			Modify = 1,
			Add = 2
		}

		private class UpdateComparer : IComparer
		{
			public int Compare(object x, object y)
			{
				return 0;
			}
		}

		private class ZipUpdate
		{
			private ZipEntry entry_;

			private ZipEntry outEntry_;

			private UpdateCommand command_;

			private IStaticDataSource dataSource_;

			private string filename_;

			private long sizePatchOffset_;

			private long crcPatchOffset_;

			private long _offsetBasedSize;

			public ZipEntry Entry => null;

			public ZipEntry OutEntry => null;

			public UpdateCommand Command => default(UpdateCommand);

			public string Filename => null;

			public long SizePatchOffset
			{
				get
				{
					return 0L;
				}
				set
				{
				}
			}

			public long CrcPatchOffset
			{
				get
				{
					return 0L;
				}
				set
				{
				}
			}

			public long OffsetBasedSize
			{
				get
				{
					return 0L;
				}
				set
				{
				}
			}

			public ZipUpdate(string fileName, ZipEntry entry)
			{
			}

			[Obsolete]
			public ZipUpdate(string fileName, string entryName, CompressionMethod compressionMethod)
			{
			}

			[Obsolete]
			public ZipUpdate(string fileName, string entryName)
			{
			}

			[Obsolete]
			public ZipUpdate(IStaticDataSource dataSource, string entryName, CompressionMethod compressionMethod)
			{
			}

			public ZipUpdate(IStaticDataSource dataSource, ZipEntry entry)
			{
			}

			public ZipUpdate(ZipEntry original, ZipEntry updated)
			{
			}

			public ZipUpdate(UpdateCommand command, ZipEntry entry)
			{
			}

			public ZipUpdate(ZipEntry entry)
			{
			}

			public Stream GetSource()
			{
				return null;
			}
		}

		private class ZipString
		{
			private string comment_;

			private byte[] rawComment_;

			private bool isSourceString_;

			public bool IsSourceString => false;

			public int RawLength => 0;

			public byte[] RawComment => null;

			public ZipString(string comment)
			{
			}

			public ZipString(byte[] rawString)
			{
			}

			public void Reset()
			{
			}

			private void MakeTextAvailable()
			{
			}

			private void MakeBytesAvailable()
			{
			}

			public static implicit operator string(ZipString zipString)
			{
				return null;
			}
		}

		private class ZipEntryEnumerator : IEnumerator
		{
			private ZipEntry[] array;

			private int index;

			public object Current => null;

			public ZipEntryEnumerator(ZipEntry[] entries)
			{
			}

			public void Reset()
			{
			}

			public bool MoveNext()
			{
				return false;
			}
		}

		private class UncompressedStream : Stream
		{
			private Stream baseStream_;

			public override bool CanRead => false;

			public override bool CanWrite => false;

			public override bool CanSeek => false;

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

			public UncompressedStream(Stream baseStream)
			{
			}

			public override void Close()
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

			public override void Write(byte[] buffer, int offset, int count)
			{
			}
		}

		private class PartialInputStream : Stream
		{
			private ZipFile zipFile_;

			private Stream baseStream_;

			private long start_;

			private long length_;

			private long readPos_;

			private long end_;

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

			public override long Length => 0L;

			public override bool CanWrite => false;

			public override bool CanSeek => false;

			public override bool CanRead => false;

			public override bool CanTimeout => false;

			public PartialInputStream(ZipFile zipFile, long start, long length)
			{
			}

			public override int ReadByte()
			{
				return 0;
			}

			public override void Close()
			{
			}

			public override int Read(byte[] buffer, int offset, int count)
			{
				return 0;
			}

			public override void Write(byte[] buffer, int offset, int count)
			{
			}

			public override void SetLength(long value)
			{
			}

			public override long Seek(long offset, SeekOrigin origin)
			{
				return 0L;
			}

			public override void Flush()
			{
			}
		}

		private const int DefaultBufferSize = 4096;

		public KeysRequiredEventHandler KeysRequired;

		private bool isDisposed_;

		private string name_;

		private string comment_;

		private string rawPassword_;

		private Stream baseStream_;

		private bool isStreamOwner;

		private long offsetOfFirstEntry;

		private ZipEntry[] entries_;

		private byte[] key;

		private bool isNewArchive_;

		private UseZip64 useZip64_;

		private ArrayList updates_;

		private long updateCount_;

		private Hashtable updateIndex_;

		private IArchiveStorage archiveStorage_;

		private IDynamicDataSource updateDataSource_;

		private bool contentsEdited_;

		private int bufferSize_;

		private byte[] copyBuffer_;

		private ZipString newComment_;

		private bool commentEdited_;

		private IEntryFactory updateEntryFactory_;

		private byte[] Key
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public string Password
		{
			set
			{
			}
		}

		private bool HaveKeys => false;

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

		public bool IsEmbeddedArchive => false;

		public bool IsNewArchive => false;

		public string ZipFileComment => null;

		public string Name => null;

		[Obsolete("Use the Count property instead")]
		public int Size => 0;

		public long Count => 0L;

		[IndexerName("EntryByIndex")]
		public ZipEntry this[int index] => null;

		public INameTransform NameTransform
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public IEntryFactory EntryFactory
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public int BufferSize
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public bool IsUpdating => false;

		public UseZip64 UseZip64
		{
			get
			{
				return default(UseZip64);
			}
			set
			{
			}
		}

		private void OnKeysRequired(string fileName)
		{
		}

		public ZipFile(string name)
		{
		}

		public ZipFile(FileStream file)
		{
		}

		public ZipFile(Stream stream)
		{
		}

		internal ZipFile()
		{
		}

		~ZipFile()
		{
		}

		public void Close()
		{
		}

		public static ZipFile Create(string fileName)
		{
			return null;
		}

		public static ZipFile Create(Stream outStream)
		{
			return null;
		}

		public IEnumerator GetEnumerator()
		{
			return null;
		}

		public int FindEntry(string name, bool ignoreCase)
		{
			return 0;
		}

		public ZipEntry GetEntry(string name)
		{
			return null;
		}

		public Stream GetInputStream(ZipEntry entry)
		{
			return null;
		}

		public Stream GetInputStream(long entryIndex)
		{
			return null;
		}

		public bool TestArchive(bool testData)
		{
			return false;
		}

		public bool TestArchive(bool testData, TestStrategy strategy, ZipTestResultHandler resultHandler)
		{
			return false;
		}

		private long TestLocalHeader(ZipEntry entry, HeaderTest tests)
		{
			return 0L;
		}

		public void BeginUpdate(IArchiveStorage archiveStorage, IDynamicDataSource dataSource)
		{
		}

		public void BeginUpdate(IArchiveStorage archiveStorage)
		{
		}

		public void BeginUpdate()
		{
		}

		public void CommitUpdate()
		{
		}

		public void AbortUpdate()
		{
		}

		public void SetComment(string comment)
		{
		}

		private void AddUpdate(ZipUpdate update)
		{
		}

		public void Add(string fileName, CompressionMethod compressionMethod, bool useUnicodeText)
		{
		}

		public void Add(string fileName, CompressionMethod compressionMethod)
		{
		}

		public void Add(string fileName)
		{
		}

		public void Add(string fileName, string entryName)
		{
		}

		public void Add(IStaticDataSource dataSource, string entryName)
		{
		}

		public void Add(IStaticDataSource dataSource, string entryName, CompressionMethod compressionMethod)
		{
		}

		public void Add(IStaticDataSource dataSource, string entryName, CompressionMethod compressionMethod, bool useUnicodeText)
		{
		}

		public void Add(ZipEntry entry)
		{
		}

		public void AddDirectory(string directoryName)
		{
		}

		public bool Delete(string fileName)
		{
			return false;
		}

		public void Delete(ZipEntry entry)
		{
		}

		private void WriteLEShort(int value)
		{
		}

		private void WriteLEUshort(ushort value)
		{
		}

		private void WriteLEInt(int value)
		{
		}

		private void WriteLEUint(uint value)
		{
		}

		private void WriteLeLong(long value)
		{
		}

		private void WriteLEUlong(ulong value)
		{
		}

		private void WriteLocalEntryHeader(ZipUpdate update)
		{
		}

		private int WriteCentralDirectoryHeader(ZipEntry entry)
		{
			return 0;
		}

		private void PostUpdateCleanup()
		{
		}

		private string GetTransformedFileName(string name)
		{
			return null;
		}

		private string GetTransformedDirectoryName(string name)
		{
			return null;
		}

		private byte[] GetBuffer()
		{
			return null;
		}

		private void CopyDescriptorBytes(ZipUpdate update, Stream dest, Stream source)
		{
		}

		private void CopyBytes(ZipUpdate update, Stream destination, Stream source, long bytesToCopy, bool updateCrc)
		{
		}

		private int GetDescriptorSize(ZipUpdate update)
		{
			return 0;
		}

		private void CopyDescriptorBytesDirect(ZipUpdate update, Stream stream, ref long destinationPosition, long sourcePosition)
		{
		}

		private void CopyEntryDataDirect(ZipUpdate update, Stream stream, bool updateCrc, ref long destinationPosition, ref long sourcePosition)
		{
		}

		private int FindExistingUpdate(ZipEntry entry)
		{
			return 0;
		}

		private int FindExistingUpdate(string fileName)
		{
			return 0;
		}

		private Stream GetOutputStream(ZipEntry entry)
		{
			return null;
		}

		private void AddEntry(ZipFile workFile, ZipUpdate update)
		{
		}

		private void ModifyEntry(ZipFile workFile, ZipUpdate update)
		{
		}

		private void CopyEntryDirect(ZipFile workFile, ZipUpdate update, ref long destinationPosition)
		{
		}

		private void CopyEntry(ZipFile workFile, ZipUpdate update)
		{
		}

		private void Reopen(Stream source)
		{
		}

		private void Reopen()
		{
		}

		private void UpdateCommentOnly()
		{
		}

		private void RunUpdates()
		{
		}

		private void CheckUpdating()
		{
		}

		void IDisposable.Dispose()
		{
		}

		private void DisposeInternal(bool disposing)
		{
		}

		protected virtual void Dispose(bool disposing)
		{
		}

		private ushort ReadLEUshort()
		{
			return 0;
		}

		private uint ReadLEUint()
		{
			return 0u;
		}

		private ulong ReadLEUlong()
		{
			return 0uL;
		}

		private long LocateBlockWithSignature(int signature, long endLocation, int minimumBlockSize, int maximumVariableData)
		{
			return 0L;
		}

		private void ReadEntries()
		{
		}

		private long LocateEntry(ZipEntry entry)
		{
			return 0L;
		}

		private Stream CreateAndInitDecryptionStream(Stream baseStream, ZipEntry entry)
		{
			return null;
		}

		private Stream CreateAndInitEncryptionStream(Stream baseStream, ZipEntry entry)
		{
			return null;
		}

		private static void CheckClassicPassword(CryptoStream classicCryptoStream, ZipEntry entry)
		{
		}

		private static void WriteEncryptionHeader(Stream stream, long crcValue)
		{
		}
	}
}
