using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using Pathfinding.Ionic.Crc;
using Pathfinding.Ionic.Zlib;

namespace Pathfinding.Ionic.Zip
{
	[ClassInterface(ClassInterfaceType.AutoDispatch)]
	[ComVisible(true)]
	[Guid("ebc25cf6-9120-4283-b972-0e5520d00004")]
	public class ZipEntry
	{
		private class CopyHelper
		{
			private static Regex re;

			private static int callCount;

			internal static string AppendCopyToFileName(string f)
			{
				return null;
			}
		}

		private delegate T Func<T>();

		private short _VersionMadeBy;

		private short _InternalFileAttrs;

		private int _ExternalFileAttrs;

		private short _filenameLength;

		private short _extraFieldLength;

		private short _commentLength;

		private Stream _inputDecryptorStream;

		private int _readExtraDepth;

		private object _outputLock;

		private ZipCrypto _zipCrypto_forExtract;

		private ZipCrypto _zipCrypto_forWrite;

		internal DateTime _LastModified;

		private DateTime _Mtime;

		private DateTime _Atime;

		private DateTime _Ctime;

		private bool _ntfsTimesAreSet;

		private bool _emitNtfsTimes;

		private bool _emitUnixTimes;

		private bool _TrimVolumeFromFullyQualifiedPaths;

		internal string _LocalFileName;

		private string _FileNameInArchive;

		internal short _VersionNeeded;

		internal short _BitField;

		internal short _CompressionMethod;

		private short _CompressionMethod_FromZipFile;

		private CompressionLevel _CompressionLevel;

		internal string _Comment;

		private bool _IsDirectory;

		private byte[] _CommentBytes;

		internal long _CompressedSize;

		internal long _CompressedFileDataSize;

		internal long _UncompressedSize;

		internal int _TimeBlob;

		private bool _crcCalculated;

		internal int _Crc32;

		internal byte[] _Extra;

		private bool _metadataChanged;

		private bool _restreamRequiredOnSave;

		private bool _sourceIsEncrypted;

		private bool _skippedDuringSave;

		private uint _diskNumber;

		private static Encoding ibm437;

		private Encoding _actualEncoding;

		internal ZipContainer _container;

		private long __FileDataPosition;

		private byte[] _EntryHeader;

		internal long _RelativeOffsetOfLocalHeader;

		private long _future_ROLH;

		private long _TotalEntrySize;

		private int _LengthOfHeader;

		private int _LengthOfTrailer;

		internal bool _InputUsesZip64;

		private uint _UnsupportedAlgorithmId;

		internal string _Password;

		internal ZipEntrySource _Source;

		internal EncryptionAlgorithm _Encryption;

		internal EncryptionAlgorithm _Encryption_FromZipFile;

		internal byte[] _WeakEncryptionHeader;

		internal Stream _archiveStream;

		private Stream _sourceStream;

		private long? _sourceStreamOriginalPosition;

		private bool _sourceWasJitProvided;

		private bool _ioOperationCanceled;

		private bool _presumeZip64;

		private bool? _entryRequiresZip64;

		private bool? _OutputUsesZip64;

		private bool _IsText;

		private ZipEntryTimestamp _timestamp;

		private static DateTime _unixEpoch;

		private static DateTime _win32Epoch;

		private static DateTime _zeroHour;

		private WriteDelegate _WriteDelegate;

		private OpenDelegate _OpenDelegate;

		private CloseDelegate _CloseDelegate;

		internal bool AttributesIndicateDirectory => false;

		public string Info => null;

		private string UnsupportedAlgorithm => null;

		private string UnsupportedCompressionMethod => null;

		public DateTime LastModified
		{
			get
			{
				return default(DateTime);
			}
			set
			{
			}
		}

		private int BufferSize => 0;

		public DateTime ModifiedTime
		{
			get
			{
				return default(DateTime);
			}
			set
			{
			}
		}

		public DateTime AccessedTime
		{
			get
			{
				return default(DateTime);
			}
			set
			{
			}
		}

		public DateTime CreationTime
		{
			get
			{
				return default(DateTime);
			}
			set
			{
			}
		}

		public bool EmitTimesInWindowsFormatWhenSaving
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool EmitTimesInUnixFormatWhenSaving
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public ZipEntryTimestamp Timestamp => default(ZipEntryTimestamp);

		public FileAttributes Attributes
		{
			get
			{
				return default(FileAttributes);
			}
			set
			{
			}
		}

		internal string LocalFileName => null;

		public string FileName
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public Stream InputStream
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public bool InputStreamWasJitProvided => false;

		public ZipEntrySource Source => default(ZipEntrySource);

		public short VersionNeeded => 0;

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

		public bool? RequiresZip64 => null;

