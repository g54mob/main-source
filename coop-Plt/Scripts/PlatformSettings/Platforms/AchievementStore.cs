using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kitchen.NetworkSupport;

namespace Platforms
{
	public class AchievementStore
	{
		public class AchievementState
		{
			public string Identifier;

			public bool IsUnlocked;

			public bool IsUnlockedRemotely;
		}

		private Dictionary<string, string> IdentifierMap;

		private Func<PlatformUser, Task<IEnumerable<string>>> RetrieveUserAchievements;

		private Func<PlatformUser, string, Task> GrantUserAchievement;

		private ConcurrentDictionary<PlatformUser, ConcurrentDictionary<string, AchievementState>> LocalCache = new ConcurrentDictionary<PlatformUser, ConcurrentDictionary<string, AchievementState>>();

		public AchievementStore(Func<PlatformUser, Task<IEnumerable<string>>> retrieve_user_achievements, Func<PlatformUser, string, Task> grant_user_achievement, Dictionary<string, string> mapping)
		{
			RetrieveUserAchievements = retrieve_user_achievements;
			GrantUserAchievement = grant_user_achievement;
			IdentifierMap = mapping;
		}

		public void PrerequestUser(PlatformUser user)
		{
			UserAchievements(user);
		}

		public IEnumerable<string> AllPlatformAchievements()
		{
			foreach (KeyValuePair<string, string> item in IdentifierMap)
			{
				yield return item.Value;
			}
		}

		public string GetGameIdentifierFromPlatformIdentifier(string platform_identifier)
		{
			if (IdentifierMap.TryGetValue(platform_identifier, out var value))
			{
				return value;
			}
			return null;
		}

		public bool Has(PlatformUser user, string achievement)
		{
			return UserAchievement(user, achievement).IsUnlocked;
		}

		public void Unlock(PlatformUser user, string achievement)
		{
			AchievementState achievementState = UserAchievement(user, achievement);
			achievementState.IsUnlocked = true;
			if (!achievementState.IsUnlockedRemotely)
			{
				achievementState.IsUnlockedRemotely = true;
				if (IdentifierMap.TryGetValue(achievement, out var value))
				{
					GrantUserAchievement(user, value);
				}
			}
		}

		public (int current, int total) GetProgress(PlatformUser user)
		{
			return (current: CountUserAchievements(user), total: IdentifierMap.Count);
		}

		public void Unlock(IEnumerable<PlatformUser> users, string identifier)
		{
			foreach (PlatformUser user in users)
			{
				Unlock(user, identifier);
			}
		}

		private int CountUserAchievements(PlatformUser user)
		{
			return UserAchievements(user).Count((KeyValuePair<string, AchievementState> w) => IdentifierMap.ContainsKey(w.Key) && w.Value.IsUnlocked);
		}

		private ConcurrentDictionary<string, AchievementState> UserAchievements(PlatformUser user)
		{
			return LocalCache.GetOrAdd(user, delegate
			{
				ConcurrentDictionary<string, AchievementState> new_dictionary = new ConcurrentDictionary<string, AchievementState>();
				RetrieveUserAchievements(user).ContinueWith(delegate(Task<IEnumerable<string>> r)
				{
					if (r.IsCanceled || r.IsFaulted)
					{
						EventLog.Networking.Report(PlatformEvent.FailedToGetUserAchievements, user.ToString());
						return;
					}
					foreach (KeyValuePair<string, string> item in IdentifierMap)
					{
						if (r.Result.Contains(item.Value))
						{
							new_dictionary[item.Key] = new AchievementState
							{
								Identifier = item.Key,
								IsUnlocked = true,
								IsUnlockedRemotely = true
							};
						}
					}
				});
				return new_dictionary;
			});
		}

		private AchievementState UserAchievement(PlatformUser user, string identifier)
		{
			if (!IdentifierMap.ContainsKey(identifier))
			{
				return new AchievementState
				{
					Identifier = identifier
				};
			}
			return UserAchievements(user).GetOrAdd(identifier, new AchievementState
			{
				Identifier = identifier
			});
		}
	}
}
