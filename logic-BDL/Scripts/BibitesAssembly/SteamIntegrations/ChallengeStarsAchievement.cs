using SettingScripts;

namespace SteamIntegrations
{
	public class ChallengeStarsAchievement : Achievement
	{
		private string challengeName;

		private int starLevel;

		protected sealed override bool achievedLocal
		{
			get
			{
				return ChallengesProgress.GetStarOfChallenge(challengeName) >= starLevel;
			}
			set
			{
				base.achievedLocal = value;
			}
		}

		public ChallengeStarsAchievement(string challengeName, int level, string achievementDesc)
		{
			this.challengeName = challengeName;
			starLevel = level;
			title_t = challengeName + string.Format(" Challenge - {0} Star{1}", level, (level > 1) ? "s" : "");
			desc_t = achievementDesc;
			id_t = ChallengesProgress.NameToAchievementKey(challengeName, level);
		}

		public ChallengeStarsAchievement(string achievementID, string achievementTitle, string achievementDesc)
			: base(achievementID, achievementTitle, achievementDesc)
		{
		}
	}
}
