using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine.Networking;

public class lzip
{
	public class inMemory
	{
		public IntPtr pointer;

		public IntPtr zf;

		public IntPtr memStruct;

		public IntPtr fileStruct;

		public int[] info;

		public int lastResult;

		public bool isClosed;

		public int size()
		{
			return 0;
		}

		public IntPtr memoryPointer()
		{
			return (IntPtr)0;
		}

		public byte[] getZipBuffer()
		{
			return null;
		}
	}

	public struct zipInfo
	{
		public short VersionMadeBy;

		public short MinimumVersionToExtract;

		public short BitFlag;

		public short CompressionMethod;

		public short FileLastModificationTime;

		public short FileLastModificationDate;

		public int CRC;

		public int CompressedSize;

		public int UncompressedSize;

		public short DiskNumberWhereFileStarts;

		public short InternalFileAttributes;

		public int ExternalFileAttributes;

		public int RelativeOffsetOfLocalFileHeader;

		public int AbsoluteOffsetOfLocalFileHeaderStore;

		public string filename;

		public string extraField;

		public string fileComment;
	}

	public class CustomWebRequest : DownloadHandlerScript
	{
		public CustomWebRequest()
		{
		}

		public CustomWebRequest(byte[] buffer)
		{
		}

		protected override byte[] GetData()
		{
			return null;
		}

		protected override bool ReceiveData(byte[] bytesFromServer, int dataLength)
		{
			return false;
		}
	}

	[CompilerGenerated]
	private sealed class _003CdownloadZipFileNative_003Ed__141 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public string url;

		public Action<bool> downloadDone;

		public Action<inMemory> inmem;

		public Action<IntPtr> pointer;

		public Action<int> fileSize;

		private UnityWebRequest _003Cwr_003E5__2;

		private int _003CzipSize_003E5__3;

		private UnityWebRequest _003CwwwSK_003E5__4;

		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		[DebuggerHidden]
		public _003CdownloadZipFileNative_003Ed__141(int _003C_003E1__state)
		{
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		private void _003C_003Em__Finally1()
		{
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
		}
	}

	private const string libname = "libzipw";

	public static IntPtr nativeBuffer;

	public static bool nativeBufferIsBeingUsed;

	public static int nativeOffset;

	public static List<string> ninfo;

	public static List<ulong> uinfo;

	public static List<ulong> cinfo;

	public static List<ulong> localOffset;

	public static int zipFiles;

	public static int zipFolders;

	public static ulong totalCompressedSize;

	public static ulong totalUncompressedSize;

	public static List<zipInfo> zinfo;

	[PreserveSig]
	public static extern void setTarEncoding(uint encoding);

	[PreserveSig]
	public static extern void setEncoding(uint encoding);

	[PreserveSig]
	internal static extern bool zipValidateFile(string zipArchive, IntPtr FileBuffer, int fileBufferLength);

	[PreserveSig]
	internal static extern int zipGetTotalFiles(string zipArchive, IntPtr FileBuffer, int fileBufferLength);

	[PreserveSig]
	internal static extern int zipGetTotalEntries(string zipArchive, IntPtr FileBuffer, int fileBufferLength);

	[PreserveSig]
	internal static extern int zipGetInfoA(string zipArchive, IntPtr total, IntPtr FileBuffer, int fileBufferLength);

	[PreserveSig]
	internal static extern IntPtr zipGetInfo(string zipArchive, int size, IntPtr unc, IntPtr comp, IntPtr offs, IntPtr FileBuffer, int fileBufferLength);

	[PreserveSig]
	public static extern void releaseBuffer(IntPtr buffer);

	[PreserveSig]
	public static extern IntPtr createBuffer(int size);

	[PreserveSig]
	private static extern void addToBuffer(IntPtr destination, int offset, IntPtr buffer, int len);

	[PreserveSig]
	internal static extern ulong zipGetEntrySize(string zipArchive, string entry, IntPtr FileBuffer, int fileBufferLength);

