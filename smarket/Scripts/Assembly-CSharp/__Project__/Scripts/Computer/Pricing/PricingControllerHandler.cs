using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using __Project__.Scripts.ControllerInputModule;

namespace __Project__.Scripts.Computer.Pricing
{
	public class PricingControllerHandler : NoktaSingleton<PricingControllerHandler>
	{
		[CompilerGenerated]
		private sealed class _003CDelayedNumpadSwitch_003Ed__16 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public PricingControllerHandler _003C_003E4__this;

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
			public _003CDelayedNumpadSwitch_003Ed__16(int _003C_003E1__state)
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
		private TabManager m_tabManager;

		[SerializeField]
		private GamePadUIPanel m_PricingUIPanel;

		[SerializeField]
		private List<Button> m_tabs;

		[SerializeField]
		private NumpadSystem m_numpadSystem;

		[SerializeField]
		private VirtualKeyboard m_VirtualKeyboard;

		[SerializeField]
		private Color m_SortSelectedColor;

		[SerializeField]
		private Color m_SortDefaultColor;

		private int m_tabIndex;

		private PricingSortingButton m_currentSortingButton;

		private PricingItem m_lastSelectedItem;

		public GamePadUIPanel GamePadUIPanel => null;

		private void OnEnable()
		{
		}

		public void SwitchTab(bool isLeft)
		{
		}

		public void SortFromGamepad()
		{
		}

		public void OpenInputField(TMP_InputField inputField)
		{
		}

		[IteratorStateMachine(typeof(_003CDelayedNumpadSwitch_003Ed__16))]
		private IEnumerator DelayedNumpadSwitch()
		{
			return null;
		}

		private void SwitchNumpad(bool isGamepad)
		{
		}

		public void ConfirmInputField()
		{
		}

		public void CloseNumpad()
		{
		}

		public void CloseKeyboard()
		{
		}

		public void OpenKeyboard()
		{
		}

		public void OpenDiscountPanel()
		{
		}

		public void CloseDiscountPanel()
		{
		}

		private void OnDisable()
		{
		}

		private void DisablePanel()
		{
		}
	}
}
