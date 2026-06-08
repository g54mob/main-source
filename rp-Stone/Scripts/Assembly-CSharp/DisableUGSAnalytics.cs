using UnityEngine;
using UnityEngine.Analytics;

public class DisableUGSAnalytics : MonoBehaviour
{
	private void Awake()
	{
		Analytics.initializeOnStartup = false;
		Analytics.enabled = false;
		PerformanceReporting.enabled = false;
		Analytics.limitUserTracking = true;
		Analytics.deviceStatsEnabled = false;
	}
}
