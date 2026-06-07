using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public abstract class AUISituational : AUI
{
	[CompilerGenerated]
	private sealed class _003CCR_CloseAnimatorInSeconds_003Ed__9 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public AUISituational _003C_003E4__this;

		public float time;

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
		public _003CCR_CloseAnimatorInSeconds_003Ed__9(int _003C_003E1__state)
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
	protected Animator animator;

	[SerializeField]
	private float time_AnimatorDeactivateOnToggleOff;

	private Coroutine coroutine_CloseAnimatorInSeconds;

	private bool isUIActivated;

	private bool doCloseInSeconds;

	public bool IsUIActivated => false;

	public void Toggle(bool isOn)
	{
	}

	private void DeactivateAnimatorInSeconds(float time)
	{
	}

	[IteratorStateMachine(typeof(_003CCR_CloseAnimatorInSeconds_003Ed__9))]
	private IEnumerator CR_CloseAnimatorInSeconds(float time)
	{
		return null;
	}

	protected virtual void ToggleOn()
	{
	}

	protected virtual void ToggleOff()
	{
	}
}
