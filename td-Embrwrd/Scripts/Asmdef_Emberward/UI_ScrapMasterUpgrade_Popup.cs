using System;
using System.Collections.Generic;
using UnityEngine;

public class UI_ScrapMasterUpgrade_Popup : APopupWindow
{
	[Serializable]
	public class UpgradeButtonData
	{
		public eScrapMasterSkillType skillType;

		public List<UI_Obj_ScrapMasterUpgradeButton> list_Buttons;
	}

	[SerializeField]
	private List<UpgradeButtonData> list_UpgradeButtons;

	private bool isFinished;

	private void OnButtonClicked(UI_Obj_ScrapMasterUpgradeButton button)
	{
	}

	protected override void ShowWindowProc()
	{
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
}
