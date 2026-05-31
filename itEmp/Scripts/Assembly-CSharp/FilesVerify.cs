using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

public class FilesVerify : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CWaitingOnEnter_003Ed__15 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public FilesVerify _003C_003E4__this;

		private bool _003CcoroutineTrue_003E5__2;

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
		public _003CWaitingOnEnter_003Ed__15(int _003C_003E1__state)
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

	public DirectoryManager directoryManager;

	public yourComputerInSmallCorp urComputer;

	public ComputerVariables computerVariables;

	public ComputerStation computerStation;

	[Header("Object")]
	public GameObject ViewFileVerify;

	public TextMeshProUGUI File;

	public TextMeshProUGUI Status;

	public TextMeshProUGUI Info;

	[Header("File Data")]
	public string[] files;

	public string[] files_Code;

	public string[] files_Info;

	public bool playerIsVeryfiFilesError;

	public Coroutine EnterCoroutine;

	public void VerifyFilesInSystem()
	{
	}

	public void WhatNext()
	{
	}

	[IteratorStateMachine(typeof(_003CWaitingOnEnter_003Ed__15))]
	public IEnumerator WaitingOnEnter()
	{
		return null;
	}
}
