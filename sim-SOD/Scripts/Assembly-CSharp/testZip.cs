using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Networking;

public class testZip : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass23_0
	{
		public testZip _003C_003E4__this;

		public lzip.inMemory inMemZip;

		public IntPtr nativePointer;

		public int zipSize;

		internal void _003CNativeFileBufferDownload_003Eb__0(bool r)
		{
		}

		internal void _003CNativeFileBufferDownload_003Eb__1(lzip.inMemory result)
		{
		}

		internal void _003CNativeFileBufferDownload_003Eb__2(bool r)
		{
		}

		internal void _003CNativeFileBufferDownload_003Eb__3(IntPtr pointerResult)
		{
		}

		internal void _003CNativeFileBufferDownload_003Eb__4(int size)
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CNativeFileBufferDownload_003Ed__23 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public testZip _003C_003E4__this;

		private _003C_003Ec__DisplayClass23_0 _003C_003E8__1;

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
		public _003CNativeFileBufferDownload_003Ed__23(int _003C_003E1__state)
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

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CDownloadZipFile_003Ed__29 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public testZip _003C_003E4__this;

		private UnityWebRequest _003Cwww_003E5__2;

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
		public _003CDownloadZipFile_003Ed__29(int _003C_003E1__state)
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

	private int zres;

	private string myFile;

	private string log;

	private string ppath;

	private bool compressionStarted;

	private bool pass;

	private bool downloadDone;

	private bool downloadDone2;

	private byte[] reusableBuffer;

	private byte[] reusableBuffer2;

	private byte[] reusableBuffer3;

	private byte[] fixedInBuffer;

	private byte[] fixedOutBuffer;

	private byte[] fixedBuffer;

	private int[] progress;

	private ulong[] progress2;

	private ulong[] byteProgress;

	private void plog(string t = "")
	{
	}

	private void Start()
	{
	}

	private void Update()
	{
	}

	private void OnGUI()
	{
	}

	private void DoDecompression()
	{
	}

	private void decompressFunc()
	{
	}

	[IteratorStateMachine(typeof(_003CNativeFileBufferDownload_003Ed__23))]
	private IEnumerator NativeFileBufferDownload()
	{
		return null;
	}

	private void DoDecompression_FileBuffer()
	{
	}

	private void DoInMemoryTest()
	{
	}

	private void DoGzipBz2Tests()
	{
	}

	private void DoTarTests()
	{
	}

	private void DoDecompression_Merged()
	{
	}

	[IteratorStateMachine(typeof(_003CDownloadZipFile_003Ed__29))]
	private IEnumerator DownloadZipFile()
	{
		return null;
	}
}
