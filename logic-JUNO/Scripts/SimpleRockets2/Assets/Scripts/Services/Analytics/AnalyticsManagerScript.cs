using UnityEngine;

namespace Assets.Scripts.Services.Analytics
{
	public class AnalyticsManagerScript
	{
		public static IAnalyticsManager Create(GameObject parent)
		{
			return new DisabledAnalyticsManager();
		}
	}
}
