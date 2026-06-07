using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

public class UI_EndlessTimeScore : AUISituational
{
	[CompilerGenerated]
	private sealed class _003CCR_ScoreLerpValue_003Ed__11 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public UI_EndlessTimeScore _003C_003E4__this;

		public int value;

		private float _003Cduration_003E5__2;

		private float _003Ctimer_003E5__3;

		private int _003CstartValue_003E5__4;

		private int _003CendValue_003E5__5;

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
		public _003CCR_ScoreLerpValue_003Ed__11(int _003C_003E1__state)
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

	[SerializeField]
	private TMP_Text text_Score;

	private int curScoreValue;

	private string scoreMsgString;

	private Coroutine coroutine_ScoreChange;

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void Start()
	{
	}

	private void RequestToggleTimeScoreUI(bool isOn)
	{
	}

	private void UpdateTimeScoreUI(int value, int delta)
	{
	}

	private void OnScoreChanged(int Score, int delta)
	{
	}

	private void SetScoreText(int value)
	{
	}

	[IteratorStateMachine(typeof(_003CCR_ScoreLerpValue_003Ed__11))]
	private IEnumerator CR_ScoreLerpValue(int value)
	{
		return null;
	}
}
