using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.Networking;

public class AkMemBankLoader : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CLoadFile_003Ed__14 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public AkMemBankLoader _003C_003E4__this;

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
		public _003CLoadFile_003Ed__14(int _003C_003E1__state)
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

	private const int WaitMs = 50;

	private const long AK_BANK_PLATFORM_DATA_ALIGNMENT = 16L;

	private const long AK_BANK_PLATFORM_DATA_ALIGNMENT_MASK = 15L;

	public string bankName;

	public bool isLocalizedBank;

	private string m_bankPath;

	[HideInInspector]
	public uint ms_bankID;

	private IntPtr ms_pInMemoryBankPtr;

	private GCHandle ms_pinnedArray;

	private UnityWebRequest ms_www;

	private void Start()
	{
	}

	public void LoadNonLocalizedBank(string in_bankFilename)
	{
	}

	public void LoadLocalizedBank(string in_bankFilename)
	{
	}

	private uint AllocateAlignedBuffer(byte[] data)
	{
		return 0u;
	}

	[IteratorStateMachine(typeof(_003CLoadFile_003Ed__14))]
	private IEnumerator LoadFile()
	{
		return null;
	}

	private void DoLoadBank(string in_bankPath)
	{
	}

	private void OnDestroy()
	{
	}
}
