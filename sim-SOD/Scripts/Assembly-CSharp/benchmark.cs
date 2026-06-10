using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Networking;

public class benchmark : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CdecompressFunc_003Ed__30 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public benchmark _003C_003E4__this;

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
		public _003CdecompressFunc_003Ed__30(int _003C_003E1__state)
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
	private sealed class _003CDownload7ZFile_003Ed__31 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public benchmark _003C_003E4__this;

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
		public _003CDownload7ZFile_003Ed__31(int _003C_003E1__state)
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

	private int lzres;

	private int zipres;

	private int flzres;

	private int brres;

	private int lz4res;

	private int gzres;

	private bool pass1;

	private bool pass2;

	private float t1;

	private float tim;

	private string myFile;

	private string myFile2;

	private string uncFile;

	private string uri;

	private string ppath;

	private string log;

	private bool downloadDone;

	private bool benchmarkStarted;

	private long tsize;

	private GUIStyle style;

	private int[] progress;

	private ulong[] progress1;

	private ulong[] progress2;

	private float[] progress3;

	private ulong[] progress4;

	private ulong[] bytes;

	private ulong[] gzProgress;

	private void Start()
	{
	}

	private void Update()
	{
	}

	private void OnGUI()
	{
	}

	[IteratorStateMachine(typeof(_003CdecompressFunc_003Ed__30))]
	private IEnumerator decompressFunc()
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003CDownload7ZFile_003Ed__31))]
	private IEnumerator Download7ZFile()
	{
		return null;
	}
}
