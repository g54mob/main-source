using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class UI_MapScene_Campsite_Popup : APopupWindow
{
	private enum eWorkshopState
	{
		START = 0,
		MODIFY_CARD = 1,
		DESTROY_CARD = 2,
		ENHANCE_CARD = 3
	}

	[CompilerGenerated]
	private sealed class _003CCR_ShowWindowProc_003Ed__25 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public UI_MapScene_Campsite_Popup _003C_003E4__this;

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
		public _003CCR_ShowWindowProc_003Ed__25(int _003C_003E1__state)
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
	private sealed class _003CCR_WaitForProcEnd_003Ed__16 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public APopupWindow window;

		public UI_MapScene_Campsite_Popup _003C_003E4__this;

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
		public _003CCR_WaitForProcEnd_003Ed__16(int _003C_003E1__state)
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
	private Button button_Leave;

	[SerializeField]
	private Button button_Recover;

	[SerializeField]
	private Button button_Circus;

	[SerializeField]
	private Image image_RecoverBanned;

	[SerializeField]
	private Image image_CircusNotInDemo;

	[SerializeField]
	private Image image_AltarNotInDemo;

	[SerializeField]
	private Button button_Exchange;

	[SerializeField]
	private CanvasGroup canvasGroup_Buttons;

	private bool isCardSelected;

	private CardData enhanceCardData;

	protected override void OnEnableProc()
	{
	}

	protected override void OnDisableProc()
	{
	}

	protected override void Start()
	{
	}

	private void Update()
	{
	}

	private void OnClick_Leave()
	{
	}

	private void OnClick_Recover()
	{
	}

	[IteratorStateMachine(typeof(_003CCR_WaitForProcEnd_003Ed__16))]
	private IEnumerator CR_WaitForProcEnd(APopupWindow window)
	{
		return null;
	}

	private void OnSelectedCardFromBackpack_Modify(CardData data)
	{
	}

	private void OnClick_Circus()
	{
	}

	private void OnClick_Exchange()
	{
	}

	private void OnSelectedCardFromBackpack_Enhance(CardData cardData)
	{
	}

	private void OnEnhanceFinish()
	{
	}

	private void Toggle(bool isOn)
	{
	}

	protected override void ShowWindowProc()
	{
	}

	[IteratorStateMachine(typeof(_003CCR_ShowWindowProc_003Ed__25))]
	private IEnumerator CR_ShowWindowProc()
	{
		return null;
	}

	protected override void CloseWindowProc()
	{
	}

	public override void OnTriggerKeybind(string keyName)
	{
	}

	public override void OnWindowRegainFocus()
	{
	}

	public override void OnJoystickModeActivated()
	{
	}

	public override void OnMouseModeActivated()
	{
	}

	private void RebuildNavigationAndSelect()
	{
	}
}
