using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class ChaseState : SecurityGuardState
{
	[CompilerGenerated]
	private sealed class _003CFollow_003Ed__8 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public ChaseState _003C_003E4__this;

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
		public _003CFollow_003Ed__8(int _003C_003E1__state)
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

	private Shoplifter m_Shoplifter;

	private readonly float m_CatchingDistance;

	private readonly SecurityGuardStateController.Status m_State;

	private readonly WaitForSeconds m_WaitForSec;

	private Coroutine m_Coroutine;

	public override void OnEnter(SecurityGuardStateController stateController)
	{
	}

	public override void OnUpdate()
	{
	}

	public override void OnExit()
	{
	}

	[IteratorStateMachine(typeof(_003CFollow_003Ed__8))]
	private IEnumerator Follow()
	{
		return null;
	}
}