		public bool? OutputUsedZip64 => null;

		public short BitField => 0;

		public CompressionMethod CompressionMethod
		{
			get
			{
				return default(CompressionMethod);
			}
			set
			{
			}
		}

		public CompressionLevel CompressionLevel
		{
			get
			{
				return default(CompressionLevel);
			}
			set
			{
			}
		}

		public long CompressedSize => 0L;

		public long UncompressedSize => 0L;

		public double CompressionRatio => 0.0;

		public int Crc => 0;

		public bool IsDirectory => false;

		public bool UsesEncryption => false;

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

		public string Password
		{
			private get
			{
				return null;
			}
			set
			{
			}
		}

		internal bool IsChanged => false;

		public ExtractExistingFileAction ExtractExistingFile { get; set; }

		public ZipErrorAction ZipErrorAction { get; set; }

		public bool IncludedInMostRecentSave => false;

		public SetCompressionCallback SetCompression { get; set; }

		[Obsolete("Beginning with v1.9.1.6 of DotNetZip, this property is obsolete.  It will be removed in a future version of the library. Your applications should  use AlternateEncoding and AlternateEncodingUsage instead.")]
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

		[Obsolete("This property is obsolete since v1.9.1.6. Use AlternateEncoding and AlternateEncodingUsage instead.", true)]
		public Encoding ProvisionalAlternateEncoding { get; set; }

		public Encoding AlternateEncoding { get; set; }

		public ZipOption AlternateEncodingUsage { get; set; }

		public bool IsText
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		internal Stream ArchiveStream => null;

		internal long FileDataPosition => 0L;

		private int LengthOfHeader => 0;

		internal void ResetDirEntry()
		{
		}

		internal static ZipEntry ReadDirEntry(ZipFile zf, Dictionary<string, object> previouslySeen)
		{
			return null;
		}

		internal static bool IsNotValidZipDirEntrySig(int signature)
		{
			return false;
		}

		public void Extract()
		{
		}

		public void Extract(ExtractExistingFileAction extractExistingFile)
		{
		}

		public void Extract(Stream stream)
		{
		}

		public void Extract(string baseDirectory)
		{
		}

		public void Extract(string baseDirectory, ExtractExistingFileAction extractExistingFile)
		{
		}

		public void ExtractWithPassword(string password)
		{
		}

		public void ExtractWithPassword(string baseDirectory, string password)
		{
		}

		public void ExtractWithPassword(ExtractExistingFileAction extractExistingFile, string password)
		{
		}

		public void ExtractWithPassword(string baseDirectory, ExtractExistingFileAction extractExistingFile, string password)
		{
		}

		public void ExtractWithPassword(Stream stream, string password)
		{
		}

		public CrcCalculatorStream OpenReader()
		{
			return null;
		}

		public CrcCalculatorStream OpenReader(string password)
		{
			return null;
		}

		internal CrcCalculatorStream InternalOpenReader(string password)
		{
			return null;
		}

		private void OnExtractProgress(long bytesWritten, long totalBytesToWrite)
		{
		}

		private void OnBeforeExtract(string path)
		{
		}

		private void OnAfterExtract(string path)
		{
		}

		private void OnExtractExisting(string path)
		{
		}

		private static void ReallyDelete(string fileName)
		{
		}

		private void WriteStatus(string format, params object[] args)
		{
		}

		private void InternalExtract(string baseDir, Stream outstream, string password)
		{
		}

		internal void VerifyCrcAfterExtract(int actualCrc32)
		{
		}

		private int CheckExtractExistingFile(string baseDir, string targetFileName)
		{
			return 0;
		}

		private void _CheckRead(int nbytes)
		{
		}

		private int ExtractOne(Stream output)
		{
			return 0;
		}

		internal Stream GetExtractDecompressor(Stream input2)
		{
			return null;
		}

		internal Stream GetExtractDecryptor(Stream input)
		{
			return null;
		}

		internal void _SetTimes(string fileOrDirectory, bool isFile)
		{
		}

		internal void ValidateEncryption()
		{
		}

		private void ValidateCompression()
		{
		}

		private void SetupCryptoForExtract(string password)
		{
		}

		private bool ValidateOutput(string basedir, Stream outstream, out string outFileName)
		{
			outFileName = null;
			return false;
		}

		private void ReadExtraField()
		{
		}

		private static bool ReadHeader(ZipEntry ze, Encoding defaultEncoding)
		{
			return false;
		}

		internal static int ReadWeakEncryptionHeader(Stream s, byte[] buffer)
		{
			return 0;
		}

		private static bool IsNotValidSig(int signature)
		{
			return false;
		}

		internal static ZipEntry ReadEntry(ZipContainer zc, bool first)
		{
			return null;
		}