	[PreserveSig]
	internal static extern bool zipEntryExists(string zipArchive, string entry, IntPtr FileBuffer, int fileBufferLength);

	[PreserveSig]
	internal static extern int zipCD(int levelOfCompression, string zipArchive, string inFilePath, string fileName, string comment, string password, bool useBz2, int diskSize, IntPtr bprog);

	[PreserveSig]
	internal static extern int zipCDList(int levelOfCompression, string zipArchive, IntPtr filename, int arrayLength, IntPtr prog, IntPtr filenameForced, string password, bool useBz2, int diskSize, IntPtr bprog);

	[PreserveSig]
	internal static extern bool zipBuf2File(int levelOfCompression, string zipArchive, string arcFilename, IntPtr buffer, int bufferSize, string comment, string password, bool useBz2);

	[PreserveSig]
	internal static extern int zipDeleteFile(string zipArchive, string arcFilename, string tempArchive);

	[PreserveSig]
	internal static extern int zipEntry2Buffer(string zipArchive, string entry, IntPtr buffer, int bufferSize, IntPtr FileBuffer, int fileBufferLength, string password);

	[PreserveSig]
	internal static extern IntPtr zipCompressBuffer(IntPtr source, int sourceLen, int levelOfCompression, ref int v);

	[PreserveSig]
	internal static extern IntPtr zipDecompressBuffer(IntPtr source, int sourceLen, ref int v);

	[PreserveSig]
	internal static extern int zipEX(string zipArchive, string outPath, IntPtr progress, IntPtr FileBuffer, int fileBufferLength, IntPtr proc, string password);

	[PreserveSig]
	internal static extern int zipEntry(string zipArchive, string arcFilename, string outpath, IntPtr FileBuffer, int fileBufferLength, IntPtr proc, string password);

	[PreserveSig]
	internal static extern int zipEntryList(string zipArchive, IntPtr outpath, IntPtr filename, int arrayLength, IntPtr FileBuffer, int fileBufferLength, IntPtr proc, string password);

	[PreserveSig]
	internal static extern uint getEntryDateTime(string zipArchive, string arcFilename, IntPtr FileBuffer, int fileBufferLength);

	[PreserveSig]
	internal static extern int freeMemStruct(IntPtr buffer);

	[PreserveSig]
	internal static extern IntPtr zipCDMem(IntPtr info, IntPtr pnt, int levelOfCompression, IntPtr source, int sourceLen, string fileName, string comment, string password, bool useBz2);

	[PreserveSig]
	internal static extern IntPtr initMemStruct();

	[PreserveSig]
	internal static extern IntPtr initFileStruct();

	[PreserveSig]
	internal static extern int freeMemZ(IntPtr pointer);

	[PreserveSig]
	internal static extern int freeFileZ(IntPtr pointer);

	[PreserveSig]
	internal static extern IntPtr zipCDMemStart(IntPtr info, IntPtr pnt, IntPtr fileStruct, IntPtr memStruct);

	[PreserveSig]
	internal static extern int zipCDMemAdd(IntPtr zf, int levelOfCompression, IntPtr source, int sourceLen, string fileName, string comment, string password, bool useBz2);

	[PreserveSig]
	internal static extern IntPtr zipCDMemClose(IntPtr zf, IntPtr memStruct, IntPtr info, int err);

	[PreserveSig]
	internal static extern int zipGzip(IntPtr source, int sourceLen, IntPtr outBuffer, int levelOfCompression, bool addHeader, bool addFooter);

	[PreserveSig]
	internal static extern int zipUnGzip(IntPtr source, int sourceLen, IntPtr outBuffer, int outLen, bool hasHeader, bool hasFooter);

	[PreserveSig]
	internal static extern int zipUnGzip2(IntPtr source, int sourceLen, IntPtr outBuffer, int outLen);

	[PreserveSig]
	internal static extern int gzip_File(string inFile, string outFile, int level, IntPtr progress, bool addHeader);

