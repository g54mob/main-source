using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Rewired;
using UnityEngine;
using UnityEngine.UI;

public class UI_SettingPage_Popup : APopupWindow
{
	[CompilerGenerated]
	private sealed class _003CCR_ShowWindowProc_003Ed__13 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public UI_SettingPage_Popup _003C_003E4__this;

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
		public _003CCR_ShowWindowProc_003Ed__13(int _003C_003E1__state)
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
	private Button button_Exit;

	[SerializeField]
	private List<AUIGameSettingItem> list_GameSettingItems;

	[SerializeField]
	private List<AUIGameSettingItem> list_OnlyInCoinPage;

	[SerializeField]
	private UI_ScrollView_AutoScrollToSelected scrollAutoScroller;

	private float initTimer;

	protected override void OnEnableProc()
	{
	}

	private void OnInputSourceChanged(ControllerType type)
	{
	}

	private void Update()
	{
	}

	protected override void OnDisableProc()
	{
	}

	private void OnGameSettingChanged()
	{
	}

	private void OnClickButton_Exit()
	{
	}

	private void Toggle(bool isOn)
	{
	}

	protected override void ShowWindowProc()
	{
	}

	[IteratorStateMachine(typeof(_003CCR_ShowWindowProc_003Ed__13))]
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

	private void RebuildNavigation()
	{
	}
}
