using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine.Networking;

public class brotli
{
	public class CustomWebRequest5 : DownloadHandlerScript
	{
		public CustomWebRequest5()
		{
		}

		public CustomWebRequest5(byte[] buffer)
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
	private sealed class _003CdownloadBrFileNative_003Ed__24 : IEnumerator<object>, IEnumerator, IDisposable
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
		public _003CdownloadBrFileNative_003Ed__24(int _003C_003E1__state)
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

	private const string libname = "libbrotli";

	public static IntPtr nativeBuffer;

	public static bool nativeBufferIsBeingUsed;

	public static int nativeOffset;

	[PreserveSig]
	internal static extern int brCompress(string inFile, string outFile, IntPtr proc, int quality, int lgwin, int lgblock, int mode);

	[PreserveSig]
	internal static extern int brDecompresss(string inFile, string outFile, IntPtr proc, IntPtr FileBuffer, int fileBufferLength);

	[PreserveSig]
	public static extern void brReleaseBuffer(IntPtr buffer);

	[PreserveSig]
	public static extern IntPtr brCreate_Buffer(int size);

	[PreserveSig]
	private static extern void brAddTo_Buffer(IntPtr destination, int offset, IntPtr buffer, int len);

	[PreserveSig]
	internal static extern IntPtr brCompressBuffer(int bufferLength, IntPtr buffer, IntPtr encodedSize, IntPtr proc, int quality, int lgwin, int lgblock, int mode);

	[PreserveSig]
	internal static extern int brGetDecodedSize(int bufferLength, IntPtr buffer);

	[PreserveSig]
	internal static extern int brDecompressBuffer(int bufferLength, IntPtr buffer, int outLength, IntPtr outbuffer);

	public static int setFilePermissions(string filePath, string _user, string _group, string _other)
	{
		return 0;
	}

	internal static GCHandle gcA(object o)
	{
		return default(GCHandle);
	}

	private static bool checkObject(object fileBuffer, string filePath, ref GCHandle fbuf, ref IntPtr fileBufferPointer, ref int fileBufferLength)
	{
		return false;
	}

	public static int compressFile(string inFile, string outFile, ulong[] proc, int quality = 9, int lgwin = 19, int lgblock = 0, int mode = 0)
	{
		return 0;
	}

	public static int decompressFile(string inFile, string outFile, ulong[] proc, object fileBuffer = null)
	{
		return 0;
	}

	public static int getDecodedSize(byte[] inBuffer)
	{
		return 0;
	}

	public static bool compressBuffer(byte[] inBuffer, ref byte[] outBuffer, ulong[] proc, bool includeSize = false, int quality = 9, int lgwin = 19, int lgblock = 0, int mode = 0)
	{
		return false;
	}

	public static byte[] compressBuffer(byte[] inBuffer, int[] proc, bool includeSize = false, int quality = 9, int lgwin = 19, int lgblock = 0, int mode = 0)
	{
		return null;
	}

	public static int compressBuffer(byte[] inBuffer, byte[] outBuffer, int[] proc, bool includeSize = false, int quality = 9, int lgwin = 19, int lgblock = 0, int mode = 0)
	{
		return 0;
	}

	public static bool decompressBuffer(byte[] inBuffer, ref byte[] outBuffer, bool useFooter = false, int unCompressedSize = 0)
	{
		return false;
	}

	public static byte[] decompressBuffer(byte[] inBuffer, bool useFooter = false, int unCompressedSize = 0)
	{
		return null;
	}

	public static int decompressBuffer(byte[] inBuffer, byte[] outBuffer, bool useFooter = false, int unCompressedSize = 0)
	{
		return 0;
	}

	[IteratorStateMachine(typeof(_003CdownloadBrFileNative_003Ed__24))]
	public static IEnumerator downloadBrFileNative(string url, Action<bool> downloadDone, Action<IntPtr> pointer = null, Action<int> fileSize = null)
	{
		return null;
	}
}
