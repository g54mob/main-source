using UnityEngine;
using UnityEngine.Analytics;

namespace Assets.Nimbatus.Scripts.Common.Events
{
	public class CustomAnalyticsEventOnClick : MonoBehaviour
	{
		public string Event;

		public void OnClick()
		{
			Analytics.CustomEvent(Event);
		}
	}
}
