using System;
using System.Collections.Generic;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix;
using NSEipix.Base;
using UnityEngine;

namespace NSMedieval
{
	public class AchievementManager : MonoSingleton<AchievementManager>
	{
		[Serializable]
		private struct UnlockWithStat
		{
			[SerializeField]
			private string achievementId;

			[SerializeField]
			private string statId;

			[SerializeField]
			private int unlockValue;

			public string AchievementId => achievementId;

			public string StatId => statId;

			public int UnlockValue => unlockValue;
		}

		private IAchievementManager achievementManagerImpl;

		[SerializeField]
		private UnlockWithStat[] unlockAchievementWithStat;

		private Dictionary<string, List<UnlockWithStat>> achievementsByStat;

		private void FillAchievementsByStatDict()
		{
			achievementsByStat = new Dictionary<string, List<UnlockWithStat>>();
			UnlockWithStat[] array = unlockAchievementWithStat;
			for (int i = 0; i < array.Length; i++)
			{
				UnlockWithStat item = array[i];
				if (!achievementsByStat.ContainsKey(item.StatId))
				{
					achievementsByStat.Add(item.StatId, new List<UnlockWithStat>());
				}
				achievementsByStat[item.StatId].Add(item);
			}
		}

		protected override void Awake()
		{
			base.Awake();
			FillAchievementsByStatDict();
		}

		private void Start()
		{
			achievementManagerImpl = new SteamAchievementManager();
		}

		public void UnlockAchievement(string achievementName)
		{
			if (!string.IsNullOrEmpty(achievementName) && !achievementManagerImpl.IsUnlocked(achievementName))
			{
				achievementManagerImpl.UnlockAchievement(achievementName);
			}
		}

		public bool IsUnlocked(string achievementName)
		{
			if (string.IsNullOrEmpty(achievementName))
			{
				return false;
			}
			return achievementManagerImpl.IsUnlocked(achievementName);
		}

		public void ResetAll()
		{
			achievementManagerImpl.ResetAll();
		}

		public void SetStat(string statName, int value)
		{
			if (!string.IsNullOrEmpty(statName))
			{
				achievementManagerImpl.SetStat(statName, value);
				CheckStatAchievementUnlock(statName);
			}
		}

		private void CheckStatAchievementUnlock(string statName)
		{
			MonoSingleton<TaskController>.Instance.WaitForUnscaled(1f).Then(delegate
			{
				if (achievementsByStat.ContainsKey(statName))
				{
					int stat = GetStat(statName);
					List<UnlockWithStat> list = achievementsByStat[statName];
					if (list != null)
					{
						foreach (UnlockWithStat item in list)
						{
							if (stat >= item.UnlockValue && !IsUnlocked(item.AchievementId))
							{
								bool isEnabled;
								FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(47, 3, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Achievements\\AchievementManager.cs");
								if (isEnabled)
								{
									messageBuilder.AppendLiteral("Unlocking achievement \"");
									messageBuilder.AppendFormatted(item.AchievementId);
									messageBuilder.AppendLiteral("\" because stat \"");
									messageBuilder.AppendFormatted(item.StatId);
									messageBuilder.AppendLiteral("\" is >= ");
									messageBuilder.AppendFormatted(item.UnlockValue);
								}
								Log.Info(messageBuilder);
								UnlockAchievement(item.AchievementId);
							}
						}
					}
				}
			});
		}

		public void IncreaseStat(string statName, int incValue = 1)
		{
			if (!string.IsNullOrEmpty(statName) && incValue != 0)
			{
				achievementManagerImpl.IncreaseStat(statName, incValue);
				CheckStatAchievementUnlock(statName);
			}
		}

		public int GetStat(string statName)
		{
			if (string.IsNullOrEmpty(statName))
			{
				return 0;
			}
			return achievementManagerImpl.GetStat(statName);
		}

		public void ForceFlush()
		{
			achievementManagerImpl.ForceFlush();
		}
	}
}
