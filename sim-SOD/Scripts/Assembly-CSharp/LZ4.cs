using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine.Networking;

public class LZ4
{
	public class CustomWebRequest4 : DownloadHandlerScript
	{
		public CustomWebRequest4()
		{
		}

		public CustomWebRequest4(byte[] buffer)
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
	private sealed class _003CdownloadLZ4FileNative_003Ed__24 : IEnumerator<object>, IEnumerator, IDisposable
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
		public _003CdownloadLZ4FileNative_003Ed__24(int _003C_003E1__state)
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

	private const string libname = "liblz4";

	public static IntPtr nativeBuffer;

	public static bool nativeBufferIsBeingUsed;

	public static int nativeOffset;

	[PreserveSig]
	internal static extern int LZ4DecompressFile(string inFile, string outFile, IntPtr bytes, IntPtr FileBuffer, int fileBufferLength);

	[PreserveSig]
	internal static extern int LZ4CompressFile(string inFile, string outFile, int level, IntPtr percentage, ref float rate);

	[PreserveSig]
	public static extern void LZ4releaseBuffer(IntPtr buffer);

	[PreserveSig]
	public static extern IntPtr LZ4Create_Buffer(int size);

	[PreserveSig]
	private static extern void LZ4AddTo_Buffer(IntPtr destination, int offset, IntPtr buffer, int len);

	[PreserveSig]
	internal static extern IntPtr LZ4CompressBuffer(IntPtr buffer, int bufferLength, ref int v, int level);

	[PreserveSig]
	internal static extern int LZ4DecompressBuffer(IntPtr buffer, IntPtr outbuffer, int bufferLength);

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

	public static float compress(string inFile, string outFile, int level, float[] progress)
	{
		return 0f;
	}

	public static int decompress(string inFile, string outFile, ulong[] bytes, object fileBuffer = null)
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

	public static int compressBufferPartialFixed(byte[] inBuffer, ref byte[] outBuffer, int outBufferPartialIndex, int level, bool includeSize = true)
	{
		return 0;
	}

	public static int decompressBufferPartialFixed(byte[] inBuffer, ref byte[] outBuffer, int partialIndex, int compressedBufferSize, bool safe = true, bool useFooter = true, int customLength = 0)
	{
		return 0;
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

	[IteratorStateMachine(typeof(_003CdownloadLZ4FileNative_003Ed__24))]
	public static IEnumerator downloadLZ4FileNative(string url, Action<bool> downloadDone, Action<IntPtr> pointer = null, Action<int> fileSize = null)
	{
		return null;
	}
}
