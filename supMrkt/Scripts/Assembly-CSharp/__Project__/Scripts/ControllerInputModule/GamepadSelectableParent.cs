using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

namespace __Project__.Scripts.ControllerInputModule
{
	public class GamepadSelectableParent : MonoBehaviour
	{
		[CompilerGenerated]
		private sealed class _003CDelayedSetNeighboursGrid_003Ed__14 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public GamepadSelectableParent _003C_003E4__this;

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
			public _003CDelayedSetNeighboursGrid_003Ed__14(int _003C_003E1__state)
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
		private sealed class _003CDelayedSetNeighboursHorizontal_003Ed__13 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public GamepadSelectableParent _003C_003E4__this;

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
			public _003CDelayedSetNeighboursHorizontal_003Ed__13(int _003C_003E1__state)
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
		private sealed class _003CDelayedSetNeighboursVertical_003Ed__16 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public GamepadSelectableParent _003C_003E4__this;

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
			public _003CDelayedSetNeighboursVertical_003Ed__16(int _003C_003E1__state)
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
		protected GridLayoutGroup m_layout;

		[SerializeField]
		public GamePadUIPanel m_parentPanel;

		[SerializeField]
		protected bool m_isVertical;

		[SerializeField]
		protected bool m_isHorizontal;

		public bool isAnyObjectLeft;

		protected int m_xSize;

		protected int m_totalCount;

		protected List<GamepadUISelectable> m_selectables;

		protected WindowTab m_tab;

		private void Awake()
		{
		}

		private void OnGamePadConnected(bool isGamepad)
		{
		}

		public virtual void Initialize(WindowTab tab = null, bool includeInactive = true)
		{
		}

		private void SetNeighboursHorizontal()
		{
		}

		[IteratorStateMachine(typeof(_003CDelayedSetNeighboursHorizontal_003Ed__13))]
		protected virtual IEnumerator DelayedSetNeighboursHorizontal()
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CDelayedSetNeighboursGrid_003Ed__14))]
		protected virtual IEnumerator DelayedSetNeighboursGrid()
		{
			return null;
		}

		protected virtual void SetNeighboursGrid()
		{
		}

		[IteratorStateMachine(typeof(_003CDelayedSetNeighboursVertical_003Ed__16))]
		protected virtual IEnumerator DelayedSetNeighboursVertical()
		{
			return null;
		}

		protected virtual void SetNeighboursVertical()
		{
		}

		public virtual void SwitchHints(GamepadUISelectable selectableObject)
		{
		}

		public void SetSelectables(List<GamepadUISelectable> selectables)
		{
		}

		public void ResetParentPanel()
		{
		}
	}
}
