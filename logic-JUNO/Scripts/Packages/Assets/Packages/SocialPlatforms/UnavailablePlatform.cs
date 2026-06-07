using System;
using Assets.Packages.SocialPlatforms.Achievements;
using UnityEngine.SocialPlatforms;

namespace Assets.Packages.SocialPlatforms
{
	public class UnavailablePlatform : ISocialPlatformExt, ISocialPlatform
	{
		public ILocalUser localUser
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		public bool LoggedOn
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		public string PlatformName
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		public void Authenticate(ILocalUser user, Action<bool> callback)
		{
			throw new NotImplementedException();
		}

		public void Authenticate(ILocalUser user, Action<bool, string> callback)
		{
			throw new NotImplementedException();
		}

		public IAchievement CreateAchievement()
		{
			throw new NotImplementedException();
		}

		public ILeaderboard CreateLeaderboard()
		{
			throw new NotImplementedException();
		}

		public bool GetLoading(ILeaderboard board)
		{
			throw new NotImplementedException();
		}

		public void IncrementAchievement(string achievementID, float incrementAmount, bool showProgress, Action<bool> callback)
		{
			throw new NotImplementedException();
		}

		public void IncrementAchievement(string achievementID, int incrementAmount, bool showProgress, Action<bool> callback)
		{
			throw new NotImplementedException();
		}

		public void IncrementStat(string statID, float incrementAmount, ShouldShowProgress showProgress, Action<bool> callback)
		{
			throw new NotImplementedException();
		}

		public void IncrementStat(string statID, int incrementAmount, ShouldShowProgress showProgress, Action<bool> callback)
		{
			throw new NotImplementedException();
		}

		public void Initialize(AchievementDatabase achievementDatabase)
		{
			throw new NotImplementedException();
		}

		public void LoadAchievementDescriptions(Action<IAchievementDescription[]> callback)
		{
			throw new NotImplementedException();
		}

		public void LoadAchievements(Action<IAchievement[]> callback)
		{
			throw new NotImplementedException();
		}

		public void LoadFriends(ILocalUser user, Action<bool> callback)
		{
			throw new NotImplementedException();
		}

		public void LoadScores(ILeaderboard board, Action<bool> callback)
		{
			throw new NotImplementedException();
		}

		public void LoadScores(string leaderboardID, Action<IScore[]> callback)
		{
			throw new NotImplementedException();
		}

		public void LoadUsers(string[] userIDs, Action<IUserProfile[]> callback)
		{
			throw new NotImplementedException();
		}

		public void ReportProgress(string achievementID, double progress, Action<bool> callback)
		{
			throw new NotImplementedException();
		}

		public void ReportScore(long score, string board, Action<bool> callback)
		{
			throw new NotImplementedException();
		}

		public void ResetAllAchievements()
		{
			throw new NotImplementedException();
		}

		public void ShowAchievementsUI()
		{
			throw new NotImplementedException();
		}

		public void ShowLeaderboardUI()
		{
			throw new NotImplementedException();
		}
	}
}