	[PreserveSig]
	internal static extern int ungzip_File(string inFile, string outFile, IntPtr progress);

	[PreserveSig]
	public static extern void setCancel();

	[PreserveSig]
	internal static extern int readTarA(string zipArchive, IntPtr total);

	[PreserveSig]
	internal static extern IntPtr readTar(string zipArchive, int size, IntPtr unc);

	[PreserveSig]
	internal static extern int createTar(string outFile, IntPtr filePath, IntPtr filename, int arrayLength, IntPtr prog, IntPtr bprog);

	[PreserveSig]
	internal static extern int extractTar(string inFile, string outDir, string entry, IntPtr prog, IntPtr bprog, bool fullPaths);

	[PreserveSig]
	internal static extern int bz2(bool decompress, int level, string inFile, string outFile, IntPtr byteProgress);

	internal static GCHandle gcA(object o)
	{
		return default(GCHandle);
	}

	private static bool checkObject(object o, string zipArchive, ref int len, ref IntPtr ptr)
	{
		return false;
	}

	public static ulong getFileInfo(string zipArchive, object fileBuffer = null)
	{
		return 0uL;
	}

	public static int getEntryIndex(string entry)
	{
		return 0;
	}

	public static int getTotalFiles(string zipArchive, object fileBuffer = null)
	{
		return 0;
	}

	public static int getTotalEntries(string zipArchive, object fileBuffer = null)
	{
		return 0;
	}

	public static ulong getEntrySize(string zipArchive, string entry, object fileBuffer = null)
	{
		return 0uL;
	}

	public static bool entryExists(string zipArchive, string entry, object fileBuffer = null)
	{
		return false;
	}

	public static int setFilePermissions(string filePath, string _user, string _group, string _other)
	{
		return 0;
	}

	public static bool buffer2File(int levelOfCompression, string zipArchive, string arcFilename, byte[] buffer, bool append = false, string comment = null, string password = null, bool useBz2 = false)
	{
		return false;
	}

	public static int delete_entry(string zipArchive, string arcFilename)
	{
		return 0;
	}

	public static int replace_entry(string zipArchive, string arcFilename, string newFilePath, int level = 9, string comment = null, string password = null, bool useBz2 = false)
	{
		return 0;
	}

	public static int replace_entry(string zipArchive, string arcFilename, byte[] newFileBuffer, int level = 9, string password = null, bool useBz2 = false)
	{
		return 0;
	}

	public static int extract_entry(string zipArchive, string arcFilename, string outpath, object fileBuffer = null, ulong[] proc = null, string password = null)
	{
		return 0;
	}

	public static int extract_entries(string zipArchive, string[] fileList, string outpath, object fileBuffer = null, ulong[] proc = null, string password = null)
	{
		return 0;
	}

	public static int decompress_File(string zipArchive, string outPath = null, int[] progress = null, object fileBuffer = null, ulong[] proc = null, string password = null)
	{
		return 0;
	}

	public static int compress_File(int levelOfCompression, string zipArchive, string inFilePath, bool append = false, string fileName = "", string comment = null, string password = null, bool useBz2 = false, int diskSize = 0, ulong[] byteProgress = null)
	{
		return 0;
	}

	public static int compress_File_List(int levelOfCompression, string zipArchive, string[] inFilePath, int[] progress = null, bool append = false, string[] fileName = null, string password = null, bool useBz2 = false, int diskSize = 0, ulong[] byteProgress = null)
	{
		return 0;
	}

	public static int compressDir(string sourceDir, int levelOfCompression, string zipArchive = null, bool includeRoot = false, int[] progress = null, string password = null, bool useBz2 = false, int diskSize = 0, bool append = false, ulong[] byteProgress = null)
	{
		return 0;
	}

	private static void fillPointers(string outFile, string[] fileName, string[] inFilePath, ref IntPtr[] fp, ref IntPtr[] np)
	{
	}

	private static void fillLists(string fdir, bool includeRoot, ref List<string> inFilePath, ref List<string> fileName)
	{
	}

