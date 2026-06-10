using System.Collections.Generic;

namespace NSMedieval
{
	public class DummyAchievementManager : IAchievementManager
	{
		private readonly HashSet<string> unlocked = new HashSet<string>();

		private readonly Dictionary<string, int> statsInt = new Dictionary<string, int>();

		public void UnlockAchievement(string achievementName)
		{
			if (!unlocked.Contains(achievementName))
			{
				unlocked.Add(achievementName);
			}
		}

		public bool IsUnlocked(string name)
		{
			return unlocked.Contains(name);
		}

		public void ResetAll()
		{
			unlocked.Clear();
		}

		public void SetStat(string statName, int value)
		{
			if (!statsInt.ContainsKey(statName))
			{
				statsInt.Add(statName, value);
			}
			else
			{
				statsInt[statName] = value;
			}
		}

		public void IncreaseStat(string statName, int incValue = 1)
		{
			if (!statsInt.ContainsKey(statName))
			{
				statsInt.Add(statName, incValue);
			}
			else
			{
				statsInt[statName] += incValue;
			}
		}

		public int GetStat(string statName)
		{
			if (!statsInt.ContainsKey(statName))
			{
				return 0;
			}
			return statsInt[statName];
		}

		public void ForceFlush()
		{
		}
	}
}
