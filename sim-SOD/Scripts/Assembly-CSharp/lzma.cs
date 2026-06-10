using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine.Networking;

public class lzma
{
	public enum dic
	{
		K0004 = 0x1000,
		K0008 = 0x2000,
		K0016 = 0x4000,
		K0032 = 0x8000,
		K0064 = 0x10000,
		K0128 = 0x20000,
		K0256 = 0x40000,
		K0512 = 0x80000,
		K1024 = 0x100000,
		K2048 = 0x200000
	}

	public class CustomWebRequest2 : DownloadHandlerScript
	{
		public CustomWebRequest2()
		{
		}

		public CustomWebRequest2(byte[] buffer)
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
	private sealed class _003Cdownload7zFileNative_003Ed__49 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public string url;

		public Action<bool> downloadDone;

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
		public _003Cdownload7zFileNative_003Ed__49(int _003C_003E1__state)
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

	public static string persitentDataPath;

	internal static int[] props;

	internal static bool defaultsSet;

	private const string libname = "liblzma";

	public static List<string> ninfo;

	public static List<ulong> sinfo;

	public static int trueTotalFiles;

	public static IntPtr nativeBuffer;

	public static bool nativeBufferIsBeingUsed;

	public static int nativeOffset;

	public static void setProps(int level = 5, int dictSize = 65536, int lc = 3, int lp = 0, int pb = 2, int fb = 32, int numThreads = 2)
	{
	}

	[PreserveSig]
	internal static extern int decompress7zip(string filePath, string exctractionPath, bool fullPaths, string entry, IntPtr progress, IntPtr FileBuffer, int FileBufferLength);

	[PreserveSig]
	internal static extern int decompress7zip2(string filePath, string exctractionPath, bool fullPaths, string entry, IntPtr progress, IntPtr FileBuffer, int FileBufferLength);

	[PreserveSig]
	internal static extern IntPtr _getSize(string filePath, IntPtr FileBuffer, int FileBufferLength, bool justParse);

	[PreserveSig]
	internal static extern ulong entrySize(string filePath, string entry, IntPtr FileBuffer, int FileBufferLength);

	[PreserveSig]
	internal static extern int lzmaUtil(bool encode, string inPath, string outPath, IntPtr Props);

	[PreserveSig]
	internal static extern int decode2Buf(string filePath, string entry, IntPtr buffer, IntPtr FileBuffer, int FileBufferLength);

	[PreserveSig]
	public static extern void _releaseBuffer(IntPtr buffer);

	[PreserveSig]
	public static extern IntPtr _createBuffer(int size);

	[PreserveSig]
	private static extern void _addToBuffer(IntPtr destination, int offset, IntPtr buffer, int len);

	[PreserveSig]
	internal static extern IntPtr Lzma_Compress(IntPtr buffer, int bufferLength, bool makeHeader, ref int v, IntPtr Props);

	[PreserveSig]
	internal static extern int Lzma_Uncompress(IntPtr buffer, int bufferLength, int uncompressedSize, IntPtr outbuffer, bool useHeader);

	[PreserveSig]
	public static extern void sevenZcancel();

	[PreserveSig]
	public static extern void resetBytesRead();

	[PreserveSig]
	public static extern ulong getBytesRead();

	[PreserveSig]
	public static extern ulong getBytesWritten();

	internal static GCHandle gcA(object o)
	{
		return default(GCHandle);
	}

	public static int setFilePermissions(string filePath, string _user, string _group, string _other)
	{
		return 0;
	}

	private static bool checkObject(object fileBuffer, string filePath, ref GCHandle fbuf, ref IntPtr fileBufferPointer, ref int fileBufferLength)
	{
		return false;
	}

	public static int doDecompress7zip(string filePath, string exctractionPath = null, int[] progress = null, bool largeFiles = false, bool fullPaths = true, string entry = null, object fileBuffer = null)
	{
		return 0;
	}

	public static int doDecompress7zip(string filePath, string exctractionPath = null, bool largeFiles = false, bool fullPaths = true, string entry = null, object fileBuffer = null)
	{
		return 0;
	}

	public static int LzmaUtilEncode(string inPath, string outPath)
	{
		return 0;
	}

	public static int LzmaUtilDecode(string inPath, string outPath)
	{
		return 0;
	}

	public static ulong get7zInfo(string filePath, object fileBuffer = null)
	{
		return 0uL;
	}

	public static ulong get7zSize(string filePath = null, string entry = null, object fileBuffer = null)
	{
		return 0uL;
	}

	public static uint getHeadersSize(string filePath, object fileBuffer = null)
	{
		return 0u;
	}

	public static byte[] decode2Buffer(string filePath, string entry, object fileBuffer = null)
	{
		return null;
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

	public static bool compressBuffer(byte[] inBuffer, ref byte[] outBuffer, bool makeHeader = true)
	{
		return false;
	}

	public static byte[] compressBuffer(byte[] inBuffer, bool makeHeader = true)
	{
		return null;
	}

	public static bool compressBufferPartial(byte[] inBuffer, int inBufferPartialIndex, int inBufferPartialLength, ref byte[] outBuffer, bool makeHeader = true)
	{
		return false;
	}

	public static int compressBufferPartialFixed(byte[] inBuffer, int inBufferPartialIndex, int inBufferPartialLength, ref byte[] outBuffer, bool safe = true, bool makeHeader = true)
	{
		return 0;
	}

	public static int compressBufferFixed(byte[] inBuffer, ref byte[] outBuffer, bool safe = true, bool makeHeader = true)
	{
		return 0;
	}

	public static int decompressBuffer(byte[] inBuffer, ref byte[] outbuffer, bool useHeader = true, int customLength = 0)
	{
		return 0;
	}

	public static byte[] decompressBuffer(byte[] inBuffer, bool useHeader = true, int customLength = 0)
	{
		return null;
	}

	public static int decompressBufferFixed(byte[] inBuffer, ref byte[] outbuffer, bool safe = true, bool useHeader = true, int customLength = 0)
	{
		return 0;
	}

	[IteratorStateMachine(typeof(_003Cdownload7zFileNative_003Ed__49))]
	public static IEnumerator download7zFileNative(string url, Action<bool> downloadDone, Action<IntPtr> pointer = null, Action<int> fileSize = null)
	{
		return null;
	}
}
