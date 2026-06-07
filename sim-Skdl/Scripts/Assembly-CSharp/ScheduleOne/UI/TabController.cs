using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using ScheduleOne.DevUtilities;
using UnityEngine;

namespace ScheduleOne.UI
{
	public class TabController : MonoBehaviour
	{
		[CompilerGenerated]
		private sealed class _003CDoDelayRoutine_003Ed__20 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public float delay;

			public Action onComplete;

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
			public _003CDoDelayRoutine_003Ed__20(int _003C_003E1__state)
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
		private sealed class _003CDoMoveTabIndicatorRoutine_003Ed__15 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public TabController _003C_003E4__this;

			private float _003Celapsed_003E5__2;

			private Vector2 _003CstartingPosition_003E5__3;

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
			public _003CDoMoveTabIndicatorRoutine_003Ed__15(int _003C_003E1__state)
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
		[Header("Components")]
		private RectTransform _tabIndicator;

		[SerializeField]
		private List<TabItemUI> _tabItems;

		[Header("Settings")]
		[SerializeField]
		private float _indicatorMoveTime;

		[SerializeField]
		private AnimationCurve _indicatorMoveCurve;

		[SerializeField]
		[Header("Fonts")]
		private ColorFont _tabColorFont;

		private int _currentTabIndex;

		private Vector2 _indicatorPosition;

		private Coroutine _moveIndicatorCo;

		private TabSelectedEvent _onTabSelected;

		public int CurrentTabIndex => 0;

		public void Start()
		{
		}

		private void SetTab(int index)
		{
		}

		public void SetToSelectedTab(bool instantIndicatorMove = false)
		{
		}

		public void SetTab(int index, bool instantIndicatorMove = false)
		{
		}

		[IteratorStateMachine(typeof(_003CDoMoveTabIndicatorRoutine_003Ed__15))]
		private IEnumerator DoMoveTabIndicatorRoutine()
		{
			return null;
		}

		public void SetTabIndicatorText(int index, string text)
		{
		}

		public void HideTabIndicator(int index)
		{
		}

		public void SubscribeToTabSelected(TabSelectedEvent handler)
		{
		}

		public void UnsubscribeFromTabSelected(TabSelectedEvent handler)
		{
		}

		[IteratorStateMachine(typeof(_003CDoDelayRoutine_003Ed__20))]
		private IEnumerator DoDelayRoutine(float delay, Action onComplete)
		{
			return null;
		}
	}
}
