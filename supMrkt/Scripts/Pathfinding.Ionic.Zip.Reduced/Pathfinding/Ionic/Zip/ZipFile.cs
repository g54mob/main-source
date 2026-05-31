using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using Pathfinding.Ionic.Zlib;

namespace Pathfinding.Ionic.Zip
{
	[Guid("ebc25cf6-9120-4283-b972-0e5520d00005")]
	[ClassInterface(ClassInterfaceType.AutoDispatch)]
	[ComVisible(true)]
	public class ZipFile : IEnumerable<ZipEntry>, IDisposable, IEnumerable
	{
		private long _lengthOfReadStream;

		private TextWriter _StatusMessageTextWriter;

		private bool _CaseSensitiveRetrieval;

		private Stream _readstream;

		private Stream _writestream;

		private ushort _versionMadeBy;

		private ushort _versionNeededToExtract;

		private uint _diskNumberWithCd;

		private int _maxOutputSegmentSize;

		private uint _numberOfSegmentsForMostRecentSave;

		private ZipErrorAction _zipErrorAction;

		private bool _disposed;

		private Dictionary<string, ZipEntry> _entries;

		private List<ZipEntry> _zipEntriesAsList;

		private string _name;

		private string _readName;

		private string _Comment;

		internal string _Password;

		private bool _emitNtfsTimes;

		private bool _emitUnixTimes;

		private CompressionStrategy _Strategy;

		private CompressionMethod _compressionMethod;

		private bool _fileAlreadyExists;

		private string _temporaryFileName;

		private bool _contentsChanged;

		private bool _hasBeenSaved;

		private string _TempFileFolder;

		private bool _ReadStreamIsOurs;

		private object LOCK;

		private bool _saveOperationCanceled;

		private bool _extractOperationCanceled;

		private bool _addOperationCanceled;

		private EncryptionAlgorithm _Encryption;

		private bool _JustSaved;

		private long _locEndOfCDS;

		private uint _OffsetOfCentralDirectory;

		private long _OffsetOfCentralDirectory64;

		private bool? _OutputUsesZip64;

		internal bool _inExtractAll;

		private static Encoding _defaultEncoding;

		private Encoding _alternateEncoding;

		private ZipOption _alternateEncodingUsage;

		private int _BufferSize;

		internal ParallelDeflateOutputStream ParallelDeflater;

		private long _ParallelDeflateThreshold;

		private int _maxBufferPairs;

		internal Zip64Option _zip64;

		private bool _SavingSfx;

		public static readonly int BufferSizeDefault;

		public string Info => null;

		private string ArchiveNameForEvent => null;

		private long LengthOfReadStream => 0L;

		public bool FullScan { get; set; }

		public bool SortEntriesBeforeSaving { get; set; }

		public bool AddDirectoryWillTraverseReparsePoints { get; set; }

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

		public int CodecBufferSize { get; set; }

		public bool FlattenFoldersOnExtract { get; set; }

		public CompressionStrategy Strategy
		{
			get
			{
				return default(CompressionStrategy);
			}
			set
			{
			}
		}

		public string Name
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public CompressionLevel CompressionLevel { get; set; }

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

		internal bool Verbose => false;

		public bool CaseSensitiveRetrieval
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

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

		public Zip64Option UseZip64WhenSaving
		{
			get
			{
				return default(Zip64Option);
			}
			set
			{
			}
		}

		public bool? RequiresZip64 => null;

		public bool? OutputUsedZip64 => null;

		public bool? InputUsesZip64 => null;

		[Obsolete("use AlternateEncoding instead.")]
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

		public TextWriter StatusMessageTextWriter
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public string TempFileFolder
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
			private get
			{
				return null;
			}
			set
			{
			}
		}

		public ExtractExistingFileAction ExtractExistingFile { get; set; }

