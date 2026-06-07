using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Localization.Settings;

public class ProfileUI : UIListElement
{
	[SerializeField]
	private TextMeshProUGUI profileName;

	[SerializeField]
	private TextMeshProUGUI levelsText;

	[SerializeField]
	private TextMeshProUGUI bossesText;

	[SerializeField]
	private TextMeshProUGUI upgradesText;

	[SerializeField]
	private TextMeshProUGUI saveDateText;

	private SaveProfile saveProfile;

	public SaveProfile SaveProfile => saveProfile;

	public override void LoadData()
	{
		saveProfile = base.Data as SaveProfile;
		profileName.text = saveProfile.DisplayName;
		int num = 0;
		int num2 = 0;
		LevelsProgressionManager.FLevelProgressionInfo[] levelProgressionInfos = LTFunctionLibrary.GetLevelsProgressionManager().LevelProgressionInfos;
		for (int i = 0; i < levelProgressionInfos.Length; i++)
		{
			if (levelProgressionInfos[i].MatchMode == EMatchMode.Campaign)
			{
				num2++;
			}
		}
		if (saveProfile.Metadata.ContainsKey("completedLevels"))
		{
			num = (int)saveProfile.Metadata["completedLevels"];
		}
		levelsText.text = num + "/" + num2;
		int num3 = 0;
		int num4 = 0;
		levelProgressionInfos = LTFunctionLibrary.GetLevelsProgressionManager().LevelProgressionInfos;
		for (int i = 0; i < levelProgressionInfos.Length; i++)
		{
			if (levelProgressionInfos[i].MatchMode == EMatchMode.Campaign)
			{
				num4++;
			}
		}
		if (saveProfile.Metadata.ContainsKey("defeatedBosses"))
		{
			num3 = (int)saveProfile.Metadata["defeatedBosses"];
		}
		bossesText.text = num3 + "/" + num4;
		int num5 = 0;
		int num6 = 0;
		List<PlayerUpgrade> list = new List<PlayerUpgrade>();
		foreach (PlayerUpgrade allUpgrade in LTFunctionLibrary.GetPlayerUpgradesManager().GetAllUpgrades())
		{
			if (allUpgrade.Cost > 0 && !allUpgrade.UnlockedByDefault)
			{
				list.Add(allUpgrade);
				num6++;
			}
		}
		if (saveProfile.Metadata.ContainsKey("unlockedUpgrades"))
		{
			num5 = (int)saveProfile.Metadata["unlockedUpgrades"];
		}
		upgradesText.text = num5 + "/" + num6;
		saveDateText.text = "-";
		if (saveProfile.Metadata.ContainsKey("lastSaveData"))
		{
			DateTime dateTime = ((DateTime)saveProfile.Metadata["lastSaveData"]).ToLocalTime();
			saveDateText.text = dateTime.ToShortDateString() + " - " + dateTime.ToShortTimeString();
		}
	}

	public void OnProfileClicked()
	{
		SaveSystem.instance.SelectProfile(SaveProfile.Id);
	}

	public void OnDeleteProfileClicked()
	{
		string localizedString = LocalizationSettings.StringDatabase.GetTableEntry("UI_ProfileMenu", "UI_ProfileMenu_modalWindow_deleteProfile_body").Entry.GetLocalizedString();
		string localizedString2 = LocalizationSettings.StringDatabase.GetTableEntry("UI_Common", "UI_Common_delete").Entry.GetLocalizedString();
		string localizedString3 = LocalizationSettings.StringDatabase.GetTableEntry("UI_Common", "UI_Common_cancel").Entry.GetLocalizedString();
		Action yesAction = delegate
		{
			SaveSystem.instance.DeleteProfile(SaveProfile);
		};
		GameManager.instance.PlayerController.CurrentHUD.ShowModalWindowTwoButtons(localizedString, "", null, yesAction, null, localizedString2, localizedString3);
	}

	public void OnRenameProfileClicked()
	{
		string localizedString = LocalizationSettings.StringDatabase.GetLocalizedString("UI_ProfileMenu", "UI_ProfileMenu_modalWindow_header_profileName", null, FallbackBehavior.UseProjectSettings);
		string localizedString2 = LocalizationSettings.StringDatabase.GetLocalizedString("UI_Common", "UI_Common_ok", null, FallbackBehavior.UseProjectSettings);
		string localizedString3 = LocalizationSettings.StringDatabase.GetLocalizedString("UI_Common", "UI_Common_cancel", null, FallbackBehavior.UseProjectSettings);
		Action<string> yesAction = delegate(string inputText)
		{
			SaveSystem.instance.RenameProfile(saveProfile.Id, inputText);
		};
		GameManager.instance.PlayerController.CurrentHUD.ShowInputModalWindowTwoButtons(SaveProfile.DisplayName, localizedString, yesAction, null, localizedString2, localizedString3, 16);
	}
}
