using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_InGameSelectCharacterPopup : APopupWindow
{
	[CompilerGenerated]
	private sealed class _003CCR_ShowWindow_003Ed__15 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public UI_InGameSelectCharacterPopup _003C_003E4__this;

		private int _003Ci_003E5__2;

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
		public _003CCR_ShowWindow_003Ed__15(int _003C_003E1__state)
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
	private TMP_Text text_CharacterName;

	[SerializeField]
	private UI_PlayerCharacterSkillInfo ui_SkillInfo;

	[SerializeField]
	private List<UI_Obj_IngameCharacterSelectEntry> list_characterSelectEntries;

	[SerializeField]
	private Button button_Confirm;

	[SerializeField]
	private List<Transform> list_InitAnimationObjects;

	[SerializeField]
	private eCharacterType selectedCharacterType;

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

	public void OnCharacterSelected(eCharacterType characterType, bool doPlaySound)
	{
	}

	public void StartWithCharacter(eCharacterType characterType)
	{
	}

	private void OnClickConfirmButton()
	{
	}

	private void ChangeCharacter()
	{
	}

	protected override void ShowWindowProc()
	{
	}

	[IteratorStateMachine(typeof(_003CCR_ShowWindow_003Ed__15))]
	private IEnumerator CR_ShowWindow()
	{
		return null;
	}

	protected override void CloseWindowProc()
	{
	}

	public override void OnJoystickModeActivated()
	{
	}

	public override void OnMouseModeActivated()
	{
	}

	private void SelectLastSelectedCharacter()
	{
	}

	private void RebuildNavigation()
	{
	}
}