		public ZipErrorAction ZipErrorAction
		{
			get
			{
				return default(ZipErrorAction);
			}
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

		public SetCompressionCallback SetCompression { get; set; }

		public int MaxOutputSegmentSize
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public int NumberOfSegmentsForMostRecentSave => 0;

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

		public static Version LibraryVersion => null;

		private List<ZipEntry> ZipEntriesAsList => null;

		public ZipEntry this[int ix] => null;

		public ZipEntry this[string fileName] => null;

		public ICollection<string> EntryFileNames => null;

		public ICollection<ZipEntry> Entries => null;

		public ICollection<ZipEntry> EntriesSorted => null;

		public int Count => 0;

		internal Stream ReadStream => null;

		private Stream WriteStream
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public event EventHandler<SaveProgressEventArgs> SaveProgress
		{
			add
			{
			}
			remove
			{
			}
		}

		public event EventHandler<ReadProgressEventArgs> ReadProgress
		{
			add
			{
			}
			remove
			{
			}
		}

		public event EventHandler<ExtractProgressEventArgs> ExtractProgress
		{
			add
			{
			}
			remove
			{
			}
		}

		public event EventHandler<AddProgressEventArgs> AddProgress
		{
			add
			{
			}
			remove
			{
			}
		}

		public event EventHandler<ZipErrorEventArgs> ZipError
		{
			add
			{
			}
			remove
			{
			}
		}

		public ZipFile(string fileName)
		{
		}

		public ZipFile(string fileName, Encoding encoding)
		{
		}

		public ZipFile()
		{
		}

		public ZipFile(Encoding encoding)
		{
		}

		public ZipFile(string fileName, TextWriter statusMessageWriter)
		{
		}

		public ZipFile(string fileName, TextWriter statusMessageWriter, Encoding encoding)
		{
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return null;
		}

		public ZipEntry AddItem(string fileOrDirectoryName)
		{
			return null;
		}

		public ZipEntry AddItem(string fileOrDirectoryName, string directoryPathInArchive)
		{
			return null;
		}

		public ZipEntry AddFile(string fileName)
		{
			return null;
		}

		public ZipEntry AddFile(string fileName, string directoryPathInArchive)
		{
			return null;
		}

		public void RemoveEntries(ICollection<ZipEntry> entriesToRemove)
		{
		}

		public void RemoveEntries(ICollection<string> entriesToRemove)
		{
		}

		public void AddFiles(IEnumerable<string> fileNames)
		{
		}

		public void UpdateFiles(IEnumerable<string> fileNames)
		{
		}

		public void AddFiles(IEnumerable<string> fileNames, string directoryPathInArchive)
		{
		}

		public void AddFiles(IEnumerable<string> fileNames, bool preserveDirHierarchy, string directoryPathInArchive)
		{
		}

		public void UpdateFiles(IEnumerable<string> fileNames, string directoryPathInArchive)
		{
		}

		public ZipEntry UpdateFile(string fileName)
		{
			return null;
		}

		public ZipEntry UpdateFile(string fileName, string directoryPathInArchive)
		{
			return null;
		}

		public ZipEntry UpdateDirectory(string directoryName)
		{
			return null;
		}

		public ZipEntry UpdateDirectory(string directoryName, string directoryPathInArchive)
		{
			return null;
		}

		public void UpdateItem(string itemName)
		{
		}

		public void UpdateItem(string itemName, string directoryPathInArchive)
		{
		}

		public ZipEntry AddEntry(string entryName, string content)
		{
			return null;
		}

		public ZipEntry AddEntry(string entryName, string content, Encoding encoding)
		{
			return null;
		}

		public ZipEntry AddEntry(string entryName, Stream stream)
		{
			return null;
		}

		public ZipEntry AddEntry(string entryName, WriteDelegate writer)
		{
			return null;
		}

		public ZipEntry AddEntry(string entryName, OpenDelegate opener, CloseDelegate closer)
		{
			return null;
		}

		private ZipEntry _InternalAddEntry(ZipEntry ze)
		{
			return null;
		}

		public ZipEntry UpdateEntry(string entryName, string content)
		{
			return null;
		}

		public ZipEntry UpdateEntry(string entryName, string content, Encoding encoding)
		{
			return null;
		}

		public ZipEntry UpdateEntry(string entryName, WriteDelegate writer)
		{
			return null;
		}

		public ZipEntry UpdateEntry(string entryName, OpenDelegate opener, CloseDelegate closer)
		{
			return null;
		}

		public ZipEntry UpdateEntry(string entryName, Stream stream)
		{
			return null;
		}

		private void RemoveEntryForUpdate(string entryName)
		{
		}

		public ZipEntry AddEntry(string entryName, byte[] byteContent)
		{
			return null;
		}

		public ZipEntry UpdateEntry(string entryName, byte[] byteContent)
		{
			return null;
		}

		public ZipEntry AddDirectory(string directoryName)
		{
			return null;
		}

		public ZipEntry AddDirectory(string directoryName, string directoryPathInArchive)
		{
			return null;
		}

		public ZipEntry AddDirectoryByName(string directoryNameInArchive)
		{
			return null;
		}

		private ZipEntry AddOrUpdateDirectoryImpl(string directoryName, string rootDirectoryPathInArchive, AddOrUpdateAction action)
		{
			return null;
		}

		internal void InternalAddEntry(string name, ZipEntry entry)
		{
		}

		private ZipEntry AddOrUpdateDirectoryImpl(string directoryName, string rootDirectoryPathInArchive, AddOrUpdateAction action, bool recurse, int level)
		{
			return null;
		}

		public static bool CheckZip(string zipFileName)
		{
			return false;
		}

		public static bool CheckZip(string zipFileName, bool fixIfNecessary, TextWriter writer)
		{
			return false;
		}

		public static void FixZipDirectory(string zipFileName)
		{
		}

		public static bool CheckZipPassword(string zipFileName, string password)
		{
			return false;
		}

		internal bool OnSaveBlock(ZipEntry entry, long bytesXferred, long totalBytesToXfer)
		{
			return false;
		}

		private void OnSaveEntry(int current, ZipEntry entry, bool before)
		{
		}

		private void OnSaveEvent(ZipProgressEventType eventFlavor)
		{
		}

		private void OnSaveStarted()
		{
		}

		private void OnSaveCompleted()
		{
		}

		private void OnReadStarted()
		{
		}

		private void OnReadCompleted()
		{
		}

		internal void OnReadBytes(ZipEntry entry)
		{
		}

		internal void OnReadEntry(bool before, ZipEntry entry)
		{
		}

		private void OnExtractEntry(int current, bool before, ZipEntry currentEntry, string path)
		{
		}

		internal bool OnExtractBlock(ZipEntry entry, long bytesWritten, long totalBytesToWrite)
		{
			return false;
		}

		internal bool OnSingleEntryExtract(ZipEntry entry, string path, bool before)
		{
			return false;
		}

		internal bool OnExtractExisting(ZipEntry entry, string path)
		{
			return false;
		}

		private void OnExtractAllCompleted(string path)
		{
		}

		private void OnExtractAllStarted(string path)
		{
		}

		private void OnAddStarted()
		{
		}

		private void OnAddCompleted()
		{
		}

		internal void AfterAddEntry(ZipEntry entry)
		{
		}

		internal bool OnZipErrorSaving(ZipEntry entry, Exception exc)
		{
			return false;
		}

		public void ExtractAll(string path)
		{
		}

		public void ExtractAll(string path, ExtractExistingFileAction extractExistingFile)
		{
		}

		private void _InternalExtractAll(string path, bool overrideExtractExistingProperty)
		{
		}

		public static ZipFile Read(string fileName)
		{
			return null;
		}

		public static ZipFile Read(string fileName, ReadOptions options)
		{
			return null;
		}

		private static ZipFile Read(string fileName, TextWriter statusMessageWriter, Encoding encoding, EventHandler<ReadProgressEventArgs> readProgress)
		{
			return null;
		}

		public static ZipFile Read(Stream zipStream)
		{
			return null;
		}

		public static ZipFile Read(Stream zipStream, ReadOptions options)
		{
			return null;
		}

		private static ZipFile Read(Stream zipStream, TextWriter statusMessageWriter, Encoding encoding, EventHandler<ReadProgressEventArgs> readProgress)
		{
			return null;
		}

		private static void ReadIntoInstance(ZipFile zf)
		{
		}

		private static void Zip64SeekToCentralDirectory(ZipFile zf)
		{
		}

		private static uint ReadFirstFourBytes(Stream s)
		{
			return 0u;
		}

		private static void ReadCentralDirectory(ZipFile zf)
		{
		}

		private static void ReadIntoInstance_Orig(ZipFile zf)
		{
		}

		private static void ReadCentralDirectoryFooter(ZipFile zf)
		{
		}

		private static void ReadZipFileComment(ZipFile zf)
		{
		}

		public static bool IsZipFile(string fileName)
		{
			return false;
		}

		public static bool IsZipFile(string fileName, bool testExtract)
		{
			return false;
		}

		public static bool IsZipFile(Stream stream, bool testExtract)
		{
			return false;
		}

		private void DeleteFileWithRetry(string filename)
		{
		}

		public void Save()
		{
		}

		private static void NotifyEntriesSaveComplete(ICollection<ZipEntry> c)
		{
		}

		private void RemoveTempFile()
		{
		}

		private void CleanupAfterSaveOperation()
		{
		}

		public void Save(string fileName)
		{
		}

		public void Save(Stream outputStream)
		{
		}

		public void AddSelectedFiles(string selectionCriteria)
		{
		}

		public void AddSelectedFiles(string selectionCriteria, bool recurseDirectories)
		{
		}

		public void AddSelectedFiles(string selectionCriteria, string directoryOnDisk)
		{
		}

		public void AddSelectedFiles(string selectionCriteria, string directoryOnDisk, bool recurseDirectories)
		{
		}

		public void AddSelectedFiles(string selectionCriteria, string directoryOnDisk, string directoryPathInArchive)
		{
		}

		public void AddSelectedFiles(string selectionCriteria, string directoryOnDisk, string directoryPathInArchive, bool recurseDirectories)
		{
		}

		public void UpdateSelectedFiles(string selectionCriteria, string directoryOnDisk, string directoryPathInArchive, bool recurseDirectories)
		{
		}

		private string EnsureendInSlash(string s)
		{
			return null;
		}

		private void _AddOrUpdateSelectedFiles(string selectionCriteria, string directoryOnDisk, string directoryPathInArchive, bool recurseDirectories, bool wantUpdate)
		{
		}

		private static string ReplaceLeadingDirectory(string original, string pattern, string replacement)
		{
			return null;
		}

		public ICollection<ZipEntry> SelectEntries(string selectionCriteria)
		{
			return null;
		}

		public ICollection<ZipEntry> SelectEntries(string selectionCriteria, string directoryPathInArchive)
		{
			return null;
		}

		public int RemoveSelectedEntries(string selectionCriteria)
		{
			return 0;
		}

		public int RemoveSelectedEntries(string selectionCriteria, string directoryPathInArchive)
		{
			return 0;
		}

		public void ExtractSelectedEntries(string selectionCriteria)
		{
		}

		public void ExtractSelectedEntries(string selectionCriteria, ExtractExistingFileAction extractExistingFile)
		{
		}

		public void ExtractSelectedEntries(string selectionCriteria, string directoryPathInArchive)
		{
		}

		public void ExtractSelectedEntries(string selectionCriteria, string directoryInArchive, string extractDirectory)
		{
		}

		public void ExtractSelectedEntries(string selectionCriteria, string directoryPathInArchive, string extractDirectory, ExtractExistingFileAction extractExistingFile)
		{
		}

		public bool ContainsEntry(string name)
		{
			return false;
		}

		public override string ToString()
		{
			return null;
		}

		internal void NotifyEntryChanged()
		{
		}

		internal Stream StreamForDiskNumber(uint diskNumber)
		{
			return null;
		}

		internal void Reset(bool whileSaving)
		{
		}

		public void Initialize(string fileName)
		{
		}

		private void _initEntriesDictionary()
		{
		}

		private void _InitInstance(string zipFileName, TextWriter statusMessageWriter)
		{
		}

		public void RemoveEntry(ZipEntry entry)
		{
		}

		public void RemoveEntry(string fileName)
		{
		}

		public void Dispose()
		{
		}

		protected virtual void Dispose(bool disposeManagedResources)
		{
		}

		[DebuggerHidden]
		public IEnumerator<ZipEntry> GetEnumerator()
		{
			return null;
		}

		[DispId(-4)]
		public IEnumerator GetNewEnum()
		{
			return null;
		}
	}
}
