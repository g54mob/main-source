using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using UnityEngine;
using UnityEngine.Networking;

public class SevenZipTest : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CDownload7ZFile_003Ed__17 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public SevenZipTest _003C_003E4__this;

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
		public _003CDownload7ZFile_003Ed__17(int _003C_003E1__state)
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

	[CompilerGenerated]
	private sealed class _003Cbuff2buffTest_003Ed__18 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public SevenZipTest _003C_003E4__this;

		private UnityWebRequest _003Cw_003E5__2;

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
		public _003Cbuff2buffTest_003Ed__18(int _003C_003E1__state)
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

	private string myFile;

	private string uri;

	private string ppath;

	private string log;

	private bool downloadDone;

	private ulong tsize;

	private byte[] buff;

	private byte[] fixedInBuffer;

	private byte[] fixedOutBuffer;

	private Thread th;

	private int[] fileProgress;

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

	private void Decompress()
	{
	}

	[IteratorStateMachine(typeof(_003CDownload7ZFile_003Ed__17))]
	private IEnumerator Download7ZFile()
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003Cbuff2buffTest_003Ed__18))]
	private IEnumerator buff2buffTest()
	{
		return null;
	}
}
