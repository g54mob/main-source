#define LOG_LEVEL_VERBOSE
using System;
using System.IO;
using System.Text;
using Steamworks;
using UnityConsole;
using UnityEngine;

namespace TH20
{
	[DontSave]
	public class SteamOSManager : MustCallDestroy, IOSManager
	{
		private const uint CampusAppID = 1649080u;

		public bool IsInitialised { get; private set; }

		public OSManager.Platform Platform => OSManager.Platform.Steam;

		public string BuildVersion { get; private set; }

		public Action OnDLCRefreshed { get; set; }

		private static void SteamAPIDebugTextHook(int nSeverity, StringBuilder pchDebugText)
		{
			Logging.Warning(LogChannels.Online, pchDebugText.ToString());
		}

		public static bool QuitIfNotOnSteam()
		{
			if (!Packsize.Test())
			{
				UnityEngine.Debug.LogError("[Steamworks.NET] Packsize Test returned false, the wrong version of Steamworks.NET is being run in this platform. Quitting.");
				Application.Quit();
				return true;
			}
			if (!DllCheck.Test())
			{
				UnityEngine.Debug.LogError("[Steamworks.NET] DllCheck Test returned false, One or more of the Steamworks binaries seems to be the wrong version. Quitting.");
				Application.Quit();
				return true;
			}
			if (DeleteSteamAppIDOrQuit())
			{
				return true;
			}
			try
			{
				if (SteamAPI.RestartAppIfNecessary((AppId_t)OSManager.AppID.AsUint()))
				{
					UnityEngine.Debug.Log("Restarting game due to being started outside of Steam.");
					Application.Quit();
					return true;
				}
			}
			catch (DllNotFoundException ex)
			{
				UnityEngine.Debug.LogError("[Steamworks.NET] Could not load [lib]steam_api.dll/so/dylib. Quitting.\n" + ex);
				Application.Quit();
				return true;
			}
			return false;
		}

		public void InitialiseAPI()
		{
			if (IsInitialised)
			{
				return;
			}
			IsInitialised = SteamAPI.Init();
			if (!IsInitialised)
			{
				UnityEngine.Debug.LogError("Failed to initialise Steam API. This shouldn't ever happen - perhaps game is being started on a machine without Steam installed, or on the wrong user account, or by an account that doesn't own the game. Quitting.");
				Application.Quit();
			}
			if (IsInitialised)
			{
				BuildVersion = SteamApps.GetAppBuildId().ToString();
				if (SteamApps.GetCurrentBetaName(out var pchName, 128))
				{
					BuildVersion = BuildVersion + " (" + pchName + ")";
				}
			}
		}

		private static bool DeleteSteamAppIDOrQuit()
		{
			if (File.Exists("steam_appid.txt"))
			{
				UnityEngine.Debug.Log("steam_appid.txt exists, and it shouldn't do. Trying to delete, so Steam API doesn't get tricked.");
			}
			FileUtils.TryDeleteFileIfExists("steam_appid.txt");
			if (File.Exists("steam_appid.txt"))
			{
				UnityEngine.Debug.LogError("steam_appid.txt exists and can't be deleted. This file should not exist for release builds - this is likely to be an attempt at piracy. YARR. At least it's not Denuvo :) Will now Quit.");
				Application.Quit();
				return true;
			}
			return false;
		}

		public SteamOSManager()
		{
			QuitIfNotOnSteam();
			InitialiseAPI();
			ConsoleCommandsDatabase.RegisterCommand("SetIconPlatform", "Sets specific platform for icons", "SetIconPlatform [Switch|PS4|XB1|None]", Debug_SetIconPlatform);
			if (IsInitialised)
			{
				SteamClient.SetWarningMessageHook(SteamAPIDebugTextHook);
			}
		}

		private ConsoleCommandResult Debug_SetIconPlatform(string[] args)
		{
			if (args.Length != 1)
			{
				return ConsoleCommandResult.Failed("Pass through either 'Switch', 'PS4', 'XB1' to this command or 'None' to reset");
			}
			return ConsoleCommandResult.Succeeded();
		}

		public override void Destroy()
		{
			if (IsInitialised)
			{
				SteamAPI.Shutdown();
			}
			base.Destroy();
			ConsoleCommandsDatabase.UnRegisterCommand("SetIconPlatform");
		}

		public void AssignApp(App app)
		{
		}

		public void Update()
		{
			if (IsInitialised)
			{
				SteamAPI.RunCallbacks();
			}
		}

		public void ValidateUser(IOSManagerResultCallback callback)
		{
			callback(result: true);
		}

		public void EnumerateDLC(IOSManagerResultCallback callback)
		{
			callback(result: true);
		}

		public bool IsDlcInstalled(GameID appID)
		{
			if (appID.AsUint() == 0)
			{
				return true;
			}
			if (appID.AsUint() == 1649080)
			{
				return IsDlcOwned(appID);
			}
			return SteamApps.BIsDlcInstalled((AppId_t)appID.AsUint());
		}

		public bool IsDlcOwned(GameID appID)
		{
			if (appID.AsUint() == 0)
			{
				return true;
			}
			return SteamApps.BIsSubscribedApp((AppId_t)appID.AsUint());
		}

		public bool ShowDlcPurchaseUI(GameID appID, IOSManagerResultCallback callback)
		{
			return true;
		}

		public void OpenStoreForProduct(string productID)
		{
		}

		public Preferences.LanguagePreferences.Language GetLanguage()
		{
			if (IsInitialised)
			{
				return SteamApps.GetCurrentGameLanguage() switch
				{
					"french" => Preferences.LanguagePreferences.Language.French, 
					"italian" => Preferences.LanguagePreferences.Language.Italian, 
					"german" => Preferences.LanguagePreferences.Language.German, 
					"spanish" => Preferences.LanguagePreferences.Language.Spanish, 
					"polish" => Preferences.LanguagePreferences.Language.Polish, 
					"russian" => Preferences.LanguagePreferences.Language.Russian, 
					"schinese" => Preferences.LanguagePreferences.Language.SimplifiedChinese, 
					"tchinese" => Preferences.LanguagePreferences.Language.TraditionalChinese, 
					"brazilian" => Preferences.LanguagePreferences.Language.BrazilianPortuguese, 
					"koreana" => Preferences.LanguagePreferences.Language.Korean, 
					_ => Preferences.LanguagePreferences.Language.English, 
				};
			}
			return Preferences.LanguagePreferences.Language.English;
		}
	}
}
