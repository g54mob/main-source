using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix;
using NSEipix.Base;
using Steamworks;
using UnityEngine;

namespace NSMedieval
{
	public class SteamAchievementManager : IAchievementManager
	{
		public void UnlockAchievement(string achievementName)
		{
			bool isEnabled;
			FVLogInfoInterpolationHandler messageBuilder;
			if (!IsReady())
			{
				messageBuilder = new FVLogInfoInterpolationHandler(60, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Achievements\\SteamAchievementManager.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Steam: Cannot unlock achievement \"");
					messageBuilder.AppendFormatted(achievementName);
					messageBuilder.AppendLiteral("\". IsReady returned false.");
				}
				Log.Info(messageBuilder);
				return;
			}
			if (IsUnlocked(achievementName))
			{
				messageBuilder = new FVLogInfoInterpolationHandler(54, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Achievements\\SteamAchievementManager.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Steam: Cannot unlock achievement \"");
					messageBuilder.AppendFormatted(achievementName);
					messageBuilder.AppendLiteral("\". Already unlocked.");
				}
				Log.Info(messageBuilder);
				return;
			}
			messageBuilder = new FVLogInfoInterpolationHandler(31, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Achievements\\SteamAchievementManager.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("Steam: Unlocking achievement \"");
				messageBuilder.AppendFormatted(achievementName);
				messageBuilder.AppendLiteral("\"");
			}
			Log.Info(messageBuilder);
			SteamUserStats.SetAchievement(achievementName);
			Flush();
		}

		public bool IsUnlocked(string name)
		{
			if (!IsReady())
			{
				return true;
			}
			if (!SteamUserStats.GetAchievement(name, out var pbAchieved))
			{
				return false;
			}
			return pbAchieved;
		}

		public void ResetAll()
		{
			if (!IsReady())
			{
				Log.Info("Steam: Cannot reset all stats and achievements. IsReady returned false.", "C:\\GIT\\dev\\Assets\\Scripts\\Achievements\\SteamAchievementManager.cs");
				return;
			}
			Log.Info("Steam: Resetting all stats and achievements.", "C:\\GIT\\dev\\Assets\\Scripts\\Achievements\\SteamAchievementManager.cs");
			SteamUserStats.ResetAllStats(bAchievementsToo: true);
			SteamUserStats.StoreStats();
			Flush();
		}

		public void SetStat(string statName, int value)
		{
			bool isEnabled;
			int pData;
			if (!IsReady())
			{
				FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(54, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Achievements\\SteamAchievementManager.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Steam: Cannot set stat \"");
					messageBuilder.AppendFormatted(statName);
					messageBuilder.AppendLiteral("\" to ");
					messageBuilder.AppendFormatted(value);
					messageBuilder.AppendLiteral(". IsReady returned false.");
				}
				Log.Info(messageBuilder);
			}
			else if (!SteamUserStats.GetStat(statName, out pData) || value != pData)
			{
				FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(27, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Achievements\\SteamAchievementManager.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Steam: Setting stat \"");
					messageBuilder.AppendFormatted(statName);
					messageBuilder.AppendLiteral("\" to ");
					messageBuilder.AppendFormatted(value);
					messageBuilder.AppendLiteral(".");
				}
				Log.Info(messageBuilder);
				SteamUserStats.SetStat(statName, value);
				Flush(statName);
			}
		}

		public void IncreaseStat(string statName, int incValue = 1)
		{
			bool isEnabled;
			FVLogInfoInterpolationHandler messageBuilder;
			if (!IsReady())
			{
				messageBuilder = new FVLogInfoInterpolationHandler(59, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Achievements\\SteamAchievementManager.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Steam: Cannot increase stat \"");
					messageBuilder.AppendFormatted(statName);
					messageBuilder.AppendLiteral("\" by ");
					messageBuilder.AppendFormatted(incValue);
					messageBuilder.AppendLiteral(". IsReady returned false.");
				}
				Log.Info(messageBuilder);
				return;
			}
			if (!SteamUserStats.GetStat(statName, out int pData))
			{
				messageBuilder = new FVLogInfoInterpolationHandler(50, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Achievements\\SteamAchievementManager.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Steam: Cannot increase stat \"");
					messageBuilder.AppendFormatted(statName);
					messageBuilder.AppendLiteral("\", it does not exist.");
				}
				Log.Info(messageBuilder);
				return;
			}
			messageBuilder = new FVLogInfoInterpolationHandler(30, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Achievements\\SteamAchievementManager.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("Steam: Increasing stat \"");
				messageBuilder.AppendFormatted(statName);
				messageBuilder.AppendLiteral("\" by ");
				messageBuilder.AppendFormatted(incValue);
				messageBuilder.AppendLiteral(".");
			}
			Log.Info(messageBuilder);
			incValue = Mathf.Max(1, incValue);
			SteamUserStats.SetStat(statName, pData + incValue);
			Flush(statName);
		}

		public int GetStat(string statName)
		{
			if (!IsReady())
			{
				bool isEnabled;
				FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(50, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Achievements\\SteamAchievementManager.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Steam: Cannot get stat \"");
					messageBuilder.AppendFormatted(statName);
					messageBuilder.AppendLiteral("\". IsReady returned false.");
				}
				Log.Info(messageBuilder);
				return 0;
			}
			SteamUserStats.GetStat(statName, out int pData);
			return pData;
		}

		public void ForceFlush()
		{
			if (IsReady())
			{
				SteamUserStats.StoreStats();
				MonoSingleton<TaskController>.Instance.WaitFor(0.5f).Then(MonoSingleton<SteamStatManager>.Instance.RefreshStatValues);
			}
		}

		private bool IsReady()
		{
			if (SteamAPI.IsSteamRunning())
			{
				return SteamSdkManager.IsSteamInitialised;
			}
			return false;
		}

		private void Flush(string statName = null)
		{
			if (IsReady())
			{
				if (string.IsNullOrEmpty(statName))
				{
					SteamUserStats.StoreStats();
				}
				else if (MonoSingleton<SteamStatManager>.Instance.ShouldRefresh(statName))
				{
					SteamUserStats.StoreStats();
					MonoSingleton<TaskController>.Instance.WaitFor(0.5f).Then(MonoSingleton<SteamStatManager>.Instance.RefreshStatValues);
				}
			}
		}
	}
}
