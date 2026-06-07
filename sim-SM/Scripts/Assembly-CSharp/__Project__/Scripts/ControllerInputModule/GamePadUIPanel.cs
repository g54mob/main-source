using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using __Project__.Scripts.Computer;

namespace __Project__.Scripts.ControllerInputModule
{
	public class GamePadUIPanel : MonoBehaviour
	{
		[CompilerGenerated]
		private sealed class _003CDelayedInitialize_003Ed__18 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public GamePadUIPanel _003C_003E4__this;

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
			public _003CDelayedInitialize_003Ed__18(int _003C_003E1__state)
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

		public GamePadUIPanel parentPanel;

		public GameObject firstSelected;

		public bool focusOverride;

		[HideInInspector]
		public List<GamepadUIHandler> handlers;

		[SerializeField]
		public bool m_isComputerPanel;

		private __Project__.Scripts.Computer.Computer m_Computer;

		private bool m_isFocused;

		private bool m_IsOpened;

		public bool IsFocused
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool IsPauseMenu => false;

		private void Awake()
		{
		}

		private void OnGamepadConnected(bool isGamepad)
		{
		}

		public void Initialize()
		{
		}

		private void OnEnable()
		{
		}

		public void OpenPanel()
		{
		}

		[IteratorStateMachine(typeof(_003CDelayedInitialize_003Ed__18))]
		private IEnumerator DelayedInitialize()
		{
			return null;
		}

		public void ClosePanel(bool isFromRoot = false)
		{
		}

		public void HoldPanel()
		{
		}

		public void DisablePanel(bool willCloseHandlers = false)
		{
		}

		public void CloseOnlyPanel(bool willResetSelectedObject = true)
		{
		}

		public void FullClose()
		{
		}

		public void CloseHandlers(bool willKeyboardsClose = true)
		{
		}

		private void OnDisable()
		{
		}
	}
}
