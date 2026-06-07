using System;
using System.Collections.Generic;
using Factory;
using UnityEngine;

public class WeGameSoftwareCapabilities : ISoftwareCapabilities
{
	[Dependency]
	protected IHardwareCapabilities _hardwareCapabilities;

	public LocaleDatabase.LocaleId PreferredLocaleId => _hardwareCapabilities.PreferredLocaleId;

	public bool SupportsCloudSaves => false;

	public bool CanShareImage => false;

	public Vector2Int ScreenshotDimensions => new Vector2Int(Screen.width, Screen.height);

	public bool SupportsHighDPI => false;

	public bool SupportsMultipleProfiles => true;

	public bool SupportsMovieScreen => true;

	public bool SupportsDisplayOptions => false;

	public StringId DeleteCloudGameStringId => StringId.None;

	public bool SupportsEvergreenButton => false;

	public StringId TenYearCelebrationPopupBody => StringId.None;

	public string TenYearCelebrationMiniMetroStoreLink => null;

	public void SetIsInMainMenuScreen(bool isInMainMenuScreen)
	{
	}

	public void SetIsInGame(bool isInGame)
	{
	}

	public virtual void OnAppStart()
	{
	}

	public void OnAppShutdown()
	{
	}

	public bool SaveGif(byte[] data, string tag, string parentFolder, out StringId messageId, out StringId messageHeaderId)
	{
		messageId = StringId.None;
		messageHeaderId = StringId.None;
		throw new NotImplementedException();
	}

	public bool SaveScreenshot(Texture2D screenshot, string tag, string parentFolder, out StringId messageId)
	{
		messageId = StringId.None;
		throw new NotImplementedException();
	}

	public void SetRichPresence(Dictionary<string, string> tokens)
	{
	}

	public bool AllowsTimedChallengeMessages()
	{
		return false;
	}
}
