using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Events;
using __Project__.Scripts.Computer;

namespace __Project__.Scripts.ControllerInputModule
{
	public class GamepadUIFunctionLibrary : MonoBehaviour
	{
		[CompilerGenerated]
		private sealed class _003CTabSwitchDelay_003Ed__10 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public GamepadUIFunctionLibrary _003C_003E4__this;

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
			public _003CTabSwitchDelay_003Ed__10(int _003C_003E1__state)
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

		[HideInInspector]
		public GamePadUIPanel lastOpenedMenu;

		private GamePadUIPanel m_OwnerPanel;

		private __Project__.Scripts.Computer.Computer m_Computer;

		[Header("Tab References")]
		[SerializeField]
		private TabManager m_tabManager;

		[SerializeField]
		private List<GameObject> m_tabs;

		private int m_TabIndex;

		[SerializeField]
		private UnityEvent m_backupBackAction;

		[SerializeField]
		private UnityEvent m_backupNorthAction;

		[SerializeField]
		private UnityEvent m_backupWestAction;

		[HideInInspector]
		public bool isInsideSelectable;

		private void Start()
		{
		}

		private void OnEnable()
		{
		}

		private void ArrangeTabButtons(bool _ = false)
		{
		}

		public void SwitchTab(bool isLeft)
		{
		}

		[IteratorStateMachine(typeof(_003CTabSwitchDelay_003Ed__10))]
		private IEnumerator TabSwitchDelay()
		{
			return null;
		}

		public void RefreshTab()
		{
		}

		public void ConfirmObject()
		{
		}

		public void BackFromObject()
		{
		}

		public void SelectableNorthAction()
		{
		}

		public void SelectableWestAction()
		{
		}

		public void SelectableRightJoystickClick()
		{
		}

		public void SelectableRightJoystick(bool isLeft)
		{
		}

		public void SelectableDPadAction(bool isDec)
		{
		}

		public void SelectableLeftJoystick(bool isLeft)
		{
		}

		public void SelectableTriggerAction(bool isLeft)
		{
		}

		private void OnDisable()
		{
		}
	}
}
