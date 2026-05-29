using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PatrolingState : SecurityGuardState
{
	[CompilerGenerated]
	private sealed class _003CPatroling_003Ed__8 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public PatrolingState _003C_003E4__this;

		private int _003Crnd_003E5__2;

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
		public _003CPatroling_003Ed__8(int _003C_003E1__state)
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

	private readonly SecurityGuardStateController.Status m_State;

	private List<DisplaySlot> m_DisplaySlots;

	private Vector3 m_Target;

	private SecurityGuard m_SecurityGuard;

	private Coroutine m_Patrol;

	public override void OnEnter(SecurityGuardStateController stateController)
	{
	}

	public override void OnUpdate()
	{
	}

	public override void OnExit()
	{
	}

	[IteratorStateMachine(typeof(_003CPatroling_003Ed__8))]
	private IEnumerator Patroling()
	{
		return null;
	}

	private Vector3 FindTarget()
	{
		return default(Vector3);
	}
}
