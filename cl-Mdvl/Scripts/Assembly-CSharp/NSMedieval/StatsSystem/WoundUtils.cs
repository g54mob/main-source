namespace NSMedieval.StatsSystem
{
	public static class WoundUtils
	{
		private const int WoundTendingCooldownTime = 1248;

		public static bool Tick(StatsInstance stats, WoundEffectorInfo info)
		{
			long currentTimeMinutes = GetCurrentTimeMinutes();
			if (info.LastTickTime == 0L)
			{
				info.LastTickTime = currentTimeMinutes;
				return false;
			}
			long num = currentTimeMinutes - info.LastTickTime;
			if (num <= 0)
			{
				return false;
			}
			info.LastTickTime = currentTimeMinutes;
			info.CurrentSeverity -= GetSeverityFallOff(stats, info) * (float)num;
			if (info.CurrentSeverity < info.MinSeverity)
			{
				info.NeedTend = false;
				info.NeedRest = false;
				stats.OwnerHumanoidInstance?.UpdateBloodLoss();
			}
			return info.CurrentSeverity <= 0f;
		}

		public static float GetSeverityFallOff(StatsInstance stats, WoundEffectorInfo info)
		{
			float num = info.Blueprint.SeverityFall * (stats.GetAttributeInstance(AttributeType.WoundRegen)?.Value ?? 1f);
			if (!IsTended(info))
			{
				return num / (float)MinutesInHour();
			}
			return num * info.LastTendQuality / (float)MinutesInHour();
		}

		public static bool IsTended(WoundEffectorInfo info)
		{
			if (info == null || !info.NeedTend)
			{
				return true;
			}
			long num = GetCurrentTimeMinutes() - info.LastTendTime;
			if (num >= 0)
			{
				return num <= 1248;
			}
			return false;
		}

		public static float GetTimeLeft(StatsInstance stats, WoundEffectorInfo info)
		{
			float severityFallOff = GetSeverityFallOff(stats, info);
			return info.CurrentSeverity / severityFallOff / (float)MinutesInHour();
		}

		private static long GetCurrentTimeMinutes()
		{
			return GlobalSaveController.CurrentVillageData.DateAndTime.MinutesTotal;
		}

		private static int MinutesInHour()
		{
			return GlobalSaveController.CurrentVillageData.DateAndTime.MinutesInHour;
		}
	}
}
