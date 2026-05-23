using GameAnalyticsSDK;
using UnityEngine;

namespace Events.Analytics
{
	[CreateAssetMenu(menuName = "Events/Analytics/Progression Event", fileName = "AnalyticsProgressionEvent", order = 2)]
	public class AnalyticsProgressionEvent : BaseEvent<(GAProgressionStatus, string, string, string)>
	{
	}
}
