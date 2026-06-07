using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_DifficultySelection_Popup : APopupWindow
{
	public enum eSelectedResult
	{
		NONE = -1,
		CASUAL = 0,
		NORMAL = 1,
		HEROIC = 2,
		ENDLESS_MODE = 3,
		ENIGMA_SANCTUM = 4
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass26_0
	{
		public int checkWindowResult;

		internal void _003CCR_ClickAdventureModeButtonProcess_003Eb__0(bool result)
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CCR_ClickAdventureModeButtonProcess_003Ed__26 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		private _003C_003Ec__DisplayClass26_0 _003C_003E8__1;

		public UI_DifficultySelection_Popup _003C_003E4__this;

		public Action clickProcess;

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
		public _003CCR_ClickAdventureModeButtonProcess_003Ed__26(int _003C_003E1__state)
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
	private UI_Obj_DifficultySelectionBlock block_Casual;

	[SerializeField]
	private UI_Obj_DifficultySelectionBlock block_Normal;

	[SerializeField]
	private UI_Obj_DifficultySelectionBlock block_Heroic;

	[SerializeField]
	private UI_Obj_DifficultySelectionBlock block_Event;

	[SerializeField]
	private UI_Obj_DifficultySelectionBlock block_EnigmaSanctum;

	[SerializeField]
	private Transform node_Casual;

	[SerializeField]
	private Transform node_Normal;

	[SerializeField]
	private Transform node_Heroic;

	[SerializeField]
	private Transform node_Event;

	[SerializeField]
	private Transform node_EnigmaSanctum;

	[SerializeField]
	private Button button_Casual;

	[SerializeField]
	private Button button_Normal;

	[SerializeField]
	private Button button_Heroic;

	[SerializeField]
	private Button button_Event;

	[SerializeField]
	private Button button_EnigmaSanctum;

	[SerializeField]
	private Button button_Close;

	[SerializeField]
	private TMP_Text text_HeroicLimitDesc;

	[SerializeField]
	private TMP_Text text_EventLimitDesc;

	[SerializeField]
	private TMP_Text text_EventLimitDesc_EnigmaSanctum;

	private bool isButtonClicked;

	public bool IsDifficultyChosen;

	public Action<eSelectedResult> OnWindowFinishCallback;

	protected override void ShowWindowProc()
	{
	}

	private void RemoveUselessNavigationOnButton(Button button)
	{
	}

	protected override void CloseWindowProc()
	{
	}

	[IteratorStateMachine(typeof(_003CCR_ClickAdventureModeButtonProcess_003Ed__26))]
	private IEnumerator CR_ClickAdventureModeButtonProcess(Action clickProcess)
	{
		return null;
	}

	private void OnClickButton_Casual()
	{
	}

	private void ClickButtonProcess_Casual()
	{
	}

	private void OnClickButton_Normal()
	{
	}

	private void ClickButtonProcess_Normal()
	{
	}

	private void OnClickButton_Heroic()
	{
	}

	private void ClickButtonProcess_Heroic()
	{
	}

	private void OnClickButton_Event()
	{
	}

	private void OnClickButton_EnigmaSanctum()
	{
	}

	private void DeactivateButtons()
	{
	}

	private void OnButtonCloseClick()
	{
	}

	private void Toggle(bool isOn)
	{
	}

	public override void OnTriggerKeybind(string keyName)
	{
	}

	private void Update()
	{
	}

	public override void OnJoystickModeActivated()
	{
	}

	public override void OnMouseModeActivated()
	{
	}
}
