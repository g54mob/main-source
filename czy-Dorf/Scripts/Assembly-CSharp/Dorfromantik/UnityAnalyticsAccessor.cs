using System.Collections.Generic;
using UnityEngine;

namespace Dorfromantik
{
	public class UnityAnalyticsAccessor : MonoBehaviour
	{
		public static void TriggerTutorialEvent(int currentPhase, Dictionary<string, object> dictionary)
		{
		}

		public static void TriggerGameOverEvent(string sceneName, Dictionary<string, object> dictionary)
		{
		}

		public static void SendTutorialStartEvent()
		{
		}

		public static void SendTutorialCompleteEvent()
		{
		}

		public static void SendCustomEvent(string key, Dictionary<string, object> dictionary)
		{
		}
	}
}
