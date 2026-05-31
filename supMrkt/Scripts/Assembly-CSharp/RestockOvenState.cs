using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.AI;

public class RestockOvenState : Baker.IState
{
	[CompilerGenerated]
	private sealed class _003CFillOvenDisplay_003Ed__9 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public RestockOvenState _003C_003E4__this;

		private DisplaySlot _003CnewSlot_003E5__2;

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
		public _003CFillOvenDisplay_003Ed__9(int _003C_003E1__state)
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

	private NavMeshAgent m_Agent;

	private Baker m_Baker;

	private bool m_ReachedOvenSlot;

	private const float m_RotationSmoothness = 5f;

	public RestockOvenState(Baker baker)
	{
	}

	public void Enter()
	{
	}

	public void Update()
	{
	}

	private void LookAtOvenSlot()
	{
	}

	public void Exit()
	{
	}

	[IteratorStateMachine(typeof(_003CFillOvenDisplay_003Ed__9))]
	private IEnumerator FillOvenDisplay()
	{
		return null;
	}

	private DisplaySlot GetSlotSameProductSameOven()
	{
		return null;
	}

	private DisplaySlot GetOvenSlotSameProduct()
	{
		return null;
	}

	private void MoveTo(Vector3 target)
	{
	}
}
