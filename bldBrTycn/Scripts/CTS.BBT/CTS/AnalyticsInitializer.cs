using GameAnalyticsSDK;
using UnityEngine;

namespace CTS
{
	public class AnalyticsInitializer : MonoBehaviour
	{
		private void Start()
		{
			GameAnalytics.SetBuildAllPlatforms(Application.version);
			GameAnalytics.Initialize();
		}
	}
}
