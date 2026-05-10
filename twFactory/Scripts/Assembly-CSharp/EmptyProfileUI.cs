using System;
using UnityEngine.Localization.Settings;

public class EmptyProfileUI : UIListElement
{
	public override void LoadData()
	{
	}

	public void OnProfileClicked()
	{
		string localizedString = LocalizationSettings.StringDatabase.GetLocalizedString("UI_ProfileMenu", "UI_ProfileMenu_modalWindow_header_profileName", null, FallbackBehavior.UseProjectSettings);
		string localizedString2 = LocalizationSettings.StringDatabase.GetLocalizedString("UI_Common", "UI_Common_create", null, FallbackBehavior.UseProjectSettings);
		string localizedString3 = LocalizationSettings.StringDatabase.GetLocalizedString("UI_Common", "UI_Common_cancel", null, FallbackBehavior.UseProjectSettings);
		Action<string> yesAction = delegate(string inputText)
		{
			SaveProfile saveProfile = SaveSystem.instance.CreateNewProfile(inputText, generateEmptyMetadata: true);
			SaveSystem.instance.SelectProfile(saveProfile.Id);
		};
		GameManager.instance.PlayerController.CurrentHUD.ShowInputModalWindowTwoButtons("", localizedString, yesAction, null, localizedString2, localizedString3, 16);
	}
}
