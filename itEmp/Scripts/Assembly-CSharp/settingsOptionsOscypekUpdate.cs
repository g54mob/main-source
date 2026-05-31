using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class settingsOptionsOscypekUpdate : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CCheckIsNewSystemVersion_003Ed__15 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public settingsOptionsOscypekUpdate _003C_003E4__this;

		private int _003Ci_003E5__2;

		private int _003Cj_003E5__3;

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
		public _003CCheckIsNewSystemVersion_003Ed__15(int _003C_003E1__state)
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
	private sealed class _003CDownloadNewSystemUpdate_003Ed__16 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public settingsOptionsOscypekUpdate _003C_003E4__this;

		private int _003Ci_003E5__2;

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
		public _003CDownloadNewSystemUpdate_003Ed__16(int _003C_003E1__state)
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

	[Header("Components")]
	public yourComputerInSmallCorp urComputer;

	[Header("Button - Update")]
	public Image updateButton;

	public string[] StatusButton;

	public TextMeshProUGUI Text_Button_Status;

	public GameObject buttonUpdate;

	[Header("Title - what going on")]
	public string[] StatusUpdateTitle;

	public TextMeshProUGUI Text_Update_Title;

	public TextMeshProUGUI Text_Update_Description;

	[Header("Variables")]
	public bool isCheckedNewSystem;

	public bool isCheckedSystemAndMustBeInstall;

	public bool isMustBeRestart;

	public bool isDownloadingUpdate;

	[HideInInspector]
	public int downloadingStatusProcent;

	public Coroutine updatingCoroutine;

	public void UpdateSystem()
	{
	}

	[IteratorStateMachine(typeof(_003CCheckIsNewSystemVersion_003Ed__15))]
	public IEnumerator CheckIsNewSystemVersion()
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003CDownloadNewSystemUpdate_003Ed__16))]
	public IEnumerator DownloadNewSystemUpdate()
	{
		return null;
	}

	public void VeifyButtonText()
	{
	}

	public void VerifyTtileText()
	{
	}
}
