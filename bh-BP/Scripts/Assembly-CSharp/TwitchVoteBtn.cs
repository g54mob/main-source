using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using I2.Loc;
using MEC;
using TMPro;
using UnityEngine;

public class TwitchVoteBtn : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003C_RunCountdown_003Ed__10 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public TwitchVoteBtn _003C_003E4__this;

		public float secs;

		private float _003CstartTime_003E5__2;

		float IEnumerator<float>.Current
		{
			[DebuggerHidden]
			get
			{
				return 0f;
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
		public _003C_RunCountdown_003Ed__10(int _003C_003E1__state)
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

	public GameObject WrapperBtn;

	public CoolButton Btn;

	public Localize LocBtn;

	public bool IsVoteInProgress;

	private CoroutineHandle _countdownAnim;

	public GameObject WrapperVoteInProgress;

	public Localize LocTimerLabel;

	public TextMeshProUGUI TxtTimer;

	public void SetVoteInProgress(bool isOn)
	{
	}

	public void RunCountdown(float secs)
	{
	}

	[IteratorStateMachine(typeof(_003C_RunCountdown_003Ed__10))]
	private IEnumerator<float> _RunCountdown(float secs)
	{
		return null;
	}

	public void CompleteCountdown()
	{
	}
}
