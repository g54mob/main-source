using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class State_EditMode : AGameState, IKeybindRegister
{
	[CompilerGenerated]
	private sealed class _003CStateProc_003Ed__10 : IEnumerator<object>, IEnumerator, IDisposable
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
		public _003CStateProc_003Ed__10(int _003C_003E1__state)
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

	private ObjectPlacementHandler placementHandler;

	private eControlScheme controlScheme;

	private bool recordedClickScreenPos;

	private Vector3 clickedScreenPos;

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

	[IteratorStateMachine(typeof(_003CStateProc_003Ed__10))]
	protected override IEnumerator StateProc()
	{
		return null;
	}
}
