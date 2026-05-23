using UnityEngine;

namespace Data.Analytics
{
	[CreateAssetMenu(menuName = "General/Analytics/Settings", fileName = "AnalyticsSettings", order = 0)]
	public class AnalyticsSettings : ScriptableObject
	{
		public string GameAnalyticsDemoGameKey = string.Empty;

		public string GameAnalyticsDemoSecretKey = string.Empty;

		public string GameAnalyticsPlaytestGameKey = string.Empty;

		public string GameAnalyticsPlaytestSecretKey = string.Empty;

		public string GameAnalyticsReleaseGameKey = string.Empty;

		public string GameAnalyticsReleaseSecretKey = string.Empty;

		public string GameAnalyticsDevGameKey = string.Empty;

		public string GameAnalyticsDevSecretKey = string.Empty;

		public string GameAnalyticsTestGameKey = string.Empty;

		public string GameAnalyticsTestSecretKey = string.Empty;

		[Header("Unity Analytics Environments")]
		public string UnityAnalyticsDemoEnvironment = string.Empty;

		public string UnityAnalyticsPlaytestEnvironment = string.Empty;

		public string UnityAnalyticsTestEnvironment = string.Empty;

		public string UnityAnalyticsReleaseEnvironment = string.Empty;

		public string UnityAnalyticsDevEnvironment = string.Empty;
	}
}
