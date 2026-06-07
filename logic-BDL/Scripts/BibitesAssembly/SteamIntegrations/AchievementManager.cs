using System;
using System.Collections.Generic;
using System.Linq;
using Steamworks;
using UnityEngine;

namespace SteamIntegrations
{
	public class AchievementManager : MonoBehaviour
	{
		public static AchievementManager instance;

		public static List<Achievement> achievements = new List<Achievement>
		{
			new Achievement("ACH_BIBITE_EDITOR", "Bibite Engineer", "Save your first engineered bibite!"),
			new Achievement("ACH_BIBITE_EDITOR_100", "Master Manipulator", "Save your hundredth engineered bibite"),
			new Achievement("ACH_BIBITE_EINSTEIN", "Einstein", "Have a bibite born with a brain containing 100 hidden nodes"),
			new Achievement("ACH_SIM_7DAYS", "Let There Be Light", "Reach 7 days (168h) of simulation time"),
			new Achievement("ACH_SIM_1FPS", "Does anyone smell bacon?", "Stay below 1FPS for a minute", secret: true),
			new Achievement("ACH_BIBITE_1DAY", "The Elder among us", "Have a bibite older than a full day"),
			new Achievement("ACH_BIBITE_100CHILDREN", "The Matriarch", "Have a bibite with 100 alive children"),
			new Achievement("ACH_USER_SNAP", "I am Become Death", "Kill half the population of your sim in a single click...\nYou monster..."),
			new ChallengeStarsAchievement("Apocalypse", 1, "Your champion survived a decaying world for an hour"),
			new ChallengeStarsAchievement("Apocalypse", 2, "Your champion survived a decaying world for 3 hours"),
			new ChallengeStarsAchievement("Apocalypse", 3, "Your champion survived a decaying world for 10 hours"),
			new ChallengeStarsAchievement("Like Rabbits", 1, "Your champion managed to reach up to 50 population in an hour!"),
			new ChallengeStarsAchievement("Like Rabbits", 2, "Your champion managed to reach up to 100 population in an hour!"),
			new ChallengeStarsAchievement("Like Rabbits", 3, "Your champion managed to reach up to 200 population in an hour!"),
			new ChallengeStarsAchievement("Down with the Basics", 1, "Your champion eradicated the basic bibites in less than 2 hours"),
			new ChallengeStarsAchievement("Down with the Basics", 2, "Your champion eradicated the basic bibites in less than 1 hour"),
			new ChallengeStarsAchievement("Down with the Basics", 3, "Your champion eradicated the basic bibites in less than 30 minutes"),
			new ChallengeStarsAchievement("The Ultimate Duel", 1, "Your champion eradicated the Darth bibitus in less than 2 hours"),
			new ChallengeStarsAchievement("The Ultimate Duel", 2, "Your champion eradicated the Darth bibitus in less than 1 hour"),
			new ChallengeStarsAchievement("The Ultimate Duel", 3, "Your champion eradicated the Darth bibitus in less than 30 minutes")
		};

		[SerializeField]
		private List<Sprite> achievementIcons = new List<Sprite>();

		[SerializeField]
		private Sprite placeholderLocked;

		[SerializeField]
		private Sprite placeholderUnlocked;

		public Dictionary<string, Achievement> achievementsDict = new Dictionary<string, Achievement>();

		private AppId_t gameID;

		private bool requestedStats;

		private bool requestStoreStats;

		private bool statsValid;

		protected Callback<UserStatsReceived_t> userStatsReceived;

		protected Callback<UserStatsStored_t> userStatsStored;

		private void Awake()
		{
			if (instance == null)
			{
				instance = this;
				gameID = SteamManager.AppID;
				requestedStats = true;
				statsValid = false;
				userStatsReceived = Callback<UserStatsReceived_t>.Create(OnUserStatsReceived);
				userStatsStored = Callback<UserStatsStored_t>.Create(OnUserStatsStored);
			}
			else
			{
				UnityEngine.Object.Destroy(this);
			}
		}

