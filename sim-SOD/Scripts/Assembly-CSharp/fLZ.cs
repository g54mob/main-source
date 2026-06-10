using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine.Networking;

public class fLZ
{
	public class CustomWebRequest3 : DownloadHandlerScript
	{
		public CustomWebRequest3()
		{
		}

		public CustomWebRequest3(byte[] buffer)
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
	private sealed class _003CdownloadFlzFileNative_003Ed__22 : IEnumerator<object>, IEnumerator, IDisposable
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
		public _003CdownloadFlzFileNative_003Ed__22(int _003C_003E1__state)
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

	internal static bool isle;

	private const string libname = "libfastlz";

	public static IntPtr nativeBuffer;

	public static bool nativeBufferIsBeingUsed;

	public static int nativeOffset;

	[PreserveSig]
	internal static extern int fLZcompressFile(int level, string inFile, string outFile, bool overwrite, IntPtr percent);

	[PreserveSig]
	internal static extern int fLZdecompressFile(string inFile, string outFile, bool overwrite, IntPtr percent, IntPtr FileBuffer, int fileBufferLength);

	[PreserveSig]
	public static extern void fLZreleaseBuffer(IntPtr buffer);

	[PreserveSig]
	public static extern IntPtr create_Buffer(int size);

	[PreserveSig]
	private static extern void addTo_Buffer(IntPtr destination, int offset, IntPtr buffer, int len);

	[PreserveSig]
	internal static extern IntPtr fLZcompressBuffer(IntPtr buffer, int bufferLength, int level, ref int v);

	[PreserveSig]
	internal static extern int fLZdecompressBuffer(IntPtr buffer, int bufferLength, IntPtr outbuffer);

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

	public static int compressFile(string inFile, string outFile, int level, bool overwrite, ulong[] progress)
	{
		return 0;
	}

	public static int decompressFile(string inFile, string outFile, bool overwrite, ulong[] progress, object fileBuffer = null)
	{
		return 0;
	}

	public static bool compressBuffer(byte[] inBuffer, ref byte[] outBuffer, int level, bool includeSize = true)
	{
		return false;
	}

	public static byte[] compressBuffer(byte[] inBuffer, int level, bool includeSize = true)
	{
		return null;
	}

	public static bool decompressBuffer(byte[] inBuffer, ref byte[] outBuffer, bool useFooter = true, int customLength = 0)
	{
		return false;
	}

	public static int decompressBufferFixed(byte[] inBuffer, ref byte[] outBuffer, bool safe = true, bool useFooter = true, int customLength = 0)
	{
		return 0;
	}

	public static byte[] decompressBuffer(byte[] inBuffer, bool useFooter = true, int customLength = 0)
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003CdownloadFlzFileNative_003Ed__22))]
	public static IEnumerator downloadFlzFileNative(string url, Action<bool> downloadDone, Action<IntPtr> pointer = null, Action<int> fileSize = null)
	{
		return null;
	}
}
