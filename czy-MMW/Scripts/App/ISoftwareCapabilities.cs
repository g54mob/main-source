using System.Collections.Generic;
using UnityEngine;

public interface ISoftwareCapabilities
{
	LocaleDatabase.LocaleId PreferredLocaleId { get; }

	bool SupportsCloudSaves { get; }

	bool CanShareImage { get; }

	Vector2Int ScreenshotDimensions { get; }

	bool SupportsHighDPI { get; }

	bool SupportsMultipleProfiles { get; }

	bool SupportsMovieScreen { get; }

	bool SupportsDisplayOptions { get; }

	StringId DeleteCloudGameStringId { get; }

	bool SupportsEvergreenButton { get; }

	StringId TenYearCelebrationPopupBody { get; }

	string TenYearCelebrationMiniMetroStoreLink { get; }

	void OnAppStart();

	bool SaveGif(byte[] gifData, string tag, string parentFolder, out StringId messageId, out StringId messageHeaderId);

	bool SaveScreenshot(Texture2D screenshot, string tag, string parentFolder, out StringId messageId);

	void SetIsInMainMenuScreen(bool isInMainMenuScreen);

	void SetIsInGame(bool isInGame);

	void OnAppShutdown();

	void SetRichPresence(Dictionary<string, string> tokens);

	bool AllowsTimedChallengeMessages();
}
