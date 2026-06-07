using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Factory;
using UnityEngine;

public class iOSSoftwareCapabilities : ISoftwareCapabilities
{
	private static class iOSShareAPI
	{
		public static bool ShareImage(IntPtr imageData, int imageDataLength)
		{
			return true;
		}

		public static bool CanShareImage()
		{
			return true;
		}
	}

	[Dependency]
	protected IHardwareCapabilities _hardwareCapabilities;

	public LocaleDatabase.LocaleId PreferredLocaleId => _hardwareCapabilities.PreferredLocaleId;

	public bool SupportsCloudSaves => true;

	public bool CanShareImage => iOSShareAPI.CanShareImage();

	public Vector2Int ScreenshotDimensions => new Vector2Int(Screen.width, Screen.height);

	public bool SupportsHighDPI => false;

	public bool SupportsMultipleProfiles => true;

	public bool SupportsMovieScreen => true;

	public bool SupportsDisplayOptions => false;

	public StringId DeleteCloudGameStringId => StringId.DeleteSpecificJournalPrompt_iCloud;

	public bool SupportsEvergreenButton => true;

	public StringId TenYearCelebrationPopupBody => StringId.Popup_Body_CrossPromo_AuroraBorealis;

	public string TenYearCelebrationMiniMetroStoreLink => "https://apple.co/-MiniMetro";

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

	public bool SaveScreenshot(Texture2D screenshot, string tag, string parentFolder, out StringId messageId)
	{
		byte[] array = screenshot.EncodeToPNG();
		GCHandle gCHandle = GCHandle.Alloc(array, GCHandleType.Pinned);
		iOSShareAPI.ShareImage(gCHandle.AddrOfPinnedObject(), array.Length);
		gCHandle.Free();
		messageId = StringId.None;
		return true;
	}

	public bool SaveGif(byte[] data, string tag, string parentFolder, out StringId messageId, out StringId messageHeaderId)
	{
		GCHandle gCHandle = GCHandle.Alloc(data, GCHandleType.Pinned);
		iOSShareAPI.ShareImage(gCHandle.AddrOfPinnedObject(), data.Length);
		gCHandle.Free();
		messageId = StringId.None;
		messageHeaderId = StringId.None;
		return true;
	}

	public void SetRichPresence(Dictionary<string, string> tokens)
	{
	}

	public bool AllowsTimedChallengeMessages()
	{
		return true;
	}
}
