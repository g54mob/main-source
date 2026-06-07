using System.Collections.Generic;
using Factory;
using UnityEngine;

public class MacAppStoreSoftwareCapabilities : ISoftwareCapabilities
{
	[Dependency]
	protected IHardwareCapabilities _hardwareCapabilities;

	public LocaleDatabase.LocaleId PreferredLocaleId => _hardwareCapabilities.PreferredLocaleId;

	public bool SupportsCloudSaves => true;

	public bool CanShareImage => true;

	public Vector2Int ScreenshotDimensions => new Vector2Int(Screen.width, Screen.height);

	public bool SupportsHighDPI => true;

	public bool SupportsMultipleProfiles => true;

	public bool SupportsMovieScreen => true;

	public bool SupportsDisplayOptions => true;

	public StringId DeleteCloudGameStringId => StringId.DeleteSpecificJournalPrompt_iCloud;

	public bool SupportsEvergreenButton => true;

	public StringId TenYearCelebrationPopupBody => StringId.Popup_Body_CrossPromo_AuroraBorealis;

	public string TenYearCelebrationMiniMetroStoreLink => "https://apple.co/-MiniMetro";

	public bool SaveScreenshot(Texture2D screenshot, string tag, string parentFolder, out StringId messageId)
	{
		bool flag = ImageSharingUtility.SaveScreenshotToPictures(screenshot, tag + ImageSharingUtility.PNG, parentFolder);
		messageId = (flag ? StringId.PhotoGif_Save_Directory_Mac : StringId.Photomode_Failure);
		return flag;
	}

	public bool SaveGif(byte[] data, string tag, string parentFolder, out StringId messageId, out StringId messageHeaderId)
	{
		bool flag = ImageSharingUtility.SaveGIF(data, tag + ImageSharingUtility.GIF, parentFolder);
		messageId = (flag ? StringId.PhotoGif_Save_Directory_Mac : StringId.Moviemode_Failure);
		messageHeaderId = (flag ? StringId.Moviemode_Popup_Header : StringId.Moviemode_Popup_Header_Failure);
		return flag;
	}

	public void SetIsInMainMenuScreen(bool isInMainMenuScreen)
	{
	}

	public void SetIsInGame(bool isInGame)
	{
	}

	public virtual void OnAppStart()
	{
		InitializeFairPlay();
	}

	public void OnAppShutdown()
	{
	}

	public void SetRichPresence(Dictionary<string, string> tokens)
	{
	}

	public bool AllowsTimedChallengeMessages()
	{
		return true;
	}

	private static void InitializeFairPlay()
	{
	}
}