		internal static void HandlePK00Prefix(Stream s)
		{
		}

		private static void HandleUnexpectedDataDescriptor(ZipEntry entry)
		{
		}

		internal static int FindExtraFieldSegment(byte[] extra, int offx, ushort targetHeaderId)
		{
			return 0;
		}

		internal int ProcessExtraField(Stream s, short extraFieldLength)
		{
			return 0;
		}

		private int ProcessExtraFieldPkwareStrongEncryption(byte[] Buffer, int j)
		{
			return 0;
		}

		private int ProcessExtraFieldZip64(byte[] buffer, int j, short dataSize, long posn)
		{
			return 0;
		}

		private int ProcessExtraFieldInfoZipTimes(byte[] buffer, int j, short dataSize, long posn)
		{
			return 0;
		}

		private int ProcessExtraFieldUnixTimes(byte[] buffer, int j, short dataSize, long posn)
		{
			return 0;
		}

		private int ProcessExtraFieldWindowsTimes(byte[] buffer, int j, short dataSize, long posn)
		{
			return 0;
		}

		internal void WriteCentralDirectoryEntry(Stream s)
		{
		}

		private byte[] ConstructExtraField(bool forCentralDirectory)
		{
			return null;
		}

		private string NormalizeFileName()
		{
			return null;
		}

		private byte[] GetEncodedFileNameBytes()
		{
			return null;
		}

		private bool WantReadAgain()
		{
			return false;
		}

		private void MaybeUnsetCompressionMethodForWriting(int cycle)
		{
		}

		internal void WriteHeader(Stream s, int cycle)
		{
		}

		private int FigureCrc32()
		{
			return 0;
		}

		private void PrepSourceStream()
		{
		}

		internal void CopyMetaData(ZipEntry source)
		{
		}

		private void OnWriteBlock(long bytesXferred, long totalBytesToXfer)
		{
		}

		private void _WriteEntryData(Stream s)
		{
		}

		private long SetInputAndFigureFileLength(ref Stream input)
		{
			return 0L;
		}

		internal void FinishOutputStream(Stream s, CountingStream entryCounter, Stream encryptor, Stream compressor, CrcCalculatorStream output)
		{
		}

		internal void PostProcessOutput(Stream s)
		{
		}

		private void SetZip64Flags()
		{
		}

		internal void PrepOutputStream(Stream s, long streamLength, out CountingStream outputCounter, out Stream encryptor, out Stream compressor, out CrcCalculatorStream output)
		{
			outputCounter = null;
			encryptor = null;
			compressor = null;
			output = null;
		}

		private Stream MaybeApplyCompression(Stream s, long streamLength)
		{
			return null;
		}

		private Stream MaybeApplyEncryption(Stream s)
		{
			return null;
		}

		private void OnZipErrorWhileSaving(Exception e)
		{
		}

		internal void Write(Stream s)
		{
		}

		internal void StoreRelativeOffset()
		{
		}

		internal void NotifySaveComplete()
		{
		}

		internal void WriteSecurityMetadata(Stream outstream)
		{
		}

		private void CopyThroughOneEntry(Stream outStream)
		{
		}

		private void CopyThroughWithRecompute(Stream outstream)
		{
		}

		private void CopyThroughWithNoChange(Stream outstream)
		{
		}

		[Conditional("Trace")]
		private void TraceWriteLine(string format, params object[] varParams)
		{
		}

		public void SetEntryTimes(DateTime created, DateTime accessed, DateTime modified)
		{
		}

		internal static string NameInArchive(string filename, string directoryPathInArchive)
		{
			return null;
		}

		internal static ZipEntry CreateFromNothing(string nameInArchive)
		{
			return null;
		}

		internal static ZipEntry CreateFromFile(string filename, string nameInArchive)
		{
			return null;
		}

		internal static ZipEntry CreateForStream(string entryName, Stream s)
		{
			return null;
		}

		internal static ZipEntry CreateForWriter(string entryName, WriteDelegate d)
		{
			return null;
		}

		internal static ZipEntry CreateForJitStreamProvider(string nameInArchive, OpenDelegate opener, CloseDelegate closer)
		{
			return null;
		}

		internal static ZipEntry CreateForZipOutputStream(string nameInArchive)
		{
			return null;
		}

		private static ZipEntry Create(string nameInArchive, ZipEntrySource source, object arg1, object arg2)
		{
			return null;
		}

		internal void MarkAsDirectory()
		{
		}

		public override string ToString()
		{
			return null;
		}

		private void SetFdpLoh()
		{
		}

		internal static int GetLengthOfCryptoHeaderBytes(EncryptionAlgorithm a)
		{
			return 0;
		}
	}
}
