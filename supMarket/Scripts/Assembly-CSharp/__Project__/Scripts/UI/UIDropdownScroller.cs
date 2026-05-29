using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using __Project__.Scripts.ControllerInputModule;

namespace __Project__.Scripts.UI
{
	public class UIDropdownScroller : GamepadUIHandler, ISelectHandler, IEventSystemHandler
	{
		[CompilerGenerated]
		private sealed class _003CDelayedInitialization_003Ed__9 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public UIDropdownScroller _003C_003E4__this;

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
			public _003CDelayedInitialization_003Ed__9(int _003C_003E1__state)
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

		private ScrollRect m_scrollRect;

		private float m_scrollPosition;

		private int m_horizontalLimit;

		private bool m_isInitialized;

		private int m_initializeTryCount;

		private bool m_isGamepad;

		[SerializeField]
		private bool m_isHorizontal;

		private void Start()
		{
		}

		private void OnEnable()
		{
		}

		[IteratorStateMachine(typeof(_003CDelayedInitialization_003Ed__9))]
		private IEnumerator DelayedInitialization()
		{
			return null;
		}

		private void OnDisable()
		{
		}

		private void CheckGamepad(bool isGamepad)
		{
		}

		public void Initialize()
		{
		}

		public void OnSelect(BaseEventData eventData)
		{
		}

		public virtual void Select()
		{
		}

		public void ResetInitialization()
		{
		}
	}
}
