using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace __Project__.Scripts.Vending_Machine
{
	[RequireComponent(typeof(VendingMachine))]
	public class VendingIdleCollector : MonoBehaviour
	{
		[CompilerGenerated]
		private sealed class _003CIdleCollectionRoutine_003Ed__16 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public VendingIdleCollector _003C_003E4__this;

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
			public _003CIdleCollectionRoutine_003Ed__16(int _003C_003E1__state)
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
		private sealed class _003CRangeCheckRoutine_003Ed__17 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public VendingIdleCollector _003C_003E4__this;

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
			public _003CRangeCheckRoutine_003Ed__17(int _003C_003E1__state)
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
		private float m_RangeCheckInterval;

		[SerializeField]
		private float m_IdleCollectionRadius;

		private VendingMachine m_VendingMachine;

		private Coroutine m_IdleCollectionRoutine;

		private Coroutine m_RangeCheckRoutine;

		private WaitForSeconds m_RangeCheckRoutineWait;

		private WaitForSeconds m_IdleCollectionRoutineWait;

		private bool m_WillCollect;

		private bool m_IsIdle;

		private VendingMachine VendingMachine => null;

		private void Start()
		{
		}

		private void ExchangeProductAndMoney()
		{
		}

		public void ExchangeProduct_Order(int slotId)
		{
		}

		private void BeginIdleCollection()
		{
		}

		private void StopIdleCollection()
		{
		}

		[IteratorStateMachine(typeof(_003CIdleCollectionRoutine_003Ed__16))]
		private IEnumerator IdleCollectionRoutine()
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CRangeCheckRoutine_003Ed__17))]
		private IEnumerator RangeCheckRoutine()
		{
			return null;
		}

		private void InitialRangeCheck()
		{
		}

		private void CheckRange()
		{
		}

		private void OnRangeEnter()
		{
		}

		private void OnRangeExit()
		{
		}
	}
}
