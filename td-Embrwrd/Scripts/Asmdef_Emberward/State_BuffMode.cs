using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

public class State_BuffMode : AGameState, IKeybindRegister
{
	[CompilerGenerated]
	private sealed class _003CStateProc_003Ed__6 : IEnumerator<object>, IEnumerator, IDisposable
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
		public _003CStateProc_003Ed__6(int _003C_003E1__state)
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

	private bool isFirstFrame;

	private bool isMouseDownOnEnter;

	protected override void StateInitProc()
	{
	}

	protected override void StateEndProc()
	{
	}

	protected override void StateUpdateProc(float deltaTime)
	{
	}

	public void OnTriggerKeybind(string keyName)
	{
	}

	[IteratorStateMachine(typeof(_003CStateProc_003Ed__6))]
	protected override IEnumerator StateProc()
	{
		return null;
	}
}
