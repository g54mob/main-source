using Assets.Source.Player;

namespace Assets.Behaviour.Util
{
	public class AchievementChecker
	{
		public delegate bool CheckAchievementDone();

		private float _delayTimer = 1f;

		public string AchievementName;

		public CheckAchievementDone CheckAchievement;

		public AchievementChecker(string name, CheckAchievementDone action)
		{
			AchievementName = name;
			CheckAchievement = action;
		}

		public bool Update(float delta)
		{
			_delayTimer -= delta;
			if (_delayTimer <= 0f)
			{
				if (CheckAchievement())
				{
					SteamAchievement.Trigger(AchievementName);
				}
				return true;
			}
			return false;
		}
	}
}
