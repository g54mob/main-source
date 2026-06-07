using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

public class UI_StageAnnounce : AUISituational
{
	[CompilerGenerated]
	private sealed class _003CCR_Proc_003Ed__5 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public UI_StageAnnounce _003C_003E4__this;

		public float duration;

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
		public _003CCR_Proc_003Ed__5(int _003C_003E1__state)
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
	private TMP_Text text_StageName;

	[SerializeField]
	private TMP_Text text_StageDescription;

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void OnShowStageAnnounce(int index, float duration)
	{
	}

	[IteratorStateMachine(typeof(_003CCR_Proc_003Ed__5))]
	private IEnumerator CR_Proc(float duration)
	{
		return null;
	}
}
