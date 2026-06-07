using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public abstract class AGameState : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CStateProc_003Ed__7 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

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
		public _003CStateProc_003Ed__7(int _003C_003E1__state)
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
	protected eGameState type;

	private Coroutine coroutine_StateProcess;

	public eGameState Type => default(eGameState);

	public void StateStart(eGameState _stateType)
	{
	}

	protected abstract void StateInitProc();

	private void StateProcess()
	{
	}

	[IteratorStateMachine(typeof(_003CStateProc_003Ed__7))]
	protected virtual IEnumerator StateProc()
	{
		return null;
	}

	public void StateUpdate(float deltaTime)
	{
	}

	protected virtual void StateUpdateProc(float deltaTime)
	{
	}

	public void StateEnd()
	{
	}

	protected abstract void StateEndProc();
}
