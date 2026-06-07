using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_BossExtraSkill_Popup : APopupWindow
{
	[Serializable]
	public class BossSkillData
	{
		public int worldIndex;

		public int level;

		public Sprite skillImage;

		public BossSkillData(Sprite skillImage)
		{
		}
	}

	[SerializeField]
	private Button button_Close;

	[SerializeField]
	private List<UI_Obj_BossExtraSkillEntry> list_ExtraSkillEntries;

	[SerializeField]
	private List<BossSkillData> list_BossSkillData;

	protected override void OnEnableProc()
	{
	}

	protected override void OnDisableProc()
	{
	}

	protected override void Start()
	{
	}

	private void OnCloseButtonClicked()
	{
	}

	protected override void ShowWindowProc()
	{
	}

	protected override void CloseWindowProc()
	{
	}

	public override void OnTriggerKeybind(string keyName)
	{
	}

	public override void OnJoystickModeActivated()
	{
	}

	public override void OnMouseModeActivated()
	{
	}
}
