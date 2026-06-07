using System.Collections.Generic;
using Factory;
using UnityEngine;

public class iOSDemoSoftwareCapabilities : ISoftwareCapabilities
{
	[Dependency]
	protected IHardwareCapabilities _hardwareCapabilities;

	public LocaleDatabase.LocaleId PreferredLocaleId => _hardwareCapabilities.PreferredLocaleId;

	public bool SupportsCloudSaves => false;

	public bool CanShareImage => false;

	public Vector2Int ScreenshotDimensions => new Vector2Int(Screen.width, Screen.height);

	public bool SupportsHighDPI => false;

	public bool SupportsMultipleProfiles => false;

	public bool SupportsMovieScreen => false;

	public bool SupportsDisplayOptions => false;

	public StringId DeleteCloudGameStringId => StringId.DeleteSpecificJournalPrompt_iCloud;

	public bool SupportsEvergreenButton => false;

	public StringId TenYearCelebrationPopupBody => StringId.None;

	public string TenYearCelebrationMiniMetroStoreLink => null;

	public void OnAppStart()
	{
	}

	public void OnAppShutdown()
	{
	}

	public bool SaveScreenshot(Texture2D screenshot, string tag, string parentFolder, out StringId messageId)
	{
		messageId = StringId.None;
		return false;
	}

	public bool SaveGif(byte[] data, string tag, string parentFolder, out StringId messageId, out StringId messageHeaderId)
	{
		messageId = StringId.None;
		messageHeaderId = StringId.None;
		return false;
	}

	public void SetIsInMainMenuScreen(bool isInMainMenuScreen)
	{
	}

	public void SetIsInGame(bool isInGame)
	{
	}

	public void SetRichPresence(Dictionary<string, string> tokens)
	{
	}

	public bool AllowsTimedChallengeMessages()
	{
		return true;
	}
}
