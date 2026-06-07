using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Services.Analytics
{
	public class DisabledAnalyticsManager : IAnalyticsManager
	{
		public bool Enabled => false;

		public bool Initialized => true;

		public SceneTimeTracker SceneTimeTracker => null;

		public void LogEvent(string eventName, Dictionary<string, object> eventData)
		{
			Debug.LogWarning("Attempting to log analytics data with analytics completely disabled in the build. This is likely inefficient and the analytics code should be wrapped in an if statement checking to see if analytics are enabled.");
		}
	}
}
