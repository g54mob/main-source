using System;
using Assets.Packages.SocialPlatforms.Achievements;
using Assets.Packages.SocialPlatforms.Gog;
using Assets.Packages.SocialPlatforms.Steam;
using Steamworks;
using UnityEngine;
using UnityEngine.SocialPlatforms;

namespace Assets.Packages.SocialPlatforms
{
	public static class SocialExt
	{
		public static ISocialPlatformExt Active
		{
			get
			{
				return Social.Active as ISocialPlatformExt;
			}
			private set
			{
				Social.Active = value;
			}
		}

		public static bool Enabled
		{
			get
			{
				ISocialPlatformExt active = Active;
				if (active != null)
				{
					return active.PlatformName != PlatformNames.Dummy;
				}
				return false;
			}
		}

		public static bool IsGameCenter
		{
			get
			{
				ISocialPlatformExt active = Active;
				if (active != null)
				{
					return active.PlatformName == PlatformNames.GameCenter;
				}
				return false;
			}
		}

		public static bool IsGog
		{
			get
			{
				ISocialPlatformExt active = Active;
				if (active != null)
				{
					return active.PlatformName == PlatformNames.GOG;
				}
				return false;
			}
		}

		public static bool IsGooglePlayGames
		{
			get
			{
				ISocialPlatformExt active = Active;
				if (active != null)
				{
					return active.PlatformName == PlatformNames.GooglePlayGames;
				}
				return false;
			}
		}

		public static bool IsSteam
		{
			get
			{
				ISocialPlatformExt active = Active;
				if (active != null)
				{
					return active.PlatformName == PlatformNames.Steam;
				}
				return false;
			}
		}

		public static bool IsSteamBigPicture
		{
			get
			{
				if (IsSteam)
				{
					return Steam.IsRunningInBigPicture();
				}
				return false;
			}
		}

		public static bool IsSteamDeck
		{
			get
			{
				if (IsSteam)
				{
					return Steam.IsRunningOnSteamDeck();
				}
				return false;
			}
		}

		public static bool IsSteamDeckOrBigPicture
		{
			get
			{
				if (IsSteam)
				{
					if (!Steam.IsRunningOnSteamDeck())
					{
						return Steam.IsRunningInBigPicture();
					}
					return true;
				}
				return false;
			}
		}

		public static ILocalUser LocalUser => Social.localUser;

		public static ISteamPlatform Steam => (ISteamPlatform)Active;

		public static IAchievement CreateAchievement()
		{
			return Social.CreateAchievement();
		}

		public static ILeaderboard CreateLeaderboard()
		{
			return Social.CreateLeaderboard();
		}

		public static void FallbackToDummyPlatform()
		{
			Active = new DummyPlatform();
		}

		public static void Initialize(AchievementDatabase achievementDatabase)
		{
			ISocialPlatformExt socialPlatformExt = new DummyPlatform();
			if (TryInitializeSteam())
			{
				socialPlatformExt = new SteamPlatform();
			}
			else if (TryInitializeGog())
			{
				socialPlatformExt = new GogPlatform();
			}
			Active = socialPlatformExt;
			socialPlatformExt.Initialize(achievementDatabase);
		}

		public static void LoadAchievementDescriptions(Action<IAchievementDescription[]> callback)
		{
			Social.LoadAchievementDescriptions(callback);
		}

		public static void LoadAchievements(Action<IAchievement[]> callback)
		{
			Social.LoadAchievements(callback);
		}

		public static void LoadScores(string leaderboardID, Action<IScore[]> callback)
		{
			Social.LoadScores(leaderboardID, callback);
		}

		public static void LoadUsers(string[] userIDs, Action<IUserProfile[]> callback)
		{
			Social.LoadUsers(userIDs, callback);
		}

		public static void ReportProgress(string achievementID, double progress, Action<bool> callback)
		{
			Social.ReportProgress(achievementID, progress, callback);
		}

		public static void ReportScore(long score, string board, Action<bool> callback)
		{
			Social.ReportScore(score, board, callback);
		}

		public static void ResetAllAchievements()
		{
			Active.ResetAllAchievements();
		}

		public static void ShowAchievementsUI()
		{
			Social.ShowAchievementsUI();
		}

		public static void ShowLeaderboardUI()
		{
			Social.ShowLeaderboardUI();
		}

		private static bool TryInitializeGog()
		{
			return false;
		}

		private static bool TryInitializeSteam()
		{
			return SteamAPI.Init();
		}
	}
}
