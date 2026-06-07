using System.Collections.Generic;

namespace Gh.Tk
{
	public static class SystemStatus
	{
		public enum PerformanceState
		{
			Red = 0,
			Orange = 1,
			Green = 2
		}

		private static List<SystemStatusItem> _tips;

		private static List<HardwarePerformanceData> _hardwareDataList;

		public static string SquishwareCategoryHeader;

		private const int _minFPS = 25;

		public static IEnumerable<SystemStatusItem> Tips => null;

		private static void RegisterPerformanceTip(SystemStatusItem tip)
		{
		}

		public static void Init()
		{
		}

		private static List<HardwarePerformanceData> GetHardwareData()
		{
			return null;
		}

		private static void RegisterSoftwarePerformanceTips()
		{
		}

		private static void RegisterPerformanceAndSettingsTips()
		{
		}

		private static string GetRatingLetter(float fps)
		{
			return null;
		}

		private static void RegisterSteamCloudPerformanceTip()
		{
		}

		private static void RegisterYouPerformanceTips()
		{
		}

		private static void RegisterHardwarePerformanceTips()
		{
		}
	}
}
