using System;
using System.Collections.Generic;
using System.Text;
using Factory;
using Motorways;
using Motorways.UI;
using UnityEngine;

namespace SoftwareCapabilities
{
	public class SteamSoftwareCapabilities : ISoftwareCapabilities
	{
		private static readonly Diagnostics.Log.Channel Log = Diagnostics.Log.OpenChannel("SteamSoftwareCapabilities");

		[Dependency]
		private IHardwareCapabilities _hardwareCapabilities;

		[Dependency]
		private LocaleDatabase _localeDatabase;

		[Dependency]
		private TickRegistry _tickRegistry;

		[Dependency]
		private IAchievementHandler _achievementHandler;

		[Dependency]
		private IScope _scope;

		private bool _hasSyncedAchievements;

		public const string CityModeKey = "#ModeCity";

		public const string DailyChallengeModeKey = "#ModeDailyChallenge";

		public const string WeeklyChallengeModeKey = "#ModeWeeklyChallenge";

		public const string CityKey = "city";

		public const string SteamDisplayKey = "steam_display";

		public LocaleDatabase.LocaleId PreferredLocaleId
		{
			get
			{
				LocaleDatabase.LocaleId localeId = SteamworksShared.GetLocaleId();
				if (localeId == LocaleDatabase.LocaleId.Unknown || !_localeDatabase.IsLocaleSelectable(localeId))
				{
					localeId = UnityLocaleQuery.GetLocaleId(_localeDatabase);
				}
				return localeId;
			}
		}

		public bool SupportsCloudSaves { get; }

		public bool CanShareImage => true;

		public Vector2Int ScreenshotDimensions => new Vector2Int(Screen.width, Screen.height);

		public bool SupportsHighDPI { get; }

		public bool SupportsMultipleProfiles => false;

		public bool SupportsMovieScreen => true;

		public bool SupportsDisplayOptions => true;

		public StringId DeleteCloudGameStringId => StringId.DeleteSpecificJournalPrompt_Steam;

		public bool SupportsEvergreenButton => true;

		public StringId TenYearCelebrationPopupBody => StringId.Popup_Body_CrossPromo_AuroraBorealis;

		public string TenYearCelebrationMiniMetroStoreLink => TenYearCelebrationMiniMetroStoreLinks.SteamStoreLink;

		public void OnAppStart()
		{
			if (SteamworksShared.RestartAppIfNecessary(1127500u))
			{
				Log.Warn("The app was not started from Steam, so will restart via Steam");
				_hardwareCapabilities.Exit();
			}
			else
			{
				if (!Diagnostics.Verify(SteamworksShared.Init(1127500u), "Failed to initialise SteamworksShared"))
				{
					return;
				}
				if (_scope == null)
				{
					_scope = UnityEngine.Object.FindObjectOfType<AppRuntime>()?.App?.Scope;
				}
				_tickRegistry.AppTicking += delegate
				{
					SteamworksShared.RunCallbacks();
					if (!_hasSyncedAchievements && _scope.Get<ActivePlayer>().HasActivePlayer)
					{
						SyncCompletedAchivements();
						_hasSyncedAchievements = true;
					}
				};
			}
		}

		private void SyncCompletedAchivements()
		{
			foreach (Achievement achievement in _scope.Get<ActivePlayer>().MotorwaysUserProfile.Achievements)
			{
				if (achievement.IsComplete())
				{
					_achievementHandler.CompleteAchievement(achievement, showNotification: false);
				}
			}
		}

		public void OnAppShutdown()
		{
			SteamworksShared.Shutdown();
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
			if (Application.isEditor)
			{
				messageId = StringId.PhotoGif_Save_Directory_Steam;
				return ImageSharingUtility.SaveScreenshotToPictures(screenshot, tag + ".png", parentFolder);
			}
			Color32[] pixels = screenshot.GetPixels32();
			if (pixels == null)
			{
				messageId = StringId.Photomode_Failure;
				return false;
			}
			byte[] array = new byte[pixels.Length * 3];
			for (int i = 0; i < pixels.Length; i++)
			{
				int num = i / screenshot.width;
				int num2 = i - num * screenshot.width;
				num = screenshot.height - 1 - num;
				int num3 = num * screenshot.width + num2;
				array[i * 3] = pixels[num3].r;
				array[i * 3 + 1] = pixels[num3].g;
				array[i * 3 + 2] = pixels[num3].b;
			}
			bool flag = SteamworksShared.SaveScreenshot(array, screenshot.width, screenshot.height);
			messageId = (flag ? StringId.PhotoGif_Save_Directory_Steam : StringId.Photomode_Failure);
			return flag;
		}

		public void SetIsInMainMenuScreen(bool isInMainMenuScreen)
		{
		}

		public void SetIsInGame(bool isInGame)
		{
		}

		public void SetRichPresence(Dictionary<string, string> tokens)
		{
			SteamworksShared.SetRichPresence(tokens);
		}

		public bool AllowsTimedChallengeMessages()
		{
			return false;
		}

		public static Dictionary<string, string> GetRichPresenceTokens(string cityName, string displayKey)
		{
			return new Dictionary<string, string>
			{
				{ "steam_display", displayKey },
				{
					"city",
					ConvertCityNameToSnakeCase(cityName)
				}
			};
		}

		public static string ConvertCityNameToSnakeCase(string text)
		{
			if (text == null)
			{
				throw new ArgumentNullException("text");
			}
			if (text.Length < 2)
			{
				return text;
			}
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append(char.ToLowerInvariant(text[0]));
			for (int i = 1; i < text.Length; i++)
			{
				char c = text[i];
				if (char.IsUpper(c))
				{
					stringBuilder.Append('_');
					stringBuilder.Append(char.ToLowerInvariant(c));
				}
				else
				{
					stringBuilder.Append(c);
				}
			}
			return stringBuilder.ToString();
		}
	}
}
