using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Rewired.Glyphs.UnityUI;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_SelectCharacterPopup : APopupWindow
{
	protected enum eState
	{
		NONE = 0,
		SelectCharacter = 1,
		SelectEmber = 2
	}

	[CompilerGenerated]
	private sealed class _003CCR_ShowWindowProc_003Ed__43 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

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
		public _003CCR_ShowWindowProc_003Ed__43(int _003C_003E1__state)
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
	private List<Obj_UI_CharacterSelectEntry> list_CharacterSelectEntries;

	[SerializeField]
	private List<UI_Obj_CharacterSkillEntry> list_CharacterSkillEntries;

	[SerializeField]
	private GameObject node_CharacterSkillEntry;

	[SerializeField]
	private TMP_Text text_Title;

	[SerializeField]
	private TMP_Text text_CharacterName;

	[SerializeField]
	private TMP_Text text_CharacterDescription;

	[SerializeField]
	private TMP_Text text_CharacterAbility;

	[SerializeField]
	private TMP_Text text_EmberName_Small;

	[SerializeField]
	private TMP_Text text_EmberName;

	[SerializeField]
	private TMP_Text text_EmberAbility;

	[SerializeField]
	private TMP_Text text_EmberUnlockRequirement;

	[SerializeField]
	private UnityUITextMeshProGlyphHelper text_ClickToSwitchFlame;

	[SerializeField]
	private UI_PlayerEmber ui_PlayerEmber;

	[SerializeField]
	private GameObject node_EventCharacterDescription;

	[SerializeField]
	private TMP_Text text_EventCharacterDescription;

	[SerializeField]
	private Button button_Ember;

	[SerializeField]
	private Button button_SelectEmber_Arrow_L;

	[SerializeField]
	private Button button_SelectEmber_Arrow_R;

	[SerializeField]
	private Button button_OK;

	private bool isSelected;

	private eCharacterType currentCharacterType;

	private eEmberType lastUnlockedEmberType;

	private eEmberType currentEmberType;

	private eState state;

	private List<eEmberType> list_EmberDisplayOrder;

	private int unlockRequirement_Scholar;

	private int unlockRequirement_Merchant;

	private int unlockRequirement_Sorcerer;

	private int unlockRequirement_Witch;

	private int unlockRequirement_Chunk;

	private int unlockRequirement_Tiny;

	protected override void OnEnableProc()
	{
	}

	protected override void OnDisableProc()
	{
	}

	private void Update()
	{
	}

	protected override void ShowWindowProc()
	{
	}

	private void OnClickButton_Ember()
	{
	}

	private void OnClickSelectEmberArrowL()
	{
	}

	private void OnClickSelectEmberArrowR()
	{
	}

	private void UpdateEmberInfo(eEmberType emberType)
	{
	}

	private void OnClickOK()
	{
	}

	private void GetCharacterSelectEntries()
	{
	}

	protected void SwitchState(eState state)
	{
	}

	[IteratorStateMachine(typeof(_003CCR_ShowWindowProc_003Ed__43))]
	private IEnumerator CR_ShowWindowProc()
	{
		return null;
	}

	protected override void CloseWindowProc()
	{
	}

	public void ShowCharacterInfo(eCharacterType characterType)
	{
	}

	public string GetUnlockDescription(eCharacterType characterType)
	{
		return null;
	}

	public void OnCharacterSelected(eCharacterType characterType)
	{
	}

	public override void OnTriggerKeybind(string keyName)
	{
	}

	private void UpdateSwitchFlameInputDescription()
	{
	}

	public void OnJoystickChooseCharacter(eCharacterType characterType)
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