	public static int getAllFiles(string dir)
	{
		return 0;
	}

	public static long getFileSize(string file)
	{
		return 0L;
	}

	public static ulong getDirSize(string dir)
	{
		return 0uL;
	}

	public static int tarExtract(string inFile, string outPath = null, int[] progress = null, ulong[] byteProgress = null)
	{
		return 0;
	}

	public static int tarExtractEntry(string inFile, string entry, string outPath = null, bool fullPaths = true, ulong[] byteProgress = null)
	{
		return 0;
	}

	public static int tarDir(string sourceDir, string outFile = null, bool includeRoot = false, int[] progress = null, ulong[] byteProgress = null)
	{
		return 0;
	}

	public static int tarList(string outFile, string[] inFilePath, string[] fileName = null, int[] progress = null, ulong[] byteProgress = null)
	{
		return 0;
	}

	public static ulong getTarInfo(string tarArchive)
	{
		return 0uL;
	}

	public static DateTime entryDateTime(string zipArchive, string entry, object fileBuffer = null)
	{
		return default(DateTime);
	}

	public static void free_inmemory(inMemory t)
	{
	}

	public static bool inMemoryZipStart(inMemory t)
	{
		return false;
	}

	public static int inMemoryZipAdd(inMemory t, int levelOfCompression, byte[] buffer, string fileName, string comment = null, string password = null, bool useBz2 = false)
	{
		return 0;
	}

	public static IntPtr inMemoryZipClose(inMemory t)
	{
		return (IntPtr)0;
	}

	public static IntPtr compress_Buf2Mem(inMemory t, int levelOfCompression, byte[] buffer, string fileName, string comment = null, string password = null, bool useBz2 = false)
	{
		return (IntPtr)0;
	}

	public static int decompress_Mem2File(inMemory t, string outPath, int[] progress = null, ulong[] proc = null, string password = null)
	{
		return 0;
	}

	public static int entry2BufferMem(inMemory t, string entry, ref byte[] buffer, string password = null)
	{
		return 0;
	}

	public static byte[] entry2BufferMem(inMemory t, string entry, string password = null)
	{
		return null;
	}

	public static int entry2FixedBufferMem(inMemory t, string entry, ref byte[] fixedBuffer, string password = null)
	{
		return 0;
	}

	public static ulong getFileInfoMem(inMemory t)
	{
		return 0uL;
	}

	public static int entry2Buffer(string zipArchive, string entry, ref byte[] buffer, object fileBuffer = null, string password = null)
	{
		return 0;
	}

	public static int entry2FixedBuffer(string zipArchive, string entry, ref byte[] fixedBuffer, object fileBuffer = null, string password = null)
	{
		return 0;
	}

	public static byte[] entry2Buffer(string zipArchive, string entry, object fileBuffer = null, string password = null)
	{
		return null;
	}

	public static bool validateFile(string zipArchive, object fileBuffer = null)
	{
		return false;
	}

	public static bool getZipInfo(string fileName)
	{
		return false;
	}

	public static bool getZipInfoMerged(string fileName, ref int pos, ref int size, bool getCentralDirectory = false)
	{
		return false;
	}

	public static bool getZipInfoMerged(byte[] buffer, ref int pos, ref int size, bool getCentralDirectory = false)
	{
		return false;
	}

	public static bool getZipInfoMerged(byte[] buffer)
	{
		return false;
	}

	private static bool findPK(BinaryReader reader)
	{
		return false;
	}

	private static int findEnd(BinaryReader reader, ref int pos, ref int size)
	{
		return 0;
	}

	private static void getCentralDir(BinaryReader reader, int count)
	{
	}

	public static byte[] getMergedZip(string filePath, ref int position, ref int siz)
	{
		return null;
	}

	public static byte[] getMergedZip(string filePath)
	{
		return null;
	}

	public static byte[] getMergedZip(byte[] buffer, ref int position, ref int siz)
	{
		return null;
	}