		public void Start()
		{
			achievementsDict.Clear();
			foreach (Achievement achievement in achievements)
			{
				achievementsDict.Add(achievement.id, achievement);
				achievement.Sync();
			}
			int num = 0;
			foreach (Sprite achievementIcon in achievementIcons)
			{
				string text = achievementIcon.name;
				if (!text.Contains("ACH"))
				{
					continue;
				}
				string text2 = text.Substring(0, text.Length - 2);
				if (achievementsDict.ContainsKey(text2))
				{
					if (text == text2 + "_0")
					{
						achievementsDict[text2].spriteNotAchieved = achievementIcon;
						num++;
					}
					else if (text == text2 + "_1")
					{
						achievementsDict[text2].spriteAchieved = achievementIcon;
						num++;
					}
				}
			}
			int num2 = achievements.Sum((Achievement a) => (!a.fullIconSet) ? 1 : 0);
			if (achievementIcons.Count - num > 0)
			{
				Debug.Log($"{achievementIcons.Count - num} achievement icons have not been matched");
			}
			if (num2 > 0)
			{
				Debug.Log($"{num2} achievements are missing their full icon set");
			}
			foreach (Achievement achievement2 in achievements)
			{
				if (achievement2.spriteNotAchieved == null)
				{
					achievement2.spriteNotAchieved = placeholderLocked;
				}
				if (achievement2.spriteAchieved == null)
				{
					achievement2.spriteAchieved = placeholderUnlocked;
				}
			}
		}

		public void CheckState()
		{
			foreach (Achievement achievement in achievements)
			{
				Debug.Log(achievement.id + " local:" + (achievement.achieved ? "1" : "0") + " steam:" + (achievement.achievedSteam ? "1" : "0"));
			}
		}

		public static void StoreStats()
		{
			if (!(instance == null) && SteamManager.Initialized)
			{
				instance.requestStoreStats = true;
			}
		}

		public static void RequestStats()
		{
			if (!(instance == null) && SteamManager.Initialized)
			{
				instance.requestedStats = true;
			}
		}

		public void Update()
		{
			if (SteamManager.Initialized)
			{
				if (requestedStats && SteamUserStats.RequestCurrentStats())
				{
					requestedStats = false;
				}
				if (requestStoreStats && SteamUserStats.StoreStats())
				{
					requestStoreStats = false;
				}
				if (Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.RightControl))
				{
					CheckState();
				}
			}
		}

		private void OnUserStatsStored(UserStatsStored_t callback)
		{
			if (SteamManager.Initialized && (uint)gameID == callback.m_nGameID)
			{
				if (callback.m_eResult != EResult.k_EResultOK)
				{
					Debug.Log("Store stats - something failed: " + callback.m_eResult);
				}
				else
				{
					Debug.Log("Stats updated Remotely!");
				}
			}
		}

		private void OnUserStatsReceived(UserStatsReceived_t callback)
		{
			if (SteamManager.Initialized && (uint)gameID == callback.m_nGameID)
			{
				if (callback.m_eResult != EResult.k_EResultOK)
				{
					Debug.Log("Request stats - something failed : " + callback.m_eResult);
				}
				else
				{
					Debug.Log("Stats received!");
				}
			}
		}

		public static Achievement Get(string key)
		{
			if (instance == null)
			{
				throw new Exception("AchievementManager is missing");
			}
			return instance.achievementsDict[key];
		}

		public static bool HasAchievement(string key)
		{
			if (instance == null)
			{
				throw new Exception("AchievementManager is missing");
			}
			return instance.achievementsDict.ContainsKey(key);
		}

		public static void Trigger(string key, GameObject source = null)
		{
			if (instance == null)
			{
				throw new Exception("AchievementManager is missing");
			}
			if (HasAchievement(key))
			{
				instance.achievementsDict[key].Trigger(source);
			}
		}

		public static void ResetAch(string key)
		{
			if (instance == null)
			{
				throw new Exception("AchievementManager is missing");
			}
			if (HasAchievement(key))
			{
				instance.achievementsDict[key].Trigger();
			}
		}
	}
}
