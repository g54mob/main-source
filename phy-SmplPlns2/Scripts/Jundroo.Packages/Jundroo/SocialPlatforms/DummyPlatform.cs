using System;
using Jundroo.SocialPlatforms.Achievements;

namespace Jundroo.SocialPlatforms
{
	public class DummyPlatform : ISocialPlatformExt, ISocialPlatform
	{
		public const string Name = "Dummy";

		private LocalUser _localUser;

		public ILocalUser localUser => _localUser;

		public bool LoggedOn => true;

		public string PlatformName => "Dummy";

		public void Authenticate(ILocalUser user, Action<bool> callback)
		{
			callback?.Invoke(obj: true);
		}

		public void Authenticate(ILocalUser user, Action<bool, string> callback)
		{
			callback?.Invoke(arg1: true, null);
		}

		public IAchievement CreateAchievement()
		{
			return new Achievement();
		}

		public ILeaderboard CreateLeaderboard()
		{
			return new Leaderboard();
		}

		public bool GetLoading(ILeaderboard board)
		{
			return board?.loading ?? false;
		}

		public void IncrementAchievement(string achievementID, int incrementAmount, bool showProgress, Action<bool> callback)
		{
			callback?.Invoke(obj: true);
		}

		public void IncrementAchievement(string achievementID, float incrementAmount, bool showProgress, Action<bool> callback)
		{
			callback?.Invoke(obj: true);
		}

		public void IncrementStat(string statID, int incrementAmount, ShouldShowProgress showProgress, Action<bool> callback)
		{
			callback?.Invoke(obj: true);
		}

		public void IncrementStat(string statID, float incrementAmount, ShouldShowProgress showProgress, Action<bool> callback)
		{
			callback?.Invoke(obj: true);
		}

		public void Initialize(AchievementDatabase achievementDatabase)
		{
			_localUser = new LocalUser();
		}

		public void LoadAchievementDescriptions(Action<IAchievementDescription[]> callback)
		{
			callback?.Invoke(new IAchievementDescription[0]);
		}

		public void LoadAchievements(Action<IAchievement[]> callback)
		{
			callback?.Invoke(new IAchievement[0]);
		}

		public void LoadFriends(ILocalUser user, Action<bool> callback)
		{
			_localUser.friends = new IUserProfile[0];
			callback?.Invoke(obj: true);
		}

		public void LoadScores(ILeaderboard board, Action<bool> callback)
		{
			if (board != null)
			{
				board.LoadScores(callback);
			}
			else
			{
				callback?.Invoke(obj: false);
			}
		}

		public void LoadScores(string leaderboardID, Action<IScore[]> callback)
		{
			callback?.Invoke(new IScore[0]);
		}

		public void LoadUsers(string[] userIDs, Action<IUserProfile[]> callback)
		{
			callback?.Invoke(new IUserProfile[0]);
		}

		public void ReportProgress(string achievementID, double progress, Action<bool> callback)
		{
			callback?.Invoke(obj: true);
		}

		public void ReportScore(long score, string board, Action<bool> callback)
		{
			callback?.Invoke(obj: true);
		}

		public void ResetAllAchievements()
		{
		}

		public void ShowAchievementsUI()
		{
		}

		public void ShowLeaderboardUI()
		{
		}
	}
}
