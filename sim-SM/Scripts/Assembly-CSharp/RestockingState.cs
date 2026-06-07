using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

public class RestockingState : SecurityGuardState
{
	[CompilerGenerated]
	private sealed class _003CProductRestockLoop_003Ed__8 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public RestockingState _003C_003E4__this;

		private List<Product>.Enumerator _003C_003E7__wrap1;

		private int _003CproductID_003E5__3;

		private DisplaySlot _003CtargetDisplaySlot_003E5__4;

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
		public _003CProductRestockLoop_003Ed__8(int _003C_003E1__state)
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

		private void _003C_003Em__Finally1()
		{
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
		}
	}

	private readonly SecurityGuardStateController.Status m_State;

	private SecurityGuard m_SecurityGuard;

	private Crate m_Crate;

	private Restocker m_Restocker;

	private List<DisplaySlot> m_CachedDisplaySlots;

	public override void OnEnter(SecurityGuardStateController stateController)
	{
	}

	public override void OnUpdate()
	{
	}

	public override void OnExit()
	{
	}

	[IteratorStateMachine(typeof(_003CProductRestockLoop_003Ed__8))]
	private IEnumerator ProductRestockLoop()
	{
		return null;
	}

	private bool IsDisplayAvailable(int productID)
	{
		return false;
	}

	private void SubscribeEvents()
	{
	}

	private void UnSubscribeEvents()
	{
	}
}
