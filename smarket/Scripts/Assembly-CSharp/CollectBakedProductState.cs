using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.AI;

public class CollectBakedProductState : Baker.IState
{
	[CompilerGenerated]
	private sealed class _003CCollectBakedProducts_003Ed__7 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public CollectBakedProductState _003C_003E4__this;

		private List<DisplaySlot> _003Cslots_003E5__2;

		private int _003Ci_003E5__3;

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
		public _003CCollectBakedProducts_003Ed__7(int _003C_003E1__state)
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
	private sealed class _003CCollectFromSlot_003Ed__8 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public DisplaySlot slot;

		public CollectBakedProductState _003C_003E4__this;

		private ProductSO _003CproductSO_003E5__2;

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
		public _003CCollectFromSlot_003Ed__8(int _003C_003E1__state)
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

	public CollectBakedProductState(Baker baker)
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

	[IteratorStateMachine(typeof(_003CCollectBakedProducts_003Ed__7))]
	private IEnumerator CollectBakedProducts()
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003CCollectFromSlot_003Ed__8))]
	private IEnumerator CollectFromSlot(DisplaySlot slot)
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
