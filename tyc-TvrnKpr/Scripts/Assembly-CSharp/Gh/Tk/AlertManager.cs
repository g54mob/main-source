using System.Collections.Generic;
using UnityEngine.Scripting;

namespace Gh.Tk
{
	[InitializeOnGameStarted]
	public static class AlertManager
	{
		internal static AdvisorAlertBase[] _advisorAlerts;

		internal static AlertBadgeBase[] _alertBadges;

		internal static List<AlertMessage> _recentMessageHistory;

		private const float _coolDownTimeAnyMessage = 80f;

		internal const float _coolDownSameCategory = 240f;

		private const float _coolDownSameMessage = 960f;

		private static float _lastMessageSpawnedTimestamp;

		internal const int AlertCriticalPriority = 10;

		internal const int AlertPositivePriority = 10;

		internal const int AlertWarningPriority = 0;

		internal const int AlertMinorPriority = -10;

		[Preserve]
		private static void OnGameStarted()
		{
		}

		private static void ResetAlerts()
		{
		}

		internal static void ResetAlertsForNewLevel()
		{
		}

		internal static void NotifyOfNewCvs()
		{
		}

		public static void Update()
		{
		}

		private static bool ShouldShow(AdvisorAlertBase source, AlertMessage msg)
		{
			return false;
		}

		private static bool IsConsideredSameMessage(AlertMessage a, AlertMessage b)
		{
			return false;
		}

		internal static bool GenerateAlert(AdvisorAlertBase source, AlertMessage msg)
		{
			return false;
		}

		private static void TrimMessages()
		{
		}

		public static DataStore Save()
		{
			return null;
		}

		public static void Load(DataStore data)
		{
		}
	}
}
