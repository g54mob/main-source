using System.Collections.Generic;
using UnityEngine;

public class RadicalMainMenu : RadicalMenu
{
	private List<MenuHelperButtons.HelpButtonTypes> helpButtons = new List<MenuHelperButtons.HelpButtonTypes>
	{
		MenuHelperButtons.HelpButtonTypes.NAVIGATE,
		MenuHelperButtons.HelpButtonTypes.SELECT
	};

	[ClearOnReload]
	private static bool m_didShowGPUReqError;

	public override bool UseCustomHelpButtons => true;

	public override List<MenuHelperButtons.HelpButtonTypes> GetHelpButtonsToShow()
	{
		return helpButtons;
	}

	private void Start()
	{
		Manager.platform.RefreshPlatformFriends(getProfiles: true);
		if (SystemRequirements.gpuStatus == SystemRequirements.Status.Failed && !m_didShowGPUReqError)
		{
			Manager.menu.centerPopUpText.StartNewDisplaySequence("Error/reqFailNotificationGPU", null, menuInputCooldown: true, 0f, 1.5f, useUnscaledTime: true, 0f, 1f, localize: true, TextManager.FontFace.boldMedium, PopUpCallBack, new List<string> { "ok" }, 10f, 0.95f, 0, 25f);
			m_didShowGPUReqError = true;
		}
	}

	private void PopUpCallBack(PopupResponse response)
	{
		Debug.Log(response.IsConfirm);
	}
}
