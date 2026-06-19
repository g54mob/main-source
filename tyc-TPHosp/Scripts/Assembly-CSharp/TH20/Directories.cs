using System.IO;
using Steamworks;
using UnityEngine;

namespace TH20
{
	public static class Directories
	{
		private static bool _isInitialised;

		private static bool _isOnSteam;

		private static string _playerAccountId;

		private static readonly string CachedPersistentDataPath = Application.persistentDataPath;

		private const string CloudSubdirectory = "Cloud";

		public static string GameOutputDirectoryEditor => "User";

		public static string GameOutputDirectoryStandalone => CachedPersistentDataPath;

		public static string GameOutputDirectory => Path.GetFullPath(Application.isEditor ? GameOutputDirectoryEditor : GameOutputDirectoryStandalone);

		public static string CloudDirectoryEditor => GetCloudDirectory(GameOutputDirectoryEditor);

		public static string CloudDirectoryStandalone => GetCloudDirectory(GameOutputDirectoryStandalone);

		public static string SteamCloudDirectory => GetCloudDirectory(GameOutputDirectory);

		public static void Initialise()
		{
			if (_isInitialised)
			{
				return;
			}
			if (OnlineManager.IsInitialized())
			{
				OnlinePlayerInfo playerInfo = OnlineManager.GetPlayerInfo(OnlineManager.GetLocalPlayerID());
				if (playerInfo != null)
				{
					_playerAccountId = playerInfo.AccountID.ToString();
				}
			}
			if (OSManager.IsInitialised() && OSManager.GetPlatform() == OSManager.Platform.Steam)
			{
				_playerAccountId = SteamUser.GetSteamID().GetAccountID().ToString();
				_isOnSteam = true;
			}
			_isInitialised = true;
		}

		private static void AssertInitialised()
		{
		}

		private static string GetCloudDirectory(string gameOutputDirectory)
		{
			AssertInitialised();
			if (_isOnSteam && !Application.isEditor)
			{
				return Path.Combine(Path.Combine(gameOutputDirectory, "Cloud"), _playerAccountId);
			}
			return Path.Combine(Path.Combine(gameOutputDirectory, "Cloud"), "0");
		}
	}
}
