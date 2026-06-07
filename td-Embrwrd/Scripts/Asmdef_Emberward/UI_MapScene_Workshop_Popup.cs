using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class UI_MapScene_Workshop_Popup : APopupWindow
{
	private enum eWorkshopState
	{
		START = 0,
		MODIFY_CARD = 1,
		DESTROY_CARD = 2,
		ENHANCE_CARD = 3
	}

	[CompilerGenerated]
	private sealed class _003CCR_ShowWindowProc_003Ed__20 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public UI_MapScene_Workshop_Popup _003C_003E4__this;

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
		public _003CCR_ShowWindowProc_003Ed__20(int _003C_003E1__state)
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
	private Button button_ModifyCard;

	[SerializeField]
	private Button button_DestroyCard;

	[SerializeField]
	private Button button_EnhanceCard;

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

	private void OnClick_ModifyCard()
	{
	}

	private void OnSelectedCardFromBackpack_Modify(CardData data)
	{
	}

	private void OnClick_RemoveCard()
	{
	}

	private void OnClick_EnhanceCard()
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

	[IteratorStateMachine(typeof(_003CCR_ShowWindowProc_003Ed__20))]
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
