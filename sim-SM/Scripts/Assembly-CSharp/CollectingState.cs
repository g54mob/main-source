using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

public class CollectingState : SecurityGuardState
{
	[CompilerGenerated]
	private sealed class _003COpenCrate_003Ed__6 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public CollectingState _003C_003E4__this;

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
		public _003COpenCrate_003Ed__6(int _003C_003E1__state)
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

	private readonly float m_DetectRadius;

	public override void OnEnter(SecurityGuardStateController stateController)
	{
	}

	public override void OnUpdate()
	{
	}

	public override void OnExit()
	{
	}

	private void FindNearbyProducts()
	{
	}

	[IteratorStateMachine(typeof(_003COpenCrate_003Ed__6))]
	private IEnumerator OpenCrate()
	{
		return null;
	}
}
