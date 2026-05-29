using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

namespace __Project__.Scripts.ControllerInputModule
{
	public class GamepadSelectableParentBill : GamepadSelectableParent
	{
		[CompilerGenerated]
		private sealed class _003CDelayedSetNeighboursGrid_003Ed__8 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public GamepadSelectableParentBill _003C_003E4__this;

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
			public _003CDelayedSetNeighboursGrid_003Ed__8(int _003C_003E1__state)
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
		private sealed class _003CDelayedSetNeighboursVertical_003Ed__10 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public GamepadSelectableParentBill _003C_003E4__this;

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
			public _003CDelayedSetNeighboursVertical_003Ed__10(int _003C_003E1__state)
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
		private GridLayoutGroup m_rentLayout;

		public bool isAnyRentLeft;

		public bool isAnyBillLeft;

		private int m_totalRentCount;

		private int m_totalBillCount;

		private readonly List<GamepadUISelectable> m_rentSelectables;

		private readonly List<GamepadUISelectable> m_billSelectables;

		public override void Initialize(WindowTab tab = null, bool includeInactive = true)
		{
		}

		[IteratorStateMachine(typeof(_003CDelayedSetNeighboursGrid_003Ed__8))]
		protected override IEnumerator DelayedSetNeighboursGrid()
		{
			return null;
		}

		protected override void SetNeighboursGrid()
		{
		}

		[IteratorStateMachine(typeof(_003CDelayedSetNeighboursVertical_003Ed__10))]
		protected override IEnumerator DelayedSetNeighboursVertical()
		{
			return null;
		}

		protected override void SetNeighboursVertical()
		{
		}
	}
}
