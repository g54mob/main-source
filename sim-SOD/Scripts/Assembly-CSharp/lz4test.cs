using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Networking;

public class lz4test : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CDownloadTestFile_003Ed__19 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public lz4test _003C_003E4__this;

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
		public _003CDownloadTestFile_003Ed__19(int _003C_003E1__state)
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

	private float lz1;

	private int lz2;

	private int lz3;

	private int lz4;

	private int fbuftest;

	private int nFbuftest;

	private ulong[] bytes;

	private float[] progress;

	private string myFile;

	private string uri;

	private string ppath;

	private bool compressionStarted;

	private bool downloadDone;

	private byte[] buff;

	private byte[] fixedOutBuffer;

	private void Start()
	{
	}

	private void Update()
	{
	}

	private void OnGUI()
	{
	}

	private void DoTests()
	{
	}

	[IteratorStateMachine(typeof(_003CDownloadTestFile_003Ed__19))]
	private IEnumerator DownloadTestFile()
	{
		return null;
	}
}
