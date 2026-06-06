using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Steamworks;
using UnityEngine;

namespace Brewery.UI
{
	public class ProfileManager : MonoBehaviour
	{
		private CSteamID steamId;

		private string playerName;

		private Texture2D avatarTexture;

		private const string PREF_LEVEL = "Profile_Level";

		private const string PREF_XP = "Profile_XP";

		private const string PREF_TOTAL_PLAY_TIME = "Profile_TotalPlayTime";

		private const string PREF_GAMES_PLAYED = "Profile_GamesPlayed";

		private const string PREF_GAMES_WON = "Profile_GamesWon";

		private const string PREF_TOTAL_BREWS = "Profile_TotalBrews";

		private const string PREF_BEST_BREW_QUALITY = "Profile_BestBrewQuality";

		private const string PREF_FAVORITE_COLOR = "Profile_FavoriteColor";

		private const string PREF_TITLE = "Profile_Title";

		private HashSet<string> unlockedAchievements;

		private const string PREF_ACHIEVEMENTS = "Profile_Achievements";

		private float sessionStartTime;

		private Callback<AvatarImageLoaded_t> avatarLoadedCallback;

		public static ProfileManager Instance { get; private set; }

		public string PlayerName
		{
			get
			{
				return null;
			}
			private set
			{
			}
		}

		public CSteamID SteamID => default(CSteamID);

		public Texture2D AvatarTexture
		{
			get
			{
				return null;
			}
			private set
			{
			}
		}

		public int Level
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public int XP
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public int XPForNextLevel => 0;

		public float XPProgress => 0f;

		public float TotalPlayTime
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public int GamesPlayed
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public int GamesWon
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public float WinRate => 0f;

		public int TotalBrews
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public float BestBrewQuality
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public Color FavoriteColor
		{
			get
			{
				return default(Color);
			}
			set
			{
			}
		}

		public string PlayerTitle
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public event Action OnProfileUpdated
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event Action OnStatsUpdated
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event Action OnAchievementUnlocked
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		private void Awake()
		{
		}

		private void OnDestroy()
		{
		}

		private void Start()
		{
		}

		private void OnApplicationQuit()
		{
		}

		private void InitializeSteamProfile()
		{
		}

		private void LoadSteamAvatar()
		{
		}

		private void OnAvatarImageLoaded(AvatarImageLoaded_t callback)
		{
		}

		private void LoadAvatarFromHandle(int avatarHandle)
		{
		}

		private void FlipImageVertically(byte[] imageData, int width, int height)
		{
		}

		public void AddXP(int amount)
		{
		}

		private void LevelUp()
		{
		}

		public void IncrementGamesPlayed()
		{
		}

		public void IncrementGamesWon()
		{
		}

		public void IncrementBrewsMade(float quality = 0f)
		{
		}

		public string GetFormattedPlayTime()
		{
			return null;
		}

		private void LoadAchievements()
		{
		}

		private void SaveAchievements()
		{
		}

		public bool IsAchievementUnlocked(string achievementId)
		{
			return false;
		}

		public void UnlockAchievement(string achievementId, string achievementName = null)
		{
		}

		public int GetUnlockedAchievementCount()
		{
			return 0;
		}

		public int GetTotalAchievementCount()
		{
			return 0;
		}

		public AchievementData[] GetAllAchievements()
		{
			return null;
		}

		public void ResetProfile()
		{
		}
	}
}
