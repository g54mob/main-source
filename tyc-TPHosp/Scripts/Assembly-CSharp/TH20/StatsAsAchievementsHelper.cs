#define LOG_LEVEL_VERBOSE
using System.Collections.Generic;

namespace TH20
{
	public class StatsAsAchievementsHelper
	{
		private readonly Dictionary<Stat, List<StatAsAchievement>> _statToAchievements = new Dictionary<Stat, List<StatAsAchievement>>();

		private StatAsAchievement[] _consoleAchievements;

		public void SetAchievementData(StatsAsAchievementsData achievementData)
		{
			SetupConsoleAchievements(achievementData);
			StatAsAchievement[] consoleAchievements = _consoleAchievements;
			foreach (StatAsAchievement statAsAchievement in consoleAchievements)
			{
				if (!_statToAchievements.TryGetValue(statAsAchievement._stat, out var value))
				{
					value = new List<StatAsAchievement>();
					_statToAchievements[statAsAchievement._stat] = value;
				}
				value.Add(statAsAchievement);
			}
		}

		private void SetupConsoleAchievements(StatsAsAchievementsData achievementData)
		{
			StatAsAchievement[] achievements = achievementData.Achievements;
			_consoleAchievements = new StatAsAchievement[achievements.Length];
			for (int i = 0; i < achievements.Length; i++)
			{
				_consoleAchievements[i] = achievements[i];
			}
		}

		public void UpdateAchievementValues(Stat stat, int value, List<StatAsAchievement> updatedAchievements)
		{
			updatedAchievements.Clear();
			if (!_statToAchievements.TryGetValue(stat, out var value2))
			{
				Logging.Error($"Failed to find achievements for stat value {stat}");
				return;
			}
			foreach (StatAsAchievement item in value2)
			{
				item._currentValue = value;
				updatedAchievements.Add(item);
			}
		}
	}
}
