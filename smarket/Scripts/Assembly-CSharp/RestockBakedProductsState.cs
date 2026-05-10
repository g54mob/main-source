using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.AI;

public class RestockBakedProductsState : Baker.IState
{
	[CompilerGenerated]
	private sealed class _003CRestockToSlot_003Ed__9 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public RestockBakedProductsState _003C_003E4__this;

		public int productID;

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
		public _003CRestockToSlot_003Ed__9(int _003C_003E1__state)
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

	[CompilerGenerated]
	private sealed class _003CStartRestockingSequence_003Ed__8 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public RestockBakedProductsState _003C_003E4__this;

		public DisplaySlot targetSlot;

		private int _003CproductCount_003E5__2;

		private int _003Cindex_003E5__3;

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
		public _003CStartRestockingSequence_003Ed__8(int _003C_003E1__state)
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

	private Baker m_Baker;

	private NavMeshAgent m_Agent;

	private bool m_IsReached;

	private DisplaySlot m_TargetDisplaySlot;

	public RestockBakedProductsState(Baker baker)
	{
	}

	public void Enter()
	{
	}

	public void Update()
	{
	}

	public void Exit()
	{
	}

	[IteratorStateMachine(typeof(_003CStartRestockingSequence_003Ed__8))]
	private IEnumerator StartRestockingSequence(DisplaySlot targetSlot)
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003CRestockToSlot_003Ed__9))]
	private IEnumerator RestockToSlot(int productID)
	{
		return null;
	}

	private void MoveTo(Vector3 target)
	{
	}

	private void LookAt(Vector3 target)
	{
	}
}