	public static byte[] getMergedZip(byte[] buffer)
	{
		return null;
	}

	public static int decompressZipMerged(string file, string outPath, int[] progress = null, ulong[] proc = null, string password = null)
	{
		return 0;
	}

	public static int decompressZipMerged(byte[] buffer, string outPath, int[] progress = null, ulong[] proc = null, string password = null)
	{
		return 0;
	}

	private static void writeFile(byte[] tb, string entry, string outPath, string overrideEntryName, ref int res)
	{
	}

	public static int entry2FileMerged(string file, string entry, string outPath, string overrideEntryName = null, string password = null)
	{
		return 0;
	}

	public static int entry2FileMerged(byte[] buffer, string entry, string outPath, string overrideEntryName = null, string password = null)
	{
		return 0;
	}

	public static byte[] entry2BufferMerged(string file, string entry, string password = null)
	{
		return null;
	}

	public static int entry2BufferMerged(string file, string entry, ref byte[] refBuffer, string password = null)
	{
		return 0;
	}

	public static int entry2FixedBufferMerged(string file, string entry, ref byte[] fixedBuffer, string password = null)
	{
		return 0;
	}

	public static byte[] entry2BufferMerged(byte[] buffer, string entry, string password = null)
	{
		return null;
	}

	public static int entry2BufferMerged(byte[] buffer, string entry, ref byte[] refBuffer, string password = null)
	{
		return 0;
	}

	public static int entry2FixedBufferMerged(byte[] buffer, string entry, ref byte[] fixedBuffer, string password = null)
	{
		return 0;
	}

	public static bool compressBuffer(byte[] source, ref byte[] outBuffer, int levelOfCompression)
	{
		return false;
	}

	public static int compressBufferFixed(byte[] source, ref byte[] outBuffer, int levelOfCompression, bool safe = true)
	{
		return 0;
	}

	public static byte[] compressBuffer(byte[] source, int levelOfCompression)
	{
		return null;
	}

	public static bool decompressBuffer(byte[] source, ref byte[] outBuffer)
	{
		return false;
	}

	public static int decompressBufferFixed(byte[] source, ref byte[] outBuffer, bool safe = true)
	{
		return 0;
	}

	public static byte[] decompressBuffer(byte[] source)
	{
		return null;
	}

	public static int gzip(byte[] source, byte[] outBuffer, int level, bool addHeader = true, bool addFooter = true, bool overrideDateTimeWithLength = false)
	{
		return 0;
	}

	public static int gzipUncompressedSize(byte[] source)
	{
		return 0;
	}

	public static int gzipCompressedSize(byte[] source, int offset = 0)
	{
		return 0;
	}

	public static int findGzStart(byte[] buffer)
	{
		return 0;
	}

	public static int unGzip(byte[] source, byte[] outBuffer, bool hasHeader = true, bool hasFooter = true)
	{
		return 0;
	}

	public static int unGzip2(object source, byte[] outBuffer, int intPtrLength = 0)
	{
		return 0;
	}

	public static int unGzip2Merged(byte[] source, int offset, int bufferLength, byte[] outBuffer)
	{
		return 0;
	}

	public static int gzipFile(string inFile, string outFile = null, int level = 9, ulong[] progress = null, bool addHeader = true)
	{
		return 0;
	}

	public static int ungzipFile(string inFile, string outFile = null, ulong[] progress = null)
	{
		return 0;
	}

	public static int bz2Create(string inFile, string outFile = null, int level = 9, ulong[] byteProgress = null)
	{
		return 0;
	}

	public static int bz2Decompress(string inFile, string outFile = null, ulong[] byteProgress = null)
	{
		return 0;
	}

	[IteratorStateMachine(typeof(_003CdownloadZipFileNative_003Ed__141))]
	public static IEnumerator downloadZipFileNative(string url, Action<bool> downloadDone, Action<inMemory> inmem, Action<IntPtr> pointer = null, Action<int> fileSize = null)
	{
		return null;
	}
}
