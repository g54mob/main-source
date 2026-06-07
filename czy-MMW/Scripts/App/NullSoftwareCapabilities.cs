using System.Collections.Generic;
using UnityEngine;

public class NullSoftwareCapabilities : ISoftwareCapabilities
{
	public LocaleDatabase.LocaleId PreferredLocaleId => LocaleDatabase.LocaleId.en_US;

	public bool SupportsCloudSaves => false;

	public bool CanShareImage => true;

	public Vector2Int ScreenshotDimensions => new Vector2Int(Screen.width, Screen.height);

	public bool SupportsHighDPI => false;

	public bool SupportsMultipleProfiles => false;

	public bool SupportsMovieScreen => true;

	public bool SupportsDisplayOptions => true;

	public StringId DeleteCloudGameStringId => StringId.None;

	public bool SupportsEvergreenButton => true;

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
		bool flag = ImageSharingUtility.SaveGIF(data, tag + ImageSharingUtility.GIF, parentFolder);
		messageId = (flag ? StringId.Gif_Save_Directory_Steam : StringId.Moviemode_Failure);
		messageHeaderId = (flag ? StringId.Moviemode_Popup_Header : StringId.Moviemode_Popup_Header_Failure);
		return flag;
	}

	public bool SaveScreenshot(Texture2D screenshot, string tag, string parentFolder, out StringId messageId)
	{
		bool flag = ImageSharingUtility.SaveScreenshotToPictures(screenshot, tag + ".gif", parentFolder);
		messageId = (flag ? StringId.PhotoGif_Save_Directory_Steam : StringId.Photomode_Failure);
		return flag;
	}

	public void SetRichPresence(Dictionary<string, string> tokens)
	{
	}

	public bool AllowsTimedChallengeMessages()
	{
		return false;
	}
}
